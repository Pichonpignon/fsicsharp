using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using _2SIO_FSI_Adminstration.Classe.BO;

namespace _2SIO_FSI_Adminstration.Classe.DAO
{
    public class EtudiantDAO
    {
        private string connectionString;

        public EtudiantDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Etudiant etudiant)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO etudiant (IdEtudiant, NomEtudiant, PrenomEtudiant, IdSection) VALUES (@IdEtudiant, @NomEtudiant, @PrenomEtudiant, @IdSection)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEtudiant", etudiant.IdEtudiant);
                command.Parameters.AddWithValue("@NomEtudiant", etudiant.NomEtudiant);
                command.Parameters.AddWithValue("@PrenomEtudiant", etudiant.PrenomEtudiant);
                command.Parameters.AddWithValue("@IdSection", etudiant.SectionEtudiant.IdSection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Etudiant Read(int idEtudiant)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM etudiant WHERE IdEtudiant = @IdEtudiant";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEtudiant", idEtudiant);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nom = reader.GetString(1);
                    string prenom = reader.GetString(2);
                    int idSection = reader.GetInt32(3);

                    
                    SectionDAO sectionDAO = new SectionDAO(connectionString);
                    Section section = sectionDAO.Read(idSection);

                    return new Etudiant(id, nom, prenom, section);
                }

                return null;
            }
        }

        public void Update(Etudiant etudiant)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE etudiant SET NomEtudiant = @NomEtudiant, PrenomEtudiant = @PrenomEtudiant, IdSection = @IdSection WHERE IdEtudiant = @IdEtudiant";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEtudiant", etudiant.IdEtudiant);
                command.Parameters.AddWithValue("@NomEtudiant", etudiant.NomEtudiant);
                command.Parameters.AddWithValue("@PrenomEtudiant", etudiant.PrenomEtudiant);
                command.Parameters.AddWithValue("@IdSection", etudiant.SectionEtudiant.IdSection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int idEtudiant)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM etudiant WHERE IdEtudiant = @IdEtudiant";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEtudiant", idEtudiant);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Etudiant> ReadAll()
        {
            List<Etudiant> etudiants = new List<Etudiant>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM etudiant";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nom = reader.GetString(1);
                    string prenom = reader.GetString(2);
                    int idSection = reader.GetInt32(3);

                    
                    SectionDAO sectionDAO = new SectionDAO(connectionString);
                    Section section = sectionDAO.Read(idSection);

                    Etudiant etudiant = new Etudiant(id, nom, prenom, section);
                    etudiants.Add(etudiant);
                }
            }

            return etudiants;
        }
    }
}
