using Frontend.Models;
using Newtonsoft.Json;
using System.Text;

namespace Frontend
{
    public partial class Receptek : Form
    {
        public Receptek()
        {
            InitializeComponent();
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

    }
}