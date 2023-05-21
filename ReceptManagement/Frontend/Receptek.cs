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
        public List<PrescriptionResponse> felirtReceptek;

        public Receptek()
        {
            InitializeComponent();
        }

        private async void Receptek_Load(object sender, EventArgs e)
        {
            ReceptekBetoltese();
        }

        private async void ReceptekBetoltese()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                listView1.Items.Clear();
                felirtReceptek = await ApiKommunikacio.ReceptekLekereseAsync(20, 0);
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

        private async void getToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TESZT - recept lekérése Id alapján (get/id)
            Recept recept = await ApiKommunikacio.ReceptLekereseAsync(7);
        }

        private async void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recept ujRecept = new Recept()
            {
                PaciensId = 3, // Aladar
                BNOId = 6, // Rotavirus
                AltalanosJogcimmel = false,
                EURendelkezessel = false,
                EUTeritesKotelesAronRendelve = false,
                Helyettesitheto = false,
                Kozgyogyellatottnak = false,
                ReceptKiallitasDatuma = DateTime.Now.ToUniversalTime(),
                ReceptSzovege = "Aladarnak Rotavirusra",
                TeljesAronRendelve = false
            };
            await ApiKommunikacio.ReceptHozzaadasaAsync(ujRecept);
        }

        private async void putToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recept modositottRecept = new Recept()
            {
                ReceptId = 17,
                PaciensId = 3, // Aladar
                BNOId = 7, // Kohoges
                AltalanosJogcimmel = false,
                EURendelkezessel = false,
                EUTeritesKotelesAronRendelve = false,
                Helyettesitheto = false,
                Kozgyogyellatottnak = false,
                ReceptKiallitasDatuma = DateTime.Now.ToUniversalTime(),
                ReceptSzovege = "Aladarnak náthás megfázásos köhögés csillapítására (modositva)",// eredetileg: "Aladarnak Rotavirusra"
                TeljesAronRendelve = false
            };
            await ApiKommunikacio.ReceptModositasaAsync(modositottRecept);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ApiKommunikacio.ReceptTorlese(15);
        }

        private void btnReceptekFrissitese_Click(object sender, EventArgs e)
        {
            ReceptekBetoltese();
        }

        private void btnUjRecept_Click(object sender, EventArgs e)
        {
            ReceptNezet ujRecept = new ReceptNezet();
            ujRecept.ShowDialog();
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


    }
}