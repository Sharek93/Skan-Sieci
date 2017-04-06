using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkanSieciLokalnej_v3
{
    public partial class Wybor_sieci : Form
    {
        string wybrana_siec = String.Empty;
        List<string> Lista = new List<string>();

        public Wybor_sieci()
        {
            InitializeComponent();
        }

        public string Wybrana_siec
        {
            get
            {
                return wybrana_siec;
            }
        }

        public void Wybierz_siec(List<string> ListaPodsieci)
        {
            listBox1.Items.Clear();
            Lista.Clear();
            Lista = ListaPodsieci;
            for (int i = 0; i < ListaPodsieci.Count; i++)
            {
                listBox1.Items.Add(Lista[i]); 
            }            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                wybrana_siec = listBox1.SelectedItem.ToString();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Musisz wybrać sieć", "Wybrierz sieć",MessageBoxButtons.OK);
            }            
        }

        private void SkanSieciLokalnej_v3_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (wybrana_siec == String.Empty)
            {
                MessageBox.Show("Musisz wybrać sieć", "Wybrierz sieć", MessageBoxButtons.OK);
                e.Cancel = true;
            }
        }
    }
}
