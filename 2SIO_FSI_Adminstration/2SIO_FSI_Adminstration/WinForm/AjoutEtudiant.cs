using _2SIO_FSI_Adminstration.Classe.DAO;
using _2SIO_FSI_Adminstration.Classe.BO;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2SIO_FSI_Adminstration.WinForm
{
    public partial class AjoutEtudiant : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public AjoutEtudiant()
        {
            InitializeComponent();
            
        }

      

        private void ReInitialisation()
        {
            tbAENom.Text = string.Empty;
            tbAEPrenom.Text = string.Empty;
        }

        private void bouton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void AjoutEtudiant_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AjoutEtudiant_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void enregistrerbutton_Click(object sender, EventArgs e)
        {
            string nom = tbAENom.Text;
            string prenom = tbAEPrenom.Text;
            int idSection = cbClasse.SelectedIndex + 1;

            try
            {
                using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "INSERT INTO etudiant (nomEtudiant, prenometudiant, idSection) VALUES (@nom, @prenom, @section);";
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nom", nom);
                        command.Parameters.AddWithValue("@prenom", prenom);
                        command.Parameters.AddWithValue("@section", idSection);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Etudiant ajouté");
                        ReInitialisation();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}");
            }
        }

        private void effacerbutton_Click(object sender, EventArgs e)
        {
            ReInitialisation();
        }

        private void retourbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbClasse_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                SectionDAO sectionDAO = new SectionDAO(connectionString);
                List<Section> sections = sectionDAO.ReadAll();
                cbClasse.Items.Clear();

                foreach (Section section in sections)
                {
                    cbClasse.Items.Add(section.LilbelleSection);
                }

                if (cbClasse.Items.Count > 0)
                {
                    cbClasse.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des sections : {ex.Message}");
            }
        }

    }
}