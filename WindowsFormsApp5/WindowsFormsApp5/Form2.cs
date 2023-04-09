using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int tebak1 = 0;
        int tebak2 = 0;
        Button[,] urutanbutton;
        string[] keyboard = { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
        int cek;
        string iyakah = "";
        string isi;
        List<string> isiinputan = new List<string>();
        int apapun = 5;
        private void Form2_Load(object sender, EventArgs e)
        {
            int a = 10;
            int b = 10;
            cek = Form1.cekinput;
            urutanbutton = new Button[apapun,cek];
            for (int i = 0; i < apapun; i++)
            {
                for (int j = 0; j < cek; j++)
                {
                    urutanbutton[i, j] = new Button();
                    urutanbutton[i, j].Tag = i.ToString() + "," + j.ToString();
                    urutanbutton[i, j].Size = new Size(50, 50);
                    urutanbutton[i, j].Location = new Point(a, b);
                    this.Controls.Add(urutanbutton[i, j]);
                    b += 50;
                }
                b = 10;
                a += 50;
            }

            int kiri = 260;
            int atas = 40;

            foreach (string key in keyboard)
            {
                kiri += 40;
                if (key == "A")
                {
                    kiri = 320;
                    atas += 50;
                }
                else if (key == "Z")
                {
                    kiri = 360;
                    atas += 50;
                }

                Button button = new Button();
                button.Text = key;
                button.Location = new Point(kiri, atas);
                button.Width = 40;
                button.Height = 40;
                button.Click += button1_Click;
                this.Controls.Add(button);
            }

                Button delete = new Button();
                delete = new Button();
                delete.Text = "Delete";
                delete.Size = new Size(60, 40);
                delete.Location = new Point(640, 140);
                this.Controls.Add(delete);
                delete.Click += delete1_Click;

                Button enter = new Button();
                enter = new Button();
                enter.Text = "Enter";
                enter.Size = new Size(60, 40);
                enter.Location = new Point(300, 140);
                this.Controls.Add(enter);
                enter.Click += enter1_Click;
                
    
            string[] garis = File.ReadAllLines("Wordle Word List.txt");
            foreach (string word in garis)
            {
                isiinputan.AddRange(word.Split(','));
            }
            isi = isiinputan[new Random().Next(0, isiinputan.Count - 1)].ToUpper();
            MessageBox.Show(isi);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var key = sender as Button;
            if (tebak1 < 5)
            {
                urutanbutton[tebak1, tebak2].Text = key.Text;
                tebak1++;
            }
        }
        private void delete1_Click(object sender, EventArgs e)
        {
            if (tebak1 > 0)
            {
                tebak1--;
                urutanbutton[tebak1, tebak2].Text = "";
            }
        }
        private void enter1_Click(object sender, EventArgs e)
        {
            int green = 0;
            int yellow = 0;
            if (tebak1 != 5)
            {
                MessageBox.Show("harus isi satu baris baru bisa enter", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int l = 0; l < apapun; l++)
                {
                    iyakah += urutanbutton[l, tebak2].Text;
                }
                if (isiinputan.Contains(iyakah.ToLower()))
                {
                    foreach (char iyakah in isi)
                    {
                        for (int l = 0; l < apapun; l++)
                        {
                            if (urutanbutton[l, tebak2].Text == iyakah.ToString())
                            {
                                green++;
                                urutanbutton[l, tebak2].BackColor = Color.Green;
                            }
                            if (urutanbutton[l, tebak2].Text.Contains(iyakah.ToString()) && urutanbutton[l, tebak2].Text != isi[l].ToString())
                            {
                                urutanbutton[l, tebak2].BackColor = Color.Yellow;
                            }
                        }
                    }
                    tebak1 = 0;
                    tebak2++;
                    iyakah = "";
                    if (green == 5)
                    {
                        MessageBox.Show("menang ws!!!", "", MessageBoxButtons.OK);
                    }
                    else if (tebak2 == cek && green < 5)
                    {
                        MessageBox.Show("kalah ws");
                    }


                }
                else
                {
                    MessageBox.Show("Kata tidak ada dalam wordle word list", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iyakah = "";
                }
            }
        }
        
    }
}