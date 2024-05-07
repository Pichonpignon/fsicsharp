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
    public class SectionDAO
    {
        private string connectionString;

        public SectionDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Section section)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO section (IdSection, LilbelleSection) VALUES (@IdSection, @LilbelleSection)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdSection", section.IdSection);
                command.Parameters.AddWithValue("@LilbelleSection", section.LilbelleSection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Section Read(int idSection)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM section WHERE IdSection = @IdSection";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdSection", idSection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string libelle = reader.GetString(1);

                    return new Section { IdSection = id, LilbelleSection = libelle };
                }

                return null;
            }
        }

        public void Update(Section section)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE section SET LilbelleSection = @LilbelleSection WHERE IdSection = @IdSection";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdSection", section.IdSection);
                command.Parameters.AddWithValue("@LilbelleSection", section.LilbelleSection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int idSection)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM section WHERE IdSection = @IdSection";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdSection", idSection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<Section> ReadAll()
        {
            List<Section> sections = new List<Section>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM section";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string libelle = reader.GetString(1);

                    Section section = new Section();
                    section.IdSection = id;
                    section.LilbelleSection = libelle;
                    sections.Add(section);
                }
            }

            return sections;
        }
    }
}
