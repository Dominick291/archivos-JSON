using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace archivos_JSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> notasTemporales = new List<int>();
        List<NotasAlumno> listaNotas = new List<NotasAlumno>();
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            

            int nota = Convert.ToInt16(textBox2.Text);

            notasTemporales.Add(nota);
            MessageBox.Show("Nota guardada");
            textBox2.Text = "";



        }
        private void Grabar()
        {
            //Se serializa (convierte) la lista en formato Json y se guarda en una variable de tipo string
            string json = JsonConvert.SerializeObject(listaNotas);

            //El nombre del archivo
            string archivo = "Datos.json";

            //Se escribe la variable que contiene el json al archivo en un solo paso
            //con WriteAllText se escribe todo de un solo
            System.IO.File.WriteAllText(archivo, json);

        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            NotasAlumno notasAlumno = new NotasAlumno();
            notasAlumno.Nombres = textBox1.Text;
            notasAlumno.Notas = notasTemporales.GetRange(0,notasTemporales.Count);

            listaNotas.Add(notasAlumno);

            Grabar();
            MessageBox.Show("Datos Guardados");
            notasTemporales.Clear();
            textBox1.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
