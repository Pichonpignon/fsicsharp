using _2SIO_FSI_Adminstration.Classe.BO;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2SIO_FSI_Adminstration.WinForm
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void bConnexion_Click(object sender, EventArgs e)
        {
            string loginUti = tbLogin.Text;
            string mdpUti = tbMdp.Text;

            using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
            {

                string select = "SELECT idUtilisateur, loginUtilisateur FROM utilisateur WHERE loginUtilisateur = @login AND mdpUtilisateur = @mdp;";
                using (NpgsqlCommand command = new NpgsqlCommand(select, connection))
                {
                    command.Parameters.AddWithValue("login", loginUti);
                    command.Parameters.AddWithValue("mdp", mdpUti);
                    using (NpgsqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int idUti = dr.GetInt32(0);
                            string loginUtiFromDb = dr.GetString(1);
                            Utilisateur uti = new Utilisateur(idUti, loginUtiFromDb);

                            this.Hide();
                            Form formAccueil = new Accueil(uti);
                            formAccueil.Show();
                        }
                        else
                        {
                            MessageBox.Show("Erreur d'authentification");
                            tbLogin.Text = "";
                            tbMdp.Text = "";
                        }
                    }
                }

                connection.Close(); 
            }
        }

        private void Connexion_Load(object sender, EventArgs e)
        {
           
        }

        private void Connexion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
