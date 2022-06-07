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
    public partial class UnosNovogAranzmana : Form
    {
        public UnosNovogAranzmana()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
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
                string drzava = textBox1.Text;
                string destinacija = textBox2.Text;
                double cena = Convert.ToDouble(textBox5.Text);
                string datum = textBox3.Text;
                int brojNocenja = Convert.ToInt32(numericUpDown2.Value);
                string tipPrevoza = comboBox1.Text;
                string tipAranzmana = comboBox2.Text;
                int brojOsoba = Convert.ToInt32(numericUpDown3.Value);
                string nazivHotela = textBox4.Text;

                string data = drzava + "|" + destinacija + "|" + cena.ToString() + "|" + datum + "|" + brojNocenja.ToString() + "|" + tipPrevoza + "|" + tipAranzmana + "|" + brojOsoba.ToString() + "|" + nazivHotela + "|" + "\n";
                
                File.AppendAllText("podaci.txt", data);

                this.Close();
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
            }
        }
    }
}
