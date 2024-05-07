using _2SIO_FSI_Adminstration.Classe.BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SIO_FSI_Adminstration.Classe.DAO
{
    public class CoursDAO
    {
        private string connectionString;

        public CoursDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Cours cours)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cours (IdCours, LibelleCours, DescriptionCours, IdSection) VALUES (@IdCours, @LibelleCours, @DescriptionCours, @IdSection)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCours", cours.IdCours);
                command.Parameters.AddWithValue("@LibelleCours", cours.LibelleCours);
                command.Parameters.AddWithValue("@DescriptionCours", cours.DescriptionCours);
                command.Parameters.AddWithValue("@IdSection", cours.SectionCours.IdSection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Cours Read(int idCours)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cours WHERE IdCours = @IdCours";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCours", idCours);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string libelle = reader.GetString(1);
                    string description = reader.GetString(2);
                    int idSection = reader.GetInt32(3);

                    
                    SectionDAO sectionDAO = new SectionDAO(connectionString);
                    Section section = sectionDAO.Read(idSection);

                    return new Cours(id, libelle, description, section);
                }

                return null;
            }
        }

        public void Update(Cours cours)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cours SET LibelleCours = @LibelleCours, DescriptionCours = @DescriptionCours, IdSection = @IdSection WHERE IdCours = @IdCours";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCours", cours.IdCours);
                command.Parameters.AddWithValue("@LibelleCours", cours.LibelleCours);
                command.Parameters.AddWithValue("@DescriptionCours", cours.DescriptionCours);
                command.Parameters.AddWithValue("@IdSection", cours.SectionCours.IdSection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int idCours)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cours WHERE IdCours = @IdCours";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCours", idCours);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Cours> ReadAll()
        {
            List<Cours> cours = new List<Cours>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cours";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string libelle = reader.GetString(1);
                    string description = reader.GetString(2);
                    int idSection = reader.GetInt32(3);

                    // Récupérer la section du cours (vous devez implémenter le SectionDAO)
                    SectionDAO sectionDAO = new SectionDAO(connectionString);
                    Section section = sectionDAO.Read(idSection);

                    Cours c = new Cours(id, libelle, description, section);
                    cours.Add(c);
                }
            }

            return cours;
        }
    }
}
