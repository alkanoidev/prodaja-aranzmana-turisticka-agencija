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
    public partial class IzmenaAranzmana : Form
    {
        public IzmenaAranzmana()
        {
            InitializeComponent();
        }
        Ponuda? ponudaEdit;
        Ponuda[] ponude = new Ponuda[100];
        int n = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TextReader reader = File.OpenText("podaci.txt");
                n = Ponuda.LoadPonudeData(reader, ponude);
                int id1 = Convert.ToInt32(numericUpDown4.Value);

                if (id1 < 0)
                    throw new Exception("Id aranzmana mora biti veci ili jednak nuli!");
                if(id1 > n)
                    throw new Exception("Id je veci od ukupnog broja aranzmana!");

                for (int i = 0; i < n; i++)
                    if (ponude[i].Id == id1)
                        ponudaEdit = ponude[i];

                textBox1.Text = ponudaEdit!.Drzava;
                textBox2.Text = ponudaEdit!.Destinacija;
                textBox5.Text = ponudaEdit!.Cena.ToString();
                textBox3.Text = ponudaEdit!.Datum;
                numericUpDown2.Value = (decimal) ponudaEdit!.BrojNocenja;
                comboBox1.Text = ponudaEdit!.TipPrevoza;
                comboBox2.Text = ponudaEdit!.Tip;
                numericUpDown3.Value = (decimal) ponudaEdit!.BrojOsoba;
                textBox4.Text = ponudaEdit!.NazivHotela;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ponudaEdit!.Drzava = textBox1.Text;
                ponudaEdit!.Destinacija = textBox2.Text;
                ponudaEdit!.Cena = Convert.ToDouble(textBox5.Text);
                ponudaEdit!.Datum = textBox3.Text;
                ponudaEdit!.BrojNocenja = (int)numericUpDown2.Value;
                ponudaEdit!.TipPrevoza = comboBox1.Text;
                ponudaEdit!.Tip = comboBox2.Text;
                ponudaEdit!.BrojOsoba = (int)numericUpDown3.Value;
                ponudaEdit!.NazivHotela = textBox4.Text;

                ponude[ponudaEdit.Id] = ponudaEdit;


                if (string.IsNullOrEmpty(textBox1.Text)
                    || string.IsNullOrEmpty(textBox2.Text)
                    || string.IsNullOrEmpty(textBox3.Text)
                    || string.IsNullOrEmpty(textBox4.Text)
                    || string.IsNullOrEmpty(textBox5.Text)
                    || string.IsNullOrEmpty(numericUpDown2.Value.ToString())
                    || string.IsNullOrEmpty(numericUpDown3.Value.ToString())
                    || string.IsNullOrEmpty(comboBox1.Text)
                    || string.IsNullOrEmpty(comboBox2.Text))
                {
                    throw new Exception("Sva polja moraju biti popunjena!");
                }

                Ponuda.writeTextFile(ponude, n);

                this.Close();
            }
            catch(Exception exc)
            {

                MessageBox.Show(exc.Message, "Error");
            }
        }
    }
}
