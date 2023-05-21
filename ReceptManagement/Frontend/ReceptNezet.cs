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
using Frontend.ResponseClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Diagnostics;

// TODO designerben control-ok elhelyezése

namespace Frontend
{
    public partial class ReceptNezet : Form
    {
        private int ReceptID = -1;
        private List<BNOResponse> BNOk;
        private List<PatientsResponse> Paciensek;
        Recept felirtRecept;

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

        // amikor már betöltődött a Recept nézet
        private async void ReceptNezet_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await SzuksegesAdatokBetoltese();
            // Ha a ReceptID megvan adva, akkor egy már meglévő receptet kell betölteni
            if (this.ReceptID > 0)
            {
                await ReceptAdatokBetoltese();
                cbPaciens.Visible = false;
                cbBNO.Visible = false;
                lblPaciensNeve.Visible = true;
                lbBNO.Visible = true;
            }
            // ha új receptet szeretnénk kiállítani
            else
            {
                cbPaciens.Visible = true;
                cbBNO.Visible = true;
                lblPaciensNeve.Visible = false;
                lbBNO.Visible = false;
            }

            cbPaciens.ValueMember = "PatientId";
            cbPaciens.DisplayMember = "PatientName";
            cbPaciens.DataSource = Paciensek;

            cbBNO.ValueMember = "BNOId";
            cbBNO.DisplayMember = "BNOKod";
            cbBNO.DataSource = BNOk;

            this.Cursor = Cursors.Default;
        }

        // BNO és Páciens adatok betöltése
        private async Task SzuksegesAdatokBetoltese()
        {
            BNOk = await ApiKommunikacio.BNOkLekereseAsync();
            Paciensek = await ApiKommunikacio.PaciensekLekereseAsync();
        }

        // BNO és Páciens adatok betöltése
        private async Task ReceptAdatokBetoltese()
        {
            felirtRecept = await ApiKommunikacio.ReceptLekereseAsync(this.ReceptID);
            tboxReceptSzovege.Text = felirtRecept.ReceptSzovege;
            lblReceptKiallitasDatuma.Text = felirtRecept.ReceptKiallitasDatuma.ToString();
            lblPaciensNeve.Text = Paciensek.Where(p => p.PatientId == felirtRecept.PaciensId).FirstOrDefault().PatientName;
            lbBNO.Text = BNOk.Where(b => b.BNOId == felirtRecept.BNOId).FirstOrDefault().BNOKod;
        }

        // Mentés
        private async void btnOk_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PatientsResponse kivalasztottPaciens = cbPaciens.SelectedItem as PatientsResponse;
                BNOResponse kivalasztottBNO = cbBNO.SelectedItem as BNOResponse;
                // Recept Módosítás
                if (ReceptID > 0)
                {
                    // TODO többi property, és controlok
                    felirtRecept.ReceptSzovege = tboxReceptSzovege.Text;
                    await ApiKommunikacio.ReceptModositasaAsync(felirtRecept);
                }
                // Új Recept hozzáadása
                else
                {
                    // TODO többi property, és controlok
                    felirtRecept = new Recept()
                    {
                        PaciensId = kivalasztottPaciens.PatientId,
                        BNOId = kivalasztottBNO.BNOId,
                        ReceptSzovege = tboxReceptSzovege.Text,
                        ReceptKiallitasDatuma = DateTime.Now,
                    };
                    await ApiKommunikacio.ReceptHozzaadasaAsync(felirtRecept);
                }
            }
            catch(Exception ex) {
                ;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }

        private void btnMegsem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPaciens_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PatientsResponse kivalasztottPaciens = cbPaciens.SelectedItem as PatientsResponse;

        }

        private void cbBNO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BNOResponse kivalasztottBNO = cbBNO.SelectedItem as BNOResponse;
        }
    }
}
