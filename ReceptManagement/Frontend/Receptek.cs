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
            // Ha t�rt�nt m�dos�t�s akkor �jrat�lt�m a recept list�t
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
                MessageBox.Show("Nincs kijel�lve recept");
            }
            PrescriptionResponse recept = felirtReceptek[index];

            // m�r m�gl�v� fel�rt recept megnyit�sa
            ReceptNezet receptNezet = new ReceptNezet(recept.PrescriptionId);
            receptNezet.ShowDialog();

            // Ha t�rt�nt m�dos�t�s akkor �jrat�lt�m a recept list�t
            if (receptNezet.DialogResult == DialogResult.OK)
            {
                ReceptekBetoltese();
            }
        }

        private async void btnReceptekTorlese_Click(object sender, EventArgs e)
        {
            // Ha nincs kijel�lve egy recept sem akkor return
            if (listView1.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Nincs kijel�lve egy recept sem.", "T�rl�s", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // r�k�rdez hogy szeretn�-e t�r�lni, �s ha nem-re kattint akkor return
            if (MessageBox.Show("Biztosan szeretn� t�r�lni a kijel�lt recepteket?", "T�rl�s", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            // Ha m�gis t�r�lni szeretn�, akkor egyes�vel t�rl�s
            this.Cursor = Cursors.WaitCursor;
            foreach (var torlendoIndex in listView1.SelectedIndices)
            {
                string strIndex = torlendoIndex.ToString();
                int index = int.Parse(strIndex);
                PrescriptionResponse torlendoRecept = felirtReceptek[index];
                // Recept t�rl�se RESTAPI-n kereszt�l
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
                MessageBox.Show("Ezek a legfrissebb receptek, nincsenek �jabbak", "Leg�jabb receptek.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lapozoKihagyas = 0;
            }
            ReceptekBetoltese();
        }

        private void btnRegebbiReceptek_Click(object sender, EventArgs e)
        {
            lapozoKihagyas += 20;
            ReceptekBetoltese();
        }
    }
}