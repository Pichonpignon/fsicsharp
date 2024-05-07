using _2SIO_FSI_Adminstration.Classe.BO;
using _2SIO_FSI_Adminstration.Classe.DAO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace _2SIO_FSI_Adminstration.WinForm
{
    public partial class ListeEtudiant : Form
    {
        private Utilisateur _utilisateur;

        public ListeEtudiant(Utilisateur utiConnecte)
        {
            InitializeComponent();
            _utilisateur = utiConnecte;
            ChargerEtudiants();
        }

        private void ChargerEtudiants()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Créer une instance de EtudiantDAO
            EtudiantDAO etudiantDAO = new EtudiantDAO(connectionString);

            // Appeler la méthode ReadAll() pour récupérer tous les étudiants
            List<Etudiant> mesEtudiants = etudiantDAO.ReadAll();

            dgvEtudiants.Rows.Clear();
            foreach (Etudiant etu in mesEtudiants)
            {
                dgvEtudiants.Rows.Add(etu.NomEtudiant, etu.PrenomEtudiant);
            }
        }


        private void bQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listeDesEtudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChargerEtudiants();
        }

        private void ajouterUnEtudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formAjouterEtudiant = new AjoutEtudiant();
            formAjouterEtudiant.Show();
        }

        private void accueilToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form formAccueil = new Accueil(_utilisateur);
            formAccueil.Show();
            this.Hide();
        }

        private void ListeEtudiant_Load(object sender, EventArgs e)
        {
            
        }

        private void ListeEtudiant_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }

        private void dgvEtudiants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}