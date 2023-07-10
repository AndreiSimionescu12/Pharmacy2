using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace NivelAccesDate
{
    public class AdministrareFisier_text : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareFisier_text(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();

            //liniile de mai sus pot fi inlocuite cu linia de cod urmatoare deoarece
            //instructiunea 'using' va apela sFisierText.Close();
            //using (Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate)) { }
        }
        public void AddMedicament(Medicament f)
        {
            //Medicament[] medicaments = new Medicament[PAS_ALOCARE];
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'true' al constructorului StreamWriter indica modul 'append' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(f.ConversieLaSir_PentruScriereInFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

        }

        public static List<Medicament> listaMedicamente()
        {
            List<Medicament> farmacie = new List<Medicament>();
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Medicamente.txt");
                string[] newLine = null;
                //Read the first line of text
                line = sr.ReadLine();


                //Continue to read until you reach end of file
                while (line != null)
                {
                    newLine = line.Split(' ');
                    farmacie.Add(new Medicament(newLine[0], newLine[1], Convert.ToInt32(newLine[2]), Convert.ToDateTime(newLine[3])));
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return farmacie;
        }

       

        public List<Medicament> GetMedicamente()
        {
            List<Medicament> medicamente=new List<Medicament>();

            try
            {
            
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        Medicament studentDinFisier = new Medicament(line);
                        medicamente.Add(studentDinFisier);
                        
                    }
                }
            
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            

            return medicamente;
        }

        public Medicament GetMedicament(string numemedicament, string tipadministrare)
        {
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Medicament medicament = new Medicament(line);
                        if (medicament.ReturnareNumeMedicament.Equals(numemedicament) && medicament.TipAdministrare.Equals(tipadministrare))
                            return medicament;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return null;
        }

        public Medicament GetMedicament(int Id, string Nume)
        {
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Medicament medicament = new Medicament(line);
                        if (medicament.IdMedicament==Id && medicament.ReturnareNumeMedicament.Equals(Nume))
                            return medicament;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return null;
        }
        public bool UpdateMedicament(Medicament medicamentactualizat)
        {
            List<Medicament> medicamente = GetMedicamente();
            bool actualizareCuSucces = false;
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'false' al constructorului StreamWriter indica modul 'overwrite' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, false))
                {
                    foreach (Medicament medicament in medicamente)
                    {
                        Medicament medicamentPentruScrisInFisier = medicament;
                        //informatiile despre studentul actualizat vor fi preluate din parametrul "studentActualizat"
                        if (medicament.IdMedicament == medicamentactualizat.IdMedicament)
                        {
                            medicamentPentruScrisInFisier = medicamentactualizat;
                        }
                        swFisierText.WriteLine(medicamentPentruScrisInFisier.ConversieLaSir_PentruScriereInFisier());
                    }
                    actualizareCuSucces = true;
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return actualizareCuSucces;
        }
    }
}
