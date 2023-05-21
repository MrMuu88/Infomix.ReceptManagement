using Frontend.Models;
using Frontend.ResponseClasses;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Text;

namespace Frontend
{
    public partial class Receptek : Form
    {
        private int lapozoKihagyas = 0;

        public List<PrescriptionResponse> felirtReceptek;

        public Receptek()
        {
            InitializeComponent();
        }

        private async void Receptek_Load(object sender, EventArgs e)
        {
            ReceptekBetoltese();
        }

        private void btnReceptekFrissitese_Click(object sender, EventArgs e)
        {
            ReceptekBetoltese();
        }

        private void btnUjRecept_Click(object sender, EventArgs e)
        {
            ReceptNezet ujRecept = new ReceptNezet();
            ujRecept.ShowDialog();
            // Ha történt módosítás akkor újratöltöm a recept listát
            if (ujRecept.DialogResult == DialogResult.OK)
            {
                ReceptekBetoltese();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index = 0;
            string strIndex = listView1.SelectedIndices[0].ToString();
            if (int.TryParse(strIndex, out index) == false)
            {
                MessageBox.Show("Nincs kijelölve recept");
            }
            PrescriptionResponse recept = felirtReceptek[index];

            // már méglévõ felírt recept megnyitása
            ReceptNezet receptNezet = new ReceptNezet(recept.PrescriptionId);
            receptNezet.ShowDialog();

            // Ha történt módosítás akkor újratöltöm a recept listát
            if (receptNezet.DialogResult == DialogResult.OK)
            {
                ReceptekBetoltese();
            }
        }

        private async void btnReceptekTorlese_Click(object sender, EventArgs e)
        {
            // Ha nincs kijelölve egy recept sem akkor return
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Nincs kijelölve egy recept sem.", "Törlés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // rákérdez hogy szeretné-e törölni, és ha nem-re kattint akkor return
            if (MessageBox.Show("Biztosan szeretné törölni a kijelölt recepteket?", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            // Ha mégis törölni szeretné, akkor egyesével törlés
            this.Cursor = Cursors.WaitCursor;
            foreach (var torlendoIndex in listView1.SelectedIndices)
            {
                string strIndex = torlendoIndex.ToString();
                int index = int.Parse(strIndex);
                PrescriptionResponse torlendoRecept = felirtReceptek[index];
                // Recept törlése RESTAPI-n keresztül
                await ApiKommunikacio.ReceptTorlese(torlendoRecept.PrescriptionId);
            }
            this.Cursor = Cursors.Default;
            ReceptekBetoltese();
        }

        private async void ReceptekBetoltese()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                listView1.Items.Clear();
                felirtReceptek = await ApiKommunikacio.ReceptekLekereseAsync(20, lapozoKihagyas);
                foreach (var r in felirtReceptek)
                {
                    ListViewItem lvi = new ListViewItem(r.PatientName);
                    lvi.SubItems.Add(r.PrescriptionText);
                    lvi.SubItems.Add(r.PrescribedDate.ToString());
                    lvi.SubItems.Add(r.PrescriptionId.ToString());
                    listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnUjabbReceptek_Click(object sender, EventArgs e)
        {
            lapozoKihagyas -= 20;
            if (lapozoKihagyas < 0)
            {
                MessageBox.Show("Ezek a legfrissebb receptek, nincsenek újabbak", "Legújabb receptek.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lapozoKihagyas = 0;
            }
            ReceptekBetoltese();
        }

        private void btnRegebbiReceptek_Click(object sender, EventArgs e)
        {
            lapozoKihagyas += 20;
            ReceptekBetoltese();
        }

        private void btnKereses_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<PrescriptionResponse> felirtReceptekSzurofeltetelekkel = new List<PrescriptionResponse>(felirtReceptek);
            // Szûrés páciens nevére
            if (!string.IsNullOrEmpty(tbNev.Text))
            {
                felirtReceptekSzurofeltetelekkel = felirtReceptekSzurofeltetelekkel.Where(r => r.PatientName.ToUpper().Contains(tbNev.Text.ToUpper())).ToList();
            }
            // Szûrés recept szövegére
            if (!string.IsNullOrEmpty(tbReceptSzovege.Text))
            {
                felirtReceptekSzurofeltetelekkel = felirtReceptekSzurofeltetelekkel.Where(r => r.PrescriptionText.ToUpper().Contains(tbReceptSzovege.Text.ToUpper())).ToList();
            }
            // Szûrés dátumra (egy adott napon belül)
            felirtReceptekSzurofeltetelekkel = felirtReceptekSzurofeltetelekkel.Where(r => r.PrescribedDate.Date == dtpDatum.Value.Date).ToList();

            foreach (var r in felirtReceptekSzurofeltetelekkel)
            {
                ListViewItem lvi = new ListViewItem(r.PatientName);
                lvi.SubItems.Add(r.PrescriptionText);
                lvi.SubItems.Add(r.PrescribedDate.ToString());
                lvi.SubItems.Add(r.PrescriptionId.ToString());
                listView1.Items.Add(lvi);
            }
        }
    }
}