using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Zadatak2
{
    public partial class Glavna : Form
    {
        List<Polaznik> polaznici = new List<Polaznik>();
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                Polaznik polaznik = new Polaznik();
                polaznik.Ime = txtIme.Text;
                polaznik.Prezime = txtPrezime.Text;
                polaznik.Oib = txtOib.Text;
                bool ok = DateTime.TryParse(txtDatumUpisa.Text, out DateTime datum);
                if(ok)
                {
                    polaznik.DatumUpisa = datum;
                }
                ok = double.TryParse(txtDug.Text, out double dug);
                if (ok)
                {
                    polaznik.Dug = dug;
                }
                polaznici.Add(polaznik);
                AzurirajGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Pogreška: {ex.Message}");
            }

        }

        void AzurirajGrid()
        {
            dgvPolaznici.DataSource = null;
            dgvPolaznici.DataSource = polaznici;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("polaznici.txt");
            foreach (var polaznik in polaznici)
            {
                sw.WriteLine($"{polaznik.Ime};{polaznik.Prezime};{polaznik.Oib};{polaznik.DatumUpisa};{polaznik.Dug}");
            }
            sw.Close();
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            string[] redci = File.ReadAllLines("polaznici.txt");
            foreach (string r in redci)
            {
                string[] stupci = r.Split(';');
                Polaznik polaznik = new Polaznik();
                polaznik.Ime = stupci[0];
                polaznik.Prezime = stupci[1];
                polaznik.Oib = stupci[2];
                bool ok = DateTime.TryParse(stupci[3], out DateTime datum);
                if(ok) 
                    polaznik.DatumUpisa = datum;
                ok = double.TryParse(stupci[4], out double dug);
                if (ok)
                    polaznik.Dug = dug;
                polaznici.Add(polaznik);
            }
            AzurirajGrid();
        }
    }
}
