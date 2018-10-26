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

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {

       static string[] tomb = new string[100];

        public Form1()
        {
            InitializeComponent();
         
            buttonSave.Click += (sender, e) =>
            {
                Mentes();
            };

            buttonOpen.Click += (sender, e) =>
            {
                Megnyitas();
            };

            buttonHozzaad.Click += (sender, e) =>
            {
                Hozzaad();
            };

        }



        private void Mentes()
        {
           
            string[] contentBoxTomb = new string[contentBox.Items.Count];
           
           


            string tartalom1 = "Kedvenc: " + contentBox.SelectedItem.ToString();
            string tartalomNev = textBoxNev.Text;
            string tartalomDatum = textBoxDatum.Text;
            string tartalomNem = radioNem();
           
            tomb[0] = tartalomNev.ToString();
            tomb[1] = tartalomDatum.ToString();
            tomb[2] = tartalomNem.ToString();
            tomb[3] = tartalom1;


            for (int i = 0; i < contentBoxTomb.Length; i++)
            {

                contentBoxTomb[i] = contentBox.Items[i].ToString();
                tomb[i+4] = contentBoxTomb[i];

            }


            saveFileDialog.FileName = "";
            var eredmeny = saveFileDialog.ShowDialog(this);
            if (eredmeny == DialogResult.OK)
            {
                string fileNev = saveFileDialog.FileName;
               
                File.WriteAllLines(fileNev, tomb);
                System.Windows.Forms.Application.Exit();
            }

        }


        private void Megnyitas()
        {          
            string[] beolvasottElemek = new string[tomb.Length];
            saveFileDialog.FileName = "";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {

                //contentBox.Text = File.ReadAllText(saveFileDialog.FileName);
                beolvasottElemek = File.ReadAllLines(openFileDialog.FileName);

                textBoxNev.Text = beolvasottElemek[0];
                textBoxDatum.Text = beolvasottElemek[1];
                if (beolvasottElemek[2] == "Férfi")
                {
                    radioButtonF.Checked = true;
                }
                else if(beolvasottElemek[2] == "Nő")
                {
                    radioButtonN.Checked = true;
                }
                //contentBox.Items = beolvasottElemek[3];

              /*  for (int i = 0; i < contentBox.Items.Count; i++)
                {
                    contentBox.Items.Add(beolvasottElemek[i + 4]);
                }
                */
                
                            
            }
        }

        private string radioNem()
        {
            if(radioButtonF.Checked == true)
            {
                return "Férfi";
            }else if(radioButtonN.Checked == true)
            {
                return "Nő";
            }
            else
            {
                return "Nem adott meg nemet";
            }
        }


        private void Hozzaad()
        {
            string hozzaad = textBoxHobbi.Text;
            contentBox.Items.Add(hozzaad);
            textBoxHobbi.Text = "";
            

        }

       
    }
}
