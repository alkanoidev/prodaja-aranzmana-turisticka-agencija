using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProdajaAranzmana_TuristickaAgencija
{
    public partial class PretragaPoCeni : Form
    {
        public PretragaPoCeni()
        {
            InitializeComponent();
        }

        Ponuda[] ponude = new Ponuda[100];
        private static int n = 0;
        private void PretragaPoCeni_Load(object sender, EventArgs e)
        {
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextReader reader = File.OpenText("podaci.txt");
            double cena = Convert.ToDouble(textBox1.Text);
            Ponuda.SortPoCeni(dataGridView1, reader, cena);
        }
    }
}
