using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    public static class ApiKommunikacioTesztelese
    {
        public static async void getToolStripMenuItem_Click()
        {
            // TESZT - recept lekérése Id alapján (get/id)
            Recept recept = await ApiKommunikacio.ReceptLekereseAsync(7);
        }

        public static async void postToolStripMenuItem_Click()
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

        public static async void putToolStripMenuItem_Click()
        {
            Recept modositottRecept = new Recept()
            {
                ReceptId = 19,
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

        public static async void deleteToolStripMenuItem_Click()
        {
            await ApiKommunikacio.ReceptTorlese(15);
        }
    }
}
