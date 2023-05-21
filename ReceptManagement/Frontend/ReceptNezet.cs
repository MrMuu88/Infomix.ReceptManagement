using Frontend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO designerben control-ok elhelyezése

namespace Frontend
{
    public partial class ReceptNezet : Form
    {
        private int ReceptID = -1;

        // új recept létrehozásához
        public ReceptNezet()
        {
            InitializeComponent();
        }

        // meglévő recept megtekintése
        public ReceptNezet(int id)
        {
            ReceptID = id;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // TODO: Mentés
            this.Close();
        }

        private void btnMegsem_Click(object sender, EventArgs e)
        {
            // TODO: Nincs mentés
            this.Close();
        }

        // amikor már betöltődött a Recept nézet
        private async void ReceptNezet_Load(object sender, EventArgs e)
        {
            if (this.ReceptID > 0)
            {
                Recept felirtRecept = await ApiKommunikacio.ReceptLekereseAsync(this.ReceptID);
            }
        }
    }
}
