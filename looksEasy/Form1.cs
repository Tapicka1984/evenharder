using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace looksEasy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            try
            {
                if (textBox1.Text != String.Empty)
                {
                    int cislo = int.Parse(textBox1.Text);
                    if (cislo > 20)
                    {
                        MessageBox.Show("cislo too big");
                    }
                    else
                    {
                        Random r = new Random();
                        int[] cisla = new int[cislo];
                        int x = 0;
                        while (x < cislo)
                        {
                            cisla[x] = r.Next(-1, 25);
                            x++;
                        }
                        foreach (int i in cisla)
                        {
                            listBox1.Items.Add(i);
                        }
                        PoslPrvočíslo(cisla);
                        Vymen(cisla, cislo);
                        Vypis(cisla);
                    }
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void PoslPrvočíslo(int[] cisla)
        {
            int posledniprvocislo = 0;
            int pozice = 1;
            int poziceposledniho = 0;
            foreach (int cislo in cisla)
            {
                if (cislo < 2)
                {
                    continue;
                }

                bool jePrvocislo = true;

                for (int i = 2; i * i <= cislo; i++)
                {
                    if (cislo % i == 0)
                    {
                        jePrvocislo = false;
                        break; 
                    }
                }

                if (jePrvocislo == true)
                {
                    posledniprvocislo = cislo;
                    poziceposledniho = pozice;
                }
                pozice++;
            }
            if (posledniprvocislo == 0)
            {
                MessageBox.Show("pole neobsahuje prvocisla");
            }
            else
            {
                MessageBox.Show("posledni prvocislo je: " + posledniprvocislo + ", jeho pozice je: " + poziceposledniho);
            }
        }

        private void Vymen(int[] cisla, int cislo)
        {
            int prvni = cisla[0];
            int posledni = cisla[cislo - 1];
            cisla[0] = posledni;
            cisla[cislo - 1] = prvni;
        }

        private void Vypis(int[] cisla)
        {
            foreach(int i in cisla)
            {
                listBox2.Items.Add(i);
            }
        }
            
    }
}
