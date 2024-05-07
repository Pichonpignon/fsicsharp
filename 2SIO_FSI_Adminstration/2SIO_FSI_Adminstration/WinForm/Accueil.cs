using _2SIO_FSI_Adminstration.Classe.BO;
using _2SIO_FSI_Adminstration.WinForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2SIO_FSI_Adminstration
{
    public partial class Accueil : Form
    {
        private Utilisateur _utilisateur;

        public Accueil(Utilisateur utiConnecte)
        {
            InitializeComponent();
            _utilisateur = utiConnecte;
            tbUserConnecte.ReadOnly = true;
            tbUserConnecte.Enabled = false;
            tbUserConnecte.BackColor = Color.White;
            tbUserConnecte.ForeColor = Color.Green;
            tbUserConnecte.Text = _utilisateur.LoginUtilisateur;
        }

        private void bQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listeDesEtudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Form formListeEtudiant = new ListeEtudiant(_utilisateur);
            formListeEtudiant.FormClosed += (s, args) => this.Show(); 
            formListeEtudiant.Show();
        }

        private void ajouterUnEtudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Form formAjouterEtudiant = new AjoutEtudiant();
            formAjouterEtudiant.FormClosed += (s, args) => this.Show(); 
            formAjouterEtudiant.Show();
        }
        private void tbUserConnecte_TextChanged(object sender, EventArgs e)
        {

        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            
        }

        private void Accueil_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}