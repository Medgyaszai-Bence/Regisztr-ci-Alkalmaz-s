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

       static string[] tomb = new string[5];

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

        }



        private void Mentes()
        {

           
            string tartalom1 = contentBox.Items.ToString();
            string tartalomNev = textBoxNev.Text;
            string tartalomDatum = textBoxDatum.Text;
            string tartalomNem = radioNem();
        
            tomb[0] = tartalom1.ToString();
            tomb[1] = tartalomNev.ToString();
            tomb[2] = tartalomDatum.ToString();
            tomb[3] = tartalomNem.ToString();
            tomb[4] = 

            saveFileDialog.FileName = "";
            var eredmeny = saveFileDialog.ShowDialog(this);
            if (eredmeny == DialogResult.OK)
            {
                string fileNev = saveFileDialog.FileName;
               
                File.WriteAllLines(fileNev, tomb);
            }

        }


        private void Megnyitas()
        {
            saveFileDialog.FileName = "";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                contentBox.Text = File.ReadAllText(saveFileDialog.FileName);
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
            

        }

    }
}
