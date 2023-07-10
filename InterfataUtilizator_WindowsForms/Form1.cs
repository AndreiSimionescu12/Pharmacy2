using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;
using Farmacie;
using System.Collections;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Pharmacy_Administration : Form
    {
        DataTable tabel_afisare = new DataTable();
        IStocareData adminfarmacie;
        //private int index_obiect_cautat;
        List<Medicament> medicamente;
        public int numarare_invalidari=0;
        public int numar_tipuri_administari_selectate=0;
        public const string consttextnume= "Introduceti un nume";
        public const string consttextpret = "Intropduceti un pret";
        public const string consttextdata_expirare="Introudceti data de expirare";
        public const string const_afisare_mesaj_nume = "Format incorect pentru nume !";
        public const string const_afisare_mesaj_tip_administrare = "Format incorect la tipul de administrare !";
        public const string const_afisare_mesaj_pret = "Format incorect pentru pret !";
        public const string const_afisare_mesaj_data_expirare = "Format incorect pentru data expirarii !";
        public const string const_afisare_mesaj_categorie_de_varsta = "Nu ati selectat o categorie de varsta !";
        
        public Pharmacy_Administration()
        {

            adminfarmacie = StocareFactory.GetAdministratorStocare();

            

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //

            label6.Visible = true;
            tabel_afisare.Columns.Add("Id", typeof(int));
            tabel_afisare.Columns.Add("Nume", typeof(string));
            tabel_afisare.Columns.Add("Tip administrare", typeof(string));
            tabel_afisare.Columns.Add("Pret", typeof(float));
            tabel_afisare.Columns.Add("Data si ora expirarii", typeof(DateTime));
            tabel_afisare.Columns.Add("Varsta administrare", typeof(prospect));
            

            //
            panelCautare.Visible = false;
            medicamente = adminfarmacie.GetMedicamente();
            int nr_medicamente = medicamente.Count;
            Medicament.IdUltimMedicament = nr_medicamente;
            panel_universal.Visible = true;
            panel_adaugare.Visible = false;
            panelAfisare.Visible = false;
            ResetareControale();
            sidepanelbutoane.Height = button1.Height;
            sidepanelbutoane.Top = button1.Top;

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            panelCautare.Visible = false;
            lblAntetAfisare_Editare.Text = "Formular adaugare medicament";
            ResetareControale();
            panel_universal.Visible = true;
            panel_adaugare.Visible = true;
            panelAfisare.Visible = false;
            btn_add_medicament.Visible = true;
            btnEditare_medicament.Visible = false;
            sidepanelbutoane.Height = button2.Height;
            sidepanelbutoane.Top = button2.Top;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            AdaugareInComboBoxId();
            AdaugareInComoboBoxNume();
            panelCautare.Visible = true;
            lblAntetAfisare_Editare.Text = "Formular editare medicament";
            ResetareControaleCautare();
            ResetareControale();
            panel_universal.Visible = true;
            panel_adaugare.Visible = true;
            panelAfisare.Visible = false;
            btn_add_medicament.Visible = false;
            btnEditare_medicament.Visible = true;
            sidepanelbutoane.Height = button4.Height;
            sidepanelbutoane.Top = button4.Top;
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            label6.Visible = false;

            dataGridView1.DataSource = null;
            //tabel_afisare.Columns.Clear();
            
            
            panelCautare.Visible = false;

            tabel_afisare.Rows.Clear();
            foreach (Medicament m in medicamente)
            {
                tabel_afisare.Rows.Add(m.IdMedicament, m.ReturnareNumeMedicament, m.TipAdministrare, m.Pret, m.DataExpirarii, m.varsta_administrare);
            }

            dataGridView1.DataSource = tabel_afisare;

            panel_universal.Visible = true;
            panel_adaugare.Visible = false;
            panelAfisare.Visible = true;
            sidepanelbutoane.Height = button5.Height;
            sidepanelbutoane.Top = button5.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            panelCautare.Visible = false;
            panel_universal.Visible = true;
            panelAfisare.Visible = false;
            panel_adaugare.Visible = false;
            sidepanelbutoane.Height = button1.Height;
            sidepanelbutoane.Top = button1.Top;
        }

        private void adaugare_medicamente1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void ResetareControale()
        {
            txtNume.Text = consttextnume;
            ckb_Oral.Checked = false;
            ckbocular.Checked = false;
            ckbbucal.Checked = false;
            ckbauricular.Checked = false;
            ckbIntraRectal.Checked = false;
            ckbsublingual.Checked = false;
            txtPret.Text = consttextpret;
            txtDataexpirare.Text = consttextdata_expirare;
            rdbCopil.Checked = false;
            rdbAdult.Checked = false;
            rdbBatran.Checked = false;
            
        }

        private void txtNume_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTipAdministrare_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPret_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDataexpirare_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNume_MouseClick(object sender, MouseEventArgs e)
        {
            txtNume.Clear();
        }

        private void txtTipAdministrare_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtPret_MouseClick(object sender, MouseEventArgs e)
        {
            txtPret.Clear();
        }

        private void txtDataexpirare_MouseClick(object sender, MouseEventArgs e)
        {
            txtDataexpirare.Clear();
        }

        private void btn_add_medicament_Click(object sender, EventArgs e)
        {
            numarare_invalidari = 0;
            numar_tipuri_administari_selectate = 0;
            string nume = txtNume.Text;
            string pret_medicament = txtPret.Text;
            string data_expirarii = txtDataexpirare.Text;
            bool validare_categorie_de_varsta;
            int NUME;
            int PRET;
            DateTime EXPIRARE;
            bool validare_nume = int.TryParse(nume,out NUME);
            bool sunt_spatii_nume = String.IsNullOrWhiteSpace(nume);
            if (validare_nume || nume == "" || sunt_spatii_nume ||txtNume.Text==consttextnume)
            {
                MessageBox.Show(const_afisare_mesaj_nume,"Nume medicament", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numarare_invalidari++;
            }
            bool validare_pret = int.TryParse(pret_medicament, out PRET);
            bool sunt_spatii_pret = String.IsNullOrWhiteSpace(pret_medicament);
            if (!validare_pret || pret_medicament=="" || sunt_spatii_pret || txtPret.Text==consttextpret)
            {
                numarare_invalidari++;
                MessageBox.Show(const_afisare_mesaj_pret,"Pret", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bool validare_data_expirare = DateTime.TryParse(data_expirarii,out EXPIRARE);
            bool sunt_spatii_data_expirare = String.IsNullOrWhiteSpace(data_expirarii);
            if (!validare_data_expirare || data_expirarii=="" || sunt_spatii_data_expirare || txtDataexpirare.Text==consttextdata_expirare)
            {
                numarare_invalidari++;
                MessageBox.Show(const_afisare_mesaj_data_expirare,"Data de expirare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            validare_categorie_de_varsta = categorie_de_varsta_selectata();
            if(!validare_categorie_de_varsta)
                MessageBox.Show(const_afisare_mesaj_categorie_de_varsta,"Categorie de varsta",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            numar_tipuri_administari_selectate = Tipuri_de_administrare_selectate();
            if (numar_tipuri_administari_selectate == 0)
                MessageBox.Show("Nu ati selectat nici un tip de administrare","Tip de administrare",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (numar_tipuri_administari_selectate > 2)
                MessageBox.Show("Numarul maxim de tipuri de administrare este 2","Tip de administrare",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if(numarare_invalidari==0 && (numar_tipuri_administari_selectate==1 || numar_tipuri_administari_selectate==2) && validare_categorie_de_varsta==true)
            {
                MessageBox.Show("Adaugarea a fost facuta cu succes","Formular adaugare",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Medicament m = new Medicament();
                string numecomplet_tip_administrare ="";
                if(ckbauricular.Checked==true)
                {
                    numecomplet_tip_administrare = numecomplet_tip_administrare+ckbauricular.Text + ";";
                }
                if(ckbbucal.Checked==true)
                {
                    numecomplet_tip_administrare = numecomplet_tip_administrare+ckbbucal.Text + ";";
                }
                if(ckbIntraRectal.Checked==true)
                {
                    numecomplet_tip_administrare = numecomplet_tip_administrare+ckbIntraRectal.Text + ";";
                }
                if(ckbocular.Checked==true)
                {
                    numecomplet_tip_administrare = numecomplet_tip_administrare+ckbocular.Text + ";";
                }
                if(ckbsublingual.Checked==true)
                {
                    numecomplet_tip_administrare = numecomplet_tip_administrare+ckbsublingual.Text + ";";
                }
                if(ckb_Oral.Checked==true)
                {
                    numecomplet_tip_administrare = numecomplet_tip_administrare+ckb_Oral.Text + ";";
                }
                
                

                Medicament med = new Medicament(nume,numecomplet_tip_administrare,PRET,EXPIRARE);
                prospect? categorie_checked = categorie_varsta_selectata();
                med.varsta_administrare = categorie_checked.Value;
                medicamente.Add(med);
                adminfarmacie.AddMedicament(med);

                ResetareControale();
            }
            else
            {
                MessageBox.Show("Date invalide !!! Verificati daca datele sunt valide !!!", "Formular adaugare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private prospect? categorie_varsta_selectata()
        {
            if(rdbCopil.Checked==true)
            {
                return prospect.COPIL;
            }
            if(rdbAdult.Checked==true)
            {
                return prospect.ADULT;
            }
            if(rdbBatran.Checked==true)
            {
                return prospect.BATRAN;
            }

            return null;
        }

        private bool categorie_de_varsta_selectata()
        {
            if (rdbAdult.Checked == true || rdbCopil.Checked == true || rdbBatran.Checked == true)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        private int Tipuri_de_administrare_selectate()
        {
            int nr = 0;
            if (ckbauricular.Checked == true)
                nr++;
            if(ckbbucal.Checked==true)
                nr++;
            if(ckbocular.Checked==true)
                nr++;
            if (ckbIntraRectal.Checked == true)
                nr++;
            if (ckbsublingual.Checked == true)
                nr++;
            if (ckb_Oral.Checked == true)
                nr++;

            return nr;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel_universal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdaugareInComoboBoxNume()
        {
            comboBoxNume.Items.Clear();
            foreach (Medicament m in medicamente)
            {
                comboBoxNume.Items.Add(m.ReturnareNumeMedicament.ToString());
            }
        }

        private void AdaugareInComboBoxId()
        {
            comboBoxId.Items.Clear();
            foreach (Medicament m in medicamente)
            {
                comboBoxId.Items.Add(m.IdMedicament.ToString());
            }
        }

        private void panelCautare_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditare_medicament_Click(object sender, EventArgs e)
        {
            
            int idmed;
            string numemed;
            bool valid_id = int.TryParse(comboBoxId.Text, out idmed);
            numemed = comboBoxNume.Text;

            Medicament med_cautat = adminfarmacie.GetMedicament(idmed, numemed);

            if (med_cautat == null)
            {
                MessageBox.Show("Medicamentul pe care doriti sa il editati nu a fost gasit.\nTrebuie mai intai sa cautati un medicament si sa il gasiti pentru a putea sa il editati");
            }
            else
            {
                //
                numarare_invalidari = 0;
                numar_tipuri_administari_selectate = 0;
                string nume = txtNume.Text;
                string pret_medicament = txtPret.Text;
                string data_expirarii = txtDataexpirare.Text;
                bool validare_categorie_de_varsta;
                int NUME;
                int PRET;
                DateTime EXPIRARE;
                //

                bool validare_nume = int.TryParse(nume, out NUME);
                bool sunt_spatii_nume = String.IsNullOrWhiteSpace(nume);
                if (validare_nume || nume == "" || sunt_spatii_nume || txtNume.Text == consttextnume)
                {
                    MessageBox.Show(const_afisare_mesaj_nume, "Nume medicament", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    numarare_invalidari++;
                }

                bool validare_pret = int.TryParse(pret_medicament, out PRET);
                bool sunt_spatii_pret = String.IsNullOrWhiteSpace(pret_medicament);
                if (!validare_pret || pret_medicament == "" || sunt_spatii_pret || txtPret.Text == consttextpret)
                {
                    numarare_invalidari++;
                    MessageBox.Show(const_afisare_mesaj_pret, "Pret", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                bool validare_data_expirare = DateTime.TryParse(data_expirarii, out EXPIRARE);
                bool sunt_spatii_data_expirare = String.IsNullOrWhiteSpace(data_expirarii);
                if (!validare_data_expirare || data_expirarii == "" || sunt_spatii_data_expirare || txtDataexpirare.Text == consttextdata_expirare)
                {
                    numarare_invalidari++;
                    MessageBox.Show(const_afisare_mesaj_data_expirare, "Data de expirare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                validare_categorie_de_varsta = categorie_de_varsta_selectata();
                if (!validare_categorie_de_varsta)
                    MessageBox.Show(const_afisare_mesaj_categorie_de_varsta, "Categorie de varsta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                numar_tipuri_administari_selectate = Tipuri_de_administrare_selectate();
                if (numar_tipuri_administari_selectate == 0)
                    MessageBox.Show("Nu ati selectat nici un tip de administrare", "Tip de administrare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (numar_tipuri_administari_selectate > 2)
                    MessageBox.Show("Numarul maxim de tipuri de administrare este 2", "Tip de administrare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (numarare_invalidari == 0 && (numar_tipuri_administari_selectate == 1 || numar_tipuri_administari_selectate == 2) && validare_categorie_de_varsta == true)
                {
                    MessageBox.Show("Editarea a fost facuta cu succes", "Formular editare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // Medicament m = new Medicament();
                    string numecomplet_tip_administrare = "";
                    if (ckbauricular.Checked == true)
                    {
                        numecomplet_tip_administrare = numecomplet_tip_administrare + ckbauricular.Text + ";";
                    }
                    if (ckbbucal.Checked == true)
                    {
                        numecomplet_tip_administrare = numecomplet_tip_administrare + ckbbucal.Text + ";";
                    }
                    if (ckbIntraRectal.Checked == true)
                    {
                        numecomplet_tip_administrare = numecomplet_tip_administrare + ckbIntraRectal.Text + ";";
                    }
                    if (ckbocular.Checked == true)
                    {
                        numecomplet_tip_administrare = numecomplet_tip_administrare + ckbocular.Text + ";";
                    }
                    if (ckbsublingual.Checked == true)
                    {
                        numecomplet_tip_administrare = numecomplet_tip_administrare + ckbsublingual.Text + ";";
                    }
                    if (ckb_Oral.Checked == true)
                    {
                        numecomplet_tip_administrare = numecomplet_tip_administrare + ckb_Oral.Text + ";";
                    }
                    Medicament med = new Medicament();
                    med.IdMedicament = int.Parse(lblidmed.Text);
                    med.EditareNume(nume);
                    med.TipAdministrare = numecomplet_tip_administrare;
                    med.Pret = PRET;
                    med.DataExpirarii = EXPIRARE;
                    //Medicament med = new Medicament(nume, numecomplet_tip_administrare, PRET, EXPIRARE);
                    prospect? categorie_checked = categorie_varsta_selectata();
                    med.varsta_administrare = categorie_checked.Value;
                    bool updateResult = adminfarmacie.UpdateMedicament(med);
                    if (updateResult)
                    {
                        medicamente=adminfarmacie.GetMedicamente();
                        
                    }

                    //ResetareControale();
                }
                else
                {
                    MessageBox.Show("Date invalide !!! Verificati daca datele sunt valide !!!", "Formular editare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }


            AdaugareInComboBoxId();
            AdaugareInComoboBoxNume();
            

        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            string format_valid_operatii = "";
            int numar_invalidari_cautare = 0;
            int Id;
            int nume;

            bool validare_id = int.TryParse(comboBoxId.Text,out Id);
            bool validare_spatii_id = string.IsNullOrWhiteSpace(comboBoxId.Text);

            if (!validare_id || comboBoxId.Text == "" || validare_spatii_id==true || comboBoxId.Text == "Introudceti un Id")
            {
                format_valid_operatii = format_valid_operatii + "Format invalid Id\n";
                numar_invalidari_cautare++;
            }
                

            bool validare_nume = int.TryParse(comboBoxNume.Text,out nume);
            bool validare_spatii_nume = string.IsNullOrWhiteSpace(comboBoxNume.Text);

            if (validare_nume || comboBoxNume.Text=="" || validare_spatii_nume || comboBoxNume.Text=="Introduceti un Nume")
            {
                format_valid_operatii = format_valid_operatii + "Format invalid Nume\n";
                numar_invalidari_cautare++;
            }

            if (numarare_invalidari != 0)
            {
                MessageBox.Show(format_valid_operatii, "Formular cautare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Format valid", "Formular cautare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Medicament cautat = adminfarmacie.GetMedicament(Id, comboBoxNume.Text.ToString());
                if (cautat == null)
                {
                    MessageBox.Show("Medicamentul cautat nu a fost gasit", "Formular cautare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lblidmed.Text = cautat.IdMedicament.ToString();
                    //ResetareControaleCautare();
                    MessageBox.Show("Medicamentul cautat a fost gasit", "Formular cautare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Datele medicamentului cautat au fost transmise in formularul pentru editare pentru a edita medicamentul.", "Formular editare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNume.Text = cautat.ReturnareNumeMedicament.ToString();
                    txtPret.Text=cautat.Pret.ToString();
                    txtDataexpirare.Text = cautat.DataExpirarii.ToString();
                    int categorie_selectata = Convert.ToInt32(cautat.varsta_administrare);
                    if(categorie_selectata==1)
                    {
                        rdbCopil.Checked =true;
                    }
                    if(categorie_selectata==2)
                    {
                        rdbAdult.Checked = true;
                    }
                    if(categorie_selectata==3)
                    {
                        rdbBatran.Checked = true;
                    }

                    int nr_tipuri_selectate;
                    string tipuri_afisate_in_fisier = cautat.TipAdministrare;
                    string[] spargere_tip_administrare = tipuri_afisate_in_fisier.Split(';');
                    
                    nr_tipuri_selectate = spargere_tip_administrare.Length;
                    
                    
                    if (nr_tipuri_selectate==2)
                    {
                        if(spargere_tip_administrare[0]=="orala")
                        {
                            ckb_Oral.Checked = true;
                        }
                        if(spargere_tip_administrare[0]=="auricular")
                        {
                            ckbauricular.Checked = true;
                        }
                        if (spargere_tip_administrare[0] == "intrarectal")
                        {
                            ckbIntraRectal.Checked = true;
                        }
                        if (spargere_tip_administrare[0] == "bucal")
                        {
                            ckbbucal.Checked = true;
                        }
                        if(spargere_tip_administrare[0]=="sublingual")
                        {
                            ckbsublingual.Checked = true;
                        }
                        if (spargere_tip_administrare[0] == "ocular")
                        {
                            ckbocular.Checked = true;
                        }
                    }
                    else
                    {
                        if (spargere_tip_administrare[0] == "orala" || spargere_tip_administrare[1] == "orala")
                        {
                            ckb_Oral.Checked = true;
                        }
                        if (spargere_tip_administrare[0] == "auricular" || spargere_tip_administrare[1] == "auricular")
                        {
                            ckbauricular.Checked = true;
                        }
                        if (spargere_tip_administrare[0] == "intrarectal" || spargere_tip_administrare[1] == "intrarectal")
                        {
                            ckbIntraRectal.Checked = true;
                        }
                        if (spargere_tip_administrare[0] == "bucal" || spargere_tip_administrare[1] == "bucal")
                        {
                            ckbbucal.Checked = true;
                        }
                        if (spargere_tip_administrare[0] == "sublingual" || spargere_tip_administrare[1] == "sublingual")
                        {
                            ckbsublingual.Checked = true;
                        }
                        if (spargere_tip_administrare[0] == "ocular" || spargere_tip_administrare[1] == "ocular")
                        {
                            ckbocular.Checked = true;
                        }
                    }

                }
            }
       
        }

       private void ResetareControaleCautare()
       {
            comboBoxId.Text = "Introudceti un Id";
            comboBoxNume.Text = "Introduceti un Nume";
       }

        private void comboBoxId_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxId.Text = "";
        }

        private void comboBoxNume_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxNume.Text = "";
        }

        private void lbllistamedicamente_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelAfisare_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
