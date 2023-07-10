using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public enum prospect
    {
        COPIL=1,
        ADULT=2,
        BATRAN=3
    };

    public enum campuri_medicamente
    {
        ID=0,
        NUME=1,
        TIP_ADMINISTRARE=2,
        PRET=3,
        DATA_EXPIRARII=4,
        VARSTA_ADMINISTRARE=5
    }
}
