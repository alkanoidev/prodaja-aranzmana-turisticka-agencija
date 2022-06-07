using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProdajaAranzmana_TuristickaAgencija
{
    public partial class Pocetna : Form
    {
        public Pocetna()
        {
            InitializeComponent();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Ponuda[] ponude = new Ponuda[100];
        private static int n = 0;
        private void Pocetna_Load(object sender, EventArgs e)
        {
            TextReader reader = File.OpenText("podaci.txt");

            // izgled dataGridView-a
            dataGridView1.Visible = true;
            dataGridView1.ColumnCount = 10;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = true;
            dataGridView1.RowHeadersVisible = false;

            // postavljanje naslova
            dataGridView1.Columns[0].HeaderText = "Drzava";
            dataGridView1.Columns[1].HeaderText = "Destinacija";
            dataGridView1.Columns[2].HeaderText = "Cena";
            dataGridView1.Columns[3].HeaderText = "Datum";
            dataGridView1.Columns[4].HeaderText = "Broj nocenja";
            dataGridView1.Columns[5].HeaderText = "Tip prevoza";
            dataGridView1.Columns[6].HeaderText = "Tip";
            dataGridView1.Columns[7].HeaderText = "Broj osoba";
            dataGridView1.Columns[8].HeaderText = "Naziv hotela";
            dataGridView1.Columns[9].HeaderText = "Id";

            // postavljanje tooltipova
            toolTip1.SetToolTip(this.menuStrip1, "Unos, izmena, brisanje, sortiranje ponuda");
            
            // postavljanje timera
            timer1.Interval = 1000;
            timer1.Start();

            Ponuda.LoadPonudeData(reader, dataGridView1, ponude);


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void unosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new UnosNovogAranzmana().Show();
        }

        private void Pocetna_Enter(object sender, EventArgs e)
        {
            TextReader reader = File.OpenText("podaci.txt");
            PopulateDataGridView(reader, dataGridView1, ponude);
        }
        private static void PopulateDataGridView(TextReader reader, DataGridView dataGridView1, Ponuda[] ponude)
        {
            n = Ponuda.LoadPonudeData(reader, dataGridView1, ponude);
        }

        private void izmenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IzmenaAranzmana().Show();
        }

        private void osveziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextReader reader = File.OpenText("podaci.txt");
            PopulateDataGridView(reader, dataGridView1, ponude);
        }

        private void brisanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BrisanjeAranzmana().Show();
        }

        private void letovanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ponuda.SortPoTipu(dataGridView1, ponude, "Letovanje");
        }

        private void zimovanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ponuda.SortPoTipu(dataGridView1, ponude, "Zimovanje");
        }

        private void izletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ponuda.SortPoTipu(dataGridView1, ponude, "Izlet");
        }

        private void proputovanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ponuda.SortPoTipu(dataGridView1, ponude, "Proputovanje");
        }

        private void sa4OsobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int brOsoba = 4;
            Ponuda.SortPoBrOsoba(dataGridView1, ponude, brOsoba);
        }

        private void saMaksimalnimBrOsobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            int id = 0;
            string? line;
            dataGridView1.Rows.Clear();
            TextReader reader = File.OpenText("podaci.txt");
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
            Ponuda ponudaSaMaxBrojOsoba = ponude[0];
            for (int i = 0; i < n; i++)
            {
                if (ponude[i].BrojOsoba > ponudaSaMaxBrojOsoba.BrojOsoba)
                {
                    ponudaSaMaxBrojOsoba = ponude[i];
                }
            }
            string[] items1 =
            {
                ponudaSaMaxBrojOsoba.Drzava,
                ponudaSaMaxBrojOsoba.Destinacija,
                ponudaSaMaxBrojOsoba.Cena.ToString(),
                ponudaSaMaxBrojOsoba.Datum,
                ponudaSaMaxBrojOsoba.BrojNocenja.ToString(),
                ponudaSaMaxBrojOsoba.TipPrevoza,
                ponudaSaMaxBrojOsoba.Tip,
                ponudaSaMaxBrojOsoba.BrojOsoba.ToString(),
                ponudaSaMaxBrojOsoba.NazivHotela,
                ponudaSaMaxBrojOsoba.Id.ToString()
            };
            dataGridView1.Rows.Add(items1);
        }

        private void saNajvecomCenomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            int id = 0;
            string? line;
            dataGridView1.Rows.Clear();
            TextReader reader = File.OpenText("podaci.txt");
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
            Ponuda ponudaSaNajvecomCenom = ponude[0];
            for (int i = 0; i < n; i++)
            {
                if (ponude[i].Cena > ponudaSaNajvecomCenom.Cena)
                {
                    ponudaSaNajvecomCenom = ponude[i];
                }
            }
            string[] items1 =
            {
                ponudaSaNajvecomCenom.Drzava,
                ponudaSaNajvecomCenom.Destinacija,
                ponudaSaNajvecomCenom.Cena.ToString(),
                ponudaSaNajvecomCenom.Datum,
                ponudaSaNajvecomCenom.BrojNocenja.ToString(),
                ponudaSaNajvecomCenom.TipPrevoza,
                ponudaSaNajvecomCenom.Tip,
                ponudaSaNajvecomCenom.BrojOsoba.ToString(),
                ponudaSaNajvecomCenom.NazivHotela,
                ponudaSaNajvecomCenom.Id.ToString()
            };
            dataGridView1.Rows.Add(items1);
        }

        private void poCeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PretragaPoCeni().Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                dataGridView1.BackgroundColor = colorDialog1.Color;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
    }
}
