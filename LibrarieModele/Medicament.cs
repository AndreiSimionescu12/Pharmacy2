using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Medicament
    {
        private string NumeMedicament;

        public int IdMedicament { get; set;}
        public static int IdUltimMedicament { get; set; } = 0;
        public string ReturnareNumeMedicament
        {
            get
            {
                return NumeMedicament;
            }
        }

        public float Pret
        {
            get;
            set;
        }

        public float ReturnarePret
        {
            get
            {
                return Pret;
            }
        }

        public string TipAdministrare
        {
            get;
            set;
        }

        public DateTime DataExpirarii
        {
            get;
            set;
        }

        public prospect varsta_administrare { get; set;}

        public Medicament()
        {
            this.NumeMedicament = string.Empty;
            this.TipAdministrare = string.Empty;
            this.Pret = 0;
            this.DataExpirarii = DateTime.Today;
            //IdUltimMedicament++;
            //IdMedicament = IdUltimMedicament;

        }
        public Medicament(string sirdate)
        {
            char[] delimitatori = { ',' };
            string[] datemedicamente = sirdate.Split(delimitatori);
            this.IdMedicament = Convert.ToInt32(datemedicamente[(int)campuri_medicamente.ID]);
            this.NumeMedicament = datemedicamente[(int)campuri_medicamente.NUME];
            this.TipAdministrare = datemedicamente[(int)campuri_medicamente.TIP_ADMINISTRARE];
            this.Pret = float.Parse(datemedicamente[(int)campuri_medicamente.PRET]);
            this.DataExpirarii = Convert.ToDateTime(datemedicamente[(int)campuri_medicamente.DATA_EXPIRARII]);
            varsta_administrare = (prospect)Convert.ToInt32(datemedicamente[(int)campuri_medicamente.VARSTA_ADMINISTRARE]);

            //IdUltimMedicament = IdMedicament;

        }

        public Medicament(string nume, string tip_administrare)
        {
            this.NumeMedicament = nume;
            this.TipAdministrare = tip_administrare;
            //IdUltimMedicament++;
            //IdMedicament = IdUltimMedicament;
        }
        public string ConversieLaSir()
        {
            return string.Format("Id medicament: {0} , Denumire medicament: {1} , tipul administrarii: {2} , pret: {3} , Data expirarii si ora expirarii: {4} , categorie administrare: {5}",IdMedicament, NumeMedicament, TipAdministrare, Pret, DataExpirarii, varsta_administrare);
        }

        public string Compare(Medicament a, Medicament b)
        {
            if (a.Pret > b.Pret)
            {
                return $"Medicamentul {a.NumeMedicament} are pretul mai mare decat medicamentul {b.NumeMedicament}";
            }
            else if (a.Pret < b.Pret)
            {
                return $"Medicamentul {b.NumeMedicament} are pretul mai mare decat medicamentul {a.NumeMedicament}";
            }
            else
            {
                return $"Medicamentul {b.NumeMedicament} si medicamentul {a.NumeMedicament} au preturi egale";
            }
        }

        public Medicament(string name, string type, float price, DateTime date)
        {
            IdUltimMedicament++;
            this.IdMedicament = IdUltimMedicament;
            NumeMedicament = name;
            TipAdministrare = type;
            Pret = price;
            DataExpirarii = Convert.ToDateTime(date);
            
        }

        public void EditareNume(string name)
        {
            NumeMedicament = name;
        }

        public void EditreTipAdministrare(string tip)
        {
            TipAdministrare = tip;
        }

        public void EditarePret(float pret)
        {
            this.Pret = pret;
        }

        public void EditareDataExpirare(DateTime data)
        {
            this.DataExpirarii = data;
        }

        public string ConversieLaSir_PentruScriereInFisier()
        {
            return $"{IdMedicament.ToString()},{NumeMedicament},{TipAdministrare},{Pret},{DataExpirarii},{(int)varsta_administrare}";

        }



    }
}
