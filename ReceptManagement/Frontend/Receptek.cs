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
            // TESZT - recept feltöltése (post)
            /*
            ERROR 400
            {
              "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
              "title": "One or more validation errors occurred.",
              "status": 400,
              "traceId": "00-cc65769a68ffd3e2ba7152af3ae5ce2b-632cfa4bd194d3ca-00",
              "errors": {
                "recept": [
                  "The recept field is required."
                ],
                "$.paciens.receptek[0]": [
                  "The JSON value could not be converted to Backend.Models.Recept. Path: $.paciens.receptek[0] | LineNumber: 18 | BytePositionInLine: 14."
                ]
              }
            }
             */
            Recept ujRecept = new Recept()
            {
                PaciensId = 3, // Aladar
                BNOId = 6, // Rotavirus
                AltalanosJogcimmel = false,
                EURendelkezessel = false,
                EUTeritesKotelesAronRendelve = false,
                Helyettesitheto = false,
                Kozgyogyellatottnak = false,
                ReceptKiallitasDatuma = DateTime.Now,
                ReceptSzovege = "Aladarnak Rotavirusra",
                TeljesAronRendelve = false
            };
            await ApiKommunikacio.ReceptHozzaadasaAsync(ujRecept);
        }

        private async void putToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recept modositottRecept = new Recept()
            {
                PaciensId = 3, // Aladar
                BNOId = 6, // Rotavirus
                AltalanosJogcimmel = false,
                EURendelkezessel = false,
                EUTeritesKotelesAronRendelve = false,
                Helyettesitheto = false,
                Kozgyogyellatottnak = false,
                ReceptKiallitasDatuma = DateTime.Now,
                ReceptSzovege = "Aladarnak Rotavirusra modositva",
                TeljesAronRendelve = false
            };
            await ApiKommunikacio.ReceptModositasaAsync(15, modositottRecept);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ApiKommunikacio.ReceptTorlese(15);
        }

    }
}