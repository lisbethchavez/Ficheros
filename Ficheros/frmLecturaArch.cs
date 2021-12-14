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

namespace Ficheros
{
    public partial class frmLecturaArch : Form
    {
        public frmLecturaArch()
        {
            InitializeComponent();
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            //apertura del archivo
            try
            {
                string file = this.txtArchivo.Text;

                FileStream archivo = new FileStream(file, FileMode.Open);
                StreamReader sr = new StreamReader(archivo);

                //lectura de la primera linea del archivo 
                string cad, aux = "";
                cad = sr.ReadLine();
                while (cad != null)
                {
                    aux += cad + Environment.NewLine;
                    cad = sr.ReadLine();
                }
                this.txtResultado.Text = aux;
                //cerrar flujo
                sr.Close();

            }catch(Exception e1)
            {
                MessageBox.Show(e1.Message.ToString());
            }            
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {

           

            openFileDialog1.Title = "Lectura de archivos de texto";
            openFileDialog1.InitialDirectory =@"c:\tmp";
            openFileDialog1.Filter = "txt files(*.txt)|*txt";
        
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {                

                btnAbrir.Text = openFileDialog1.FileName;
            }
            else
            {
                this.txtArchivo.Text = "";
            }
            
                

        }
    }
}
