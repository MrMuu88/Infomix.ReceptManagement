using Frontend.Models;
using Frontend.ResponseClasses;
using Newtonsoft.Json;
using System;
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
            this.Cursor = Cursors.WaitCursor;
            try
            {
                felirtReceptek = await ApiKommunikacio.ReceptekLekereseAsync(4, 0);
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
            // TESZT - recept lek�r�se Id alapj�n (get/id)
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
                ReceptSzovege = "Aladarnak n�th�s megf�z�sos k�h�g�s csillap�t�s�ra (modositva)",// eredetileg: "Aladarnak Rotavirusra"
                TeljesAronRendelve = false
            };
            await ApiKommunikacio.ReceptModositasaAsync(modositottRecept);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ApiKommunikacio.ReceptTorlese(15);
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
                MessageBox.Show("Nincs kijel�lve recept");
            }
            PrescriptionResponse recept = felirtReceptek[index];

            // m�r m�gl�v� fel�rt recept megnyit�sa
            ReceptNezet receptNezet = new ReceptNezet(recept.PrescriptionId);
            receptNezet.ShowDialog();
        }
    }
}