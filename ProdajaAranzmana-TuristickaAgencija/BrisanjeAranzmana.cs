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
    public partial class BrisanjeAranzmana : Form
    {
        public BrisanjeAranzmana()
        {
            InitializeComponent();
        }
        Ponuda[] ponude = new Ponuda[100];
        int n = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TextReader reader = File.OpenText("podaci.txt");
                n = Ponuda.LoadPonudeData(reader, ponude);

                int id1 = Convert.ToInt32(numericUpDown1.Value);
                if (id1 < 0)
                    throw new Exception("Id aranzmana mora biti veci ili jednak nuli!");
                if (id1 > n)
                    throw new Exception("Id je veci od ukupnog broja aranzmana!");

                ponude = ponude.Where((source, index) => index != id1).ToArray();
                n--;
                Ponuda.writeTextFile(ponude, n);

                this.Close();
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
            }
        }
    }
}
