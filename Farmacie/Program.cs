using LibrarieModele;
using NivelAccesDate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacie
{
    /// INCA NU ESTE GATA PROGRAMUL 

    class Program
    {
        private const string  CHOICE_INCORRECT= "Operatie inexistenta"; 
        static void Main(string[] args)
        {
            
            string operatie;
            int op;
            bool operatievalida;
            ///lista de medicamente
            List<Medicament> Catena = new List<Medicament>();

            
            DateTime datasiorapentruafisareecran = DateTime.Now;

            IStocareData adminfarmacie = StocareFactory.GetAdministratorStocare();

            Catena = adminfarmacie.GetMedicamente();


            Console.Write(datasiorapentruafisareecran);
            do
            {
                Console.WriteLine("\n\n\n\t\t\t\t\tGestiunea unei farmacii.");
                Console.WriteLine("\n\n\n1.Adaugare medicament.");
                Console.WriteLine("2.Editare medicament.");
                Console.WriteLine("3.Stergere medicament.");
                Console.WriteLine("4.Afisare lista medicamente.");
                Console.WriteLine("5.Cautare medicament");
                Console.WriteLine("6.Iesire.");
                Console.WriteLine("7.Comparare medicamente dupa pret.");
                Console.Write("\nAlegeti o optiune: ");
                operatie = Console.ReadLine();
                operatievalida = int.TryParse(operatie, out op);

                switch (op)
                {
                    case 1:
                        Console.WriteLine("\n---------------Introdu datele despre medicament---------------\n");
                        Medicament medicament1 = CitireMedicamentdelatastatura();
                        Catena.Add(medicament1);
                        adminfarmacie.AddMedicament(medicament1);
                        Console.WriteLine("Medicamentul a fost adaugat.");
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        string editare_numemedicament;
                        string editare_tip_administrare_medicament;
                        float editare_pret_medicament;
                        DateTime editare_datasitime_medicament;
                        bool validare_editare_pret_medicament=false;
                        bool validare_operatie = false;
                        bool editare_cu_succes=false;
                        int operatie_editare;
                        bool validare_editare_data_medicament;
                        int editare_categorie_varsta;
                        Console.Write("\nIntroduceti numele medicamentului cautat pentru modificare: ");
                        string nume_modificare = Console.ReadLine();

                        Console.Write("\nIntroduceti tipul de administrare al medicamentului cautat: ");
                        string tip_administrare_modificare = Console.ReadLine();

                        Medicament medicament_pentru_modificare = adminfarmacie.GetMedicament(nume_modificare,tip_administrare_modificare);

                        if(medicament_pentru_modificare==null)
                        {
                            Console.WriteLine("Medicament inexistent.");
                        }
                        else
                        {
                            
                            Console.Clear();
                            Console.WriteLine("A fost gasit medicamentul cautat pentru modificare.");
                            do
                            {
                                
                                Console.WriteLine("\n--------Date despre medicament----------");
                                Console.WriteLine(medicament_pentru_modificare.ConversieLaSir());
                                Console.WriteLine("\n\nOptiuni pentru modificare");
                                Console.WriteLine("1.Nume medicament.");
                                Console.WriteLine("2.Tip administrare medicament.");
                                Console.WriteLine("3.Pret medicament.");
                                Console.WriteLine("4.Data expirarii.");
                                Console.WriteLine("5.Categorie de varsta.");
                                Console.Write("Introduceti un numar in functie de operatia dorita: ");
                                validare_operatie = Int32.TryParse(Console.ReadLine(), out operatie_editare);
                                if(!validare_operatie || (operatie_editare!=1 && operatie_editare!=2 && operatie_editare!=3 && operatie_editare != 4 && operatie_editare != 5))
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n"+CHOICE_INCORRECT);
                                    validare_operatie = false;
                                }
                                
                            } while (!validare_operatie);
                            
                            do
                            {
                                
                                switch (operatie_editare)
                                {
                                    case 1:
                                        Console.Write("\nIntroduceti modificarea dorita: ");
                                        editare_numemedicament = Console.ReadLine();
                                        medicament_pentru_modificare.EditareNume(editare_numemedicament);
                                        editare_cu_succes = true;
                                        break;
                                    case 2:
                                        Console.Write("\nIntroduceti modificarea dorita: ");
                                        editare_tip_administrare_medicament = Console.ReadLine();
                                        medicament_pentru_modificare.EditreTipAdministrare(editare_tip_administrare_medicament);
                                        editare_cu_succes = true;
                                        break;
                                    case 3:
                                        Console.Write("\nIntroduceti modificarea dorita: ");
                                        validare_editare_pret_medicament = float.TryParse(Console.ReadLine(), out editare_pret_medicament);
                                        if (validare_editare_pret_medicament)
                                        {
                                            medicament_pentru_modificare.EditarePret(editare_pret_medicament);
                                            editare_cu_succes = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Date invalide");
                                            editare_cu_succes = false;
                                        }
                                        break;
                                    case 4:
                                        Console.Write("\nIntroduceti modificarea dorita: ");
                                        /// Console.Write("Data expirarii medicamentului introdus in format zi/luna/an (ex format:  " + datasiorapentruafisareecran.ToString("d") + ")");
                                        validare_editare_data_medicament = DateTime.TryParse(Console.ReadLine(), out editare_datasitime_medicament);
                                        if (validare_editare_data_medicament)
                                        {
                                            medicament_pentru_modificare.EditareDataExpirare(editare_datasitime_medicament);
                                            editare_cu_succes = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nATENTIE !!!!! FORMATUL INTRODUS  NU ESTE VALID sau luna ziua si anul nu exista in calendar");
                                            Console.WriteLine("Introduceti un format corect.\n\n");
                                           
                                        }
                                        break;
                                    case 5:
                                        Console.WriteLine("\nCategorie de varsta");
                                        Console.WriteLine("1.Copil (0-18):");
                                        Console.WriteLine("2.Adult (18-60)");
                                        Console.WriteLine("3.Batran (60+)");
                                        Console.Write("\nIntroduceti modificarea dorita: ");
                                        bool validare_editare_categorie_varsta = int.TryParse(Console.ReadLine(),out editare_categorie_varsta);
                                        if (validare_editare_categorie_varsta) { 
                                            medicament_pentru_modificare.varsta_administrare = (prospect)editare_categorie_varsta;
                                            editare_cu_succes = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("A aparut o eroare.");
                                        }
                                        break;
                                }
                            } while (!editare_cu_succes);
                            Console.WriteLine("\nMedicamentul a fost editat cu succes.");

                            bool updateResult = adminfarmacie.UpdateMedicament(medicament_pentru_modificare);
                            if(updateResult)
                            {
                                Catena = adminfarmacie.GetMedicamente();
                            }
                        }

                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case 3:
                        string n;
                        bool win = false;
                        Console.Write("\nIntroduceti numele medicamentului pe care doriti sa il stergeti: ");
                        n = Console.ReadLine();
                        foreach (var ob in Catena)
                        {
                            if (n.Equals(ob.ReturnareNumeMedicament))
                            {
                                win = true;
                                Console.WriteLine("\n Medicamentul a fost gasit");
                                Console.WriteLine("\n---------------Date despre medicament---------------");
                                Console.WriteLine("\n\n" + ob.ConversieLaSir());
                                Console.WriteLine("\n\nMedicamentul a fost sters.");
                                Catena.Remove(ob);
                                break;
                            }
                        }
                        if (win == false)
                        {
                            Console.WriteLine("\nMedicamentul nu exista in farmacie.");
                        }
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        if (Catena.Count == 0)
                        {
                            Console.WriteLine("\nFarmacia nu dispune de nici un medicament");
                        }
                        else
                        {
                            foreach (var medicam in Catena)
                            {
                                Console.WriteLine("\n" + medicam.ConversieLaSir());
                            }
                        }
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        if (Catena.Count == 0)
                        {
                            Console.WriteLine("\n\nNu exista medicamente");
                        }
                        else
                        {
                            string med;
                            string tip_med;
                            
                            Console.Write("\nIntroduceti numele medicamentului pe care il cautati: ");
                            med = Console.ReadLine();
                            Console.Write("\nIntroduceti tipul de administrare al medicamentului cautat: ");
                            tip_med = Console.ReadLine();
                            Medicament medicamentcautat = adminfarmacie.GetMedicament(med,tip_med);

                            if (medicamentcautat == null)
                            {
                                Console.WriteLine(" MEDICAMENT INEXISTENT ");
                            }
                            else
                            {
                                Console.WriteLine($"Am gasit medicamentul cautat \n----Date despre medicament----\n\n{medicamentcautat.ConversieLaSir()}");
                            }

                        }
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        ///Console.WriteLine(a.Compare(a,b));
                        break;
                    default:
                        Console.Write("\n"+CHOICE_INCORRECT);
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }

            } while (op != 6);
        }
        public static Medicament CitireMedicamentdelatastatura()
        {
            string numemed;
            string tipadministrare;
            float pretmedicament;
            bool validarepret;
            DateTime data_utilizare_program = DateTime.Today;
            DateTime data;

            bool validare_data_medicament;




            Console.Write("Nume medicament: ");
            numemed = Console.ReadLine();
            Console.Write("Tip de administrare: ");
            tipadministrare = Console.ReadLine();
            do
            {
                Console.Write("Pret medicament: ");
                validarepret = float.TryParse(Console.ReadLine(), out pretmedicament);
                if (!validarepret)
                {
                    Console.WriteLine("\nATENTIE !!!!! PRETUL NU ESTE VALID");
                    Console.WriteLine("Introduceti o valoare numerica pentru pretul medicamentului.\n\n");
                }
            } while (!validarepret);
            do
            {
                Console.Write("Data expirarii medicamentului introdus in format zi/luna/an (ex format:  " + data_utilizare_program.ToString("d") + "): ");
                validare_data_medicament = DateTime.TryParse(Console.ReadLine(), out data);
                if (!validare_data_medicament)
                {
                    Console.WriteLine("\nATENTIE !!!!! FORMATUL INTRODUS  NU ESTE VALID sau luna ziua si anul nu exista in calendar");
                    Console.WriteLine("Introduceti un format corect.\n\n");
                }
            } while (!validare_data_medicament);

            Medicament m = new Medicament(numemed,tipadministrare,pretmedicament,data);
            
            Console.WriteLine("Categorie de varsta");
            Console.WriteLine("1.Copil (0-18):");
            Console.WriteLine("2.Adult (18-60)");
            Console.WriteLine("3.Batran (60+)");
            Console.Write("Introduceti categoria de varsta: ");
            int categorie_varsta = Int32.Parse(Console.ReadLine());
            m.varsta_administrare = (prospect)categorie_varsta;


            return m;


        }
    }

}
