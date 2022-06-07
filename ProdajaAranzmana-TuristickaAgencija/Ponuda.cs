using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdajaAranzmana_TuristickaAgencija
{
    public enum Tip {
        Letovanje=0, Zimovanje=1, Izlet=2, Proputovanje=3
    }
    enum TipPrevoza { 
        Avion, Autobus, SopstveniPrevoz
    }


    internal class Ponuda
    {
        public int Id { get; set; }
        public string Drzava { get; set; }
        public string Destinacija { get; set; }
        public double Cena { get; set; }
        public string Datum { get; set; }
        public int BrojNocenja { get; set; }
        public int BrojOsoba { get; set; }
        public string TipPrevoza { get; set; }
        public string Tip { get; set; }
        public string NazivHotela { get; set; }

        public Ponuda()
        {
            this.Id = 0;
            this.Drzava = "";
            this.Destinacija = "";
            this.Cena = 0.0;
            this.Datum = "";
            this.BrojNocenja = 0;
            this.Tip = "";
            this.NazivHotela = "";
            this.BrojOsoba = 0;
            this.TipPrevoza = "";
        }

        public Ponuda(int id,string drzava, string destinacija, double cena, string datum, int brojNocenja, string tip, string nazivHotela, int brojOsoba, string tipPrevoza)
        {
            Id = id;
            Drzava = drzava;
            Destinacija = destinacija;
            Cena = cena;
            Datum = datum;
            BrojNocenja = brojNocenja;
            Tip = tip;
            NazivHotela = nazivHotela;
            TipPrevoza = tipPrevoza;
            Drzava = drzava;
            Destinacija = destinacija;
            Cena = cena;
            BrojNocenja = brojNocenja;
            TipPrevoza = tipPrevoza;
            Tip = tip;
            NazivHotela = nazivHotela;
            BrojOsoba = brojOsoba;
        }

        public static void writeTextFile(Ponuda[] ponude, int n)
        {
            string data = "";
            for (int i = 0; i < n; i++)
            {
                data += ponude[i].Drzava + "|" +
                        ponude[i].Destinacija + "|" +
                        ponude[i].Cena.ToString() + "|" +
                        ponude[i].Datum + "|" +
                        ponude[i].BrojNocenja.ToString() + "|" +
                        ponude[i].TipPrevoza + "|" + ponude[i].Tip + "|" +
                        ponude[i].BrojOsoba.ToString() + "|" +
                        ponude[i].NazivHotela + "|" + "\n";
            }
            File.WriteAllText("podaci.txt", data);
        }

        public static int LoadPonudeData(TextReader reader, DataGridView dataGridView1, Ponuda[] ponude)
        {
            int n = 0;
            int id = 0;
            string? line;  // moze da bude 'null'
            dataGridView1.Rows.Clear();
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Trim().Split('|');

                ponude[n] = new Ponuda(
                    id,
                    items[0],
                    items[1],
                    Convert.ToDouble(items[2]),
                    items[3],
                    Convert.ToInt32(items[4]),
                    items[5],
                    items[6],
                    Convert.ToInt32(items[7]),
                    items[8]
                );
                string[] withId = items;
                withId[withId.Length - 1] = id.ToString();
                dataGridView1.Rows.Add(withId);
                id++;
                n++;
            }
            reader.Close();

            return n;
        }

        public static int LoadPonudeData(TextReader reader, Ponuda[] ponude)
        {
            int n = 0;
            int id = 0;
            string? line;  // moze da bude 'null'
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Trim().Split('|');

                ponude[n] = new Ponuda(
                    id,
                    items[0],
                    items[1],
                    Convert.ToDouble(items[2]),
                    items[3],
                    Convert.ToInt32(items[4]),
                    items[5],
                    items[6],
                    Convert.ToInt32(items[7]),
                    items[8]
                );
                string[] withId = items;
                withId[withId.Length - 1] = id.ToString();
                id++;
                n++;
            }
            reader.Close();

            return n;
        }

        public static int LoadPonudeData(TextReader reader, Ponuda[] ponude, double cena)
        {
            int n = 0;
            int id = 0;
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Trim().Split('|');
                if (Convert.ToDouble(items[2]) < cena)
                {
                    ponude[n] = new Ponuda(
                        id,
                        items[0],
                        items[1],
                        Convert.ToDouble(items[2]),
                        items[3],
                        Convert.ToInt32(items[4]),
                        items[5],
                        items[6],
                        Convert.ToInt32(items[7]),
                        items[8]
                    );
                    string[] withId = items;
                    withId[withId.Length - 1] = id.ToString();
                    id++;
                    n++;
                }
            }
            reader.Close();

            return n;
        }

        public static void SortPoTipu(DataGridView dataGridView1, Ponuda[] ponude, string tip)
        {
            int n = 0;
            int id = 0;
            string? line;
            dataGridView1.Rows.Clear();
            TextReader reader = File.OpenText("podaci.txt");
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Trim().Split('|');

                if (items.Contains(tip))
                {
                    ponude[n] = new Ponuda(
                        id,
                        items[0],
                        items[1],
                        Convert.ToDouble(items[2]),
                        items[3],
                        Convert.ToInt32(items[4]),
                        items[5],
                        items[6],
                        Convert.ToInt32(items[7]),
                        items[8]
                    );
                    string[] withId = items;
                    withId[withId.Length - 1] = id.ToString();
                    dataGridView1.Rows.Add(withId);
                    id++;
                    n++;
                }
            }
            reader.Close();
        }

        public static void SortPoBrOsoba(DataGridView dataGridView1, Ponuda[] ponude, int brOsoba)
        {
            int n = 0;
            int id = 0;
            string? line;
            dataGridView1.Rows.Clear();
            TextReader reader = File.OpenText("podaci.txt");
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Trim().Split('|');

                if (Convert.ToInt32(items[7]) == brOsoba)
                {
                    ponude[n] = new Ponuda(
                        id,
                        items[0],
                        items[1],
                        Convert.ToDouble(items[2]),
                        items[3],
                        Convert.ToInt32(items[4]),
                        items[5],
                        items[6],
                        Convert.ToInt32(items[7]),
                        items[8]
                    );
                    string[] withId = items;
                    withId[withId.Length - 1] = id.ToString();
                    dataGridView1.Rows.Add(withId);
                    id++;
                    n++;
                }
            }
            reader.Close();
        }

        public static void SortPoCeni(DataGridView dataGridView1, TextReader reader, double cena)
        {
            Ponuda[] ponude = new Ponuda[100];
            int n = 0;
            n = Ponuda.LoadPonudeData(reader, ponude, cena);

            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; ++j)
                {
                    if (ponude[i].Cena < ponude[j].Cena)
                    {
                        Ponuda pom;
                        pom = ponude[i];
                        ponude[i] = ponude[j];
                        ponude[j] = pom;
                    }

                }

            dataGridView1.Rows.Clear();
            for (int i = 0; i < n; i++) 
            {
                string[] data = new string[10];
                data[0] = ponude[i].Drzava;
                data[1] = ponude[i].Destinacija;
                data[2] = ponude[i].Cena.ToString();
                data[3] = ponude[i].Datum;
                data[4] = ponude[i].BrojNocenja.ToString();
                data[5] = ponude[i].NazivHotela;
                data[6] = ponude[i].TipPrevoza;
                data[7] = ponude[i].BrojOsoba.ToString();
                data[8] = ponude[i].Tip;
                data[9] = i.ToString();

                dataGridView1.Rows.Add(data);
            }
        }
    }
}
