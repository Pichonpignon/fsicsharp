using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SIO_FSI_Adminstration.Classe.DAO
{
    using _2SIO_FSI_Adminstration.Classe.BO;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class UtilisateurDAO
    {
        private string connectionString;

        public UtilisateurDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Utilisateur utilisateur)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Utilisateur (IdUtilisateur, LoginUtilisateur, MdpUtilisateur) VALUES (@IdUtilisateur, @LoginUtilisateur, @MdpUtilisateur)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUtilisateur", utilisateur.IdUtilisateur);
                command.Parameters.AddWithValue("@LoginUtilisateur", utilisateur.LoginUtilisateur);
                command.Parameters.AddWithValue("@MdpUtilisateur", utilisateur.MdpUtilisateur);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Utilisateur Read(int idUtilisateur)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Utilisateur WHERE IdUtilisateur = @IdUtilisateur";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUtilisateur", idUtilisateur);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string login = reader.GetString(1);
                    string mdp = reader.GetString(2);

                    return new Utilisateur(id, login, mdp);
                }

                return null;
            }
        }

        public void Update(Utilisateur utilisateur)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Utilisateur SET LoginUtilisateur = @LoginUtilisateur, MdpUtilisateur = @MdpUtilisateur WHERE IdUtilisateur = @IdUtilisateur";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUtilisateur", utilisateur.IdUtilisateur);
                command.Parameters.AddWithValue("@LoginUtilisateur", utilisateur.LoginUtilisateur);
                command.Parameters.AddWithValue("@MdpUtilisateur", utilisateur.MdpUtilisateur);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void Delete(int idUtilisateur)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Utilisateur WHERE IdUtilisateur = @IdUtilisateur";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUtilisateur", idUtilisateur);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public List<Utilisateur> ReadAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Utilisateur";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string login = reader.GetString(1);
                    string mdp = reader.GetString(2);

                    Utilisateur utilisateur = new Utilisateur(id, login, mdp);
                    utilisateurs.Add(utilisateur);
                }
            }

            return utilisateurs;
        }
    }
}
