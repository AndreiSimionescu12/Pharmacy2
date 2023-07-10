using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddMedicament(Medicament f);
        List<Medicament> GetMedicamente();
        Medicament GetMedicament(string numemed, string tip_administrare_med);
        bool UpdateMedicament(Medicament m);

        Medicament GetMedicament(int Id, string Nume);

    }
}
