using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WsSOAP.DAL.interfaces;
using WsSOAP.Models;

namespace WsSOAP.DAL {
    public class AutorRepositoryImp : AutorRepository {
        private string conexionString = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        // PARSE
        // CREATE
        // GETALL
        // GETALL BORRADOS
        // GETALL NO BORRADOS
        // GET BY ID
        // UPDATE
        // DELETE


        // PARSE
        private Autor parseAutor(SqlDataReader reader) {
            Autor autor = new Autor();
            autor.CodAutor = Int32.Parse(reader["codAutor"].ToString());
            autor.Nombre = reader["nombre"].ToString();
            autor.Apellidos = reader["apellidos"].ToString();
            autor.FNacimiento = Convert.ToDateTime(reader["fNacimiento"]);

            return autor;
        }

        // CREATE
        public Autor create(Autor autor) {
            const string SQL = "crearAutor";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();
                command.Parameters.AddWithValue("@nombre", autor.Nombre);
                command.Parameters.AddWithValue("@apellidos", autor.Apellidos);
                command.Parameters.AddWithValue("@fNacimiento", autor.FNacimiento);
                command.Parameters.Add("@codAutor", SqlDbType.Int).Direction = ParameterDirection.Output;
                
                command.ExecuteNonQuery();

                autor.CodAutor = Convert.ToInt32(command.Parameters["@codAutor"].Value);

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            return autor;
        }

        // GETALL
        public IList<Autor> getAll() {
            IList<Autor> autores = new List<Autor>();

            const string SQL = "getAllAutores";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            autores.Add(parseAutor(reader));
                        }
                    }
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }
            return autores;
        }

        // GETALL BORRADOS
        public IList<Autor> getAllBorrados() {
            IList<Autor> autoresBorrados = new List<Autor>();

            const string SQL = "getAllAutoresBorrados";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            autoresBorrados.Add(parseAutor(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open) 
                    conexion.Close();
            }
            return autoresBorrados;
        }

        // GETALL NO BORRADOS
        public IList<Autor> getAllNoBorrados() {
            IList<Autor> autoresNoBorrados = new List<Autor>();

            const string SQL = "getAllAutoresNoBorrados";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            autoresNoBorrados.Add(parseAutor(reader));
                        }
                    }
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return autoresNoBorrados;
        }

        // GET BY ID
        public Autor getById(int codAutor) {
            Autor autor = new Autor();
            const string SQL = "getByIdAutor";
            using (SqlConnection conexiona = new SqlConnection(conexionString)) {

                SqlCommand command = conexiona.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codAutor", codAutor);
                command.Connection = conexiona;
                conexiona.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            autor = parseAutor(reader);
                        }
                    }
                }
                if (conexiona.State == System.Data.ConnectionState.Open)
                    conexiona.Close();
            }

            return autor;
        }

        // UPDATE
        public Autor update(Autor autor) {
            const string SQL = "actualizarAutor";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                command.Parameters.AddWithValue("@codAutor",autor.CodAutor);
                command.Parameters.AddWithValue("@nombre", autor.Nombre);
                command.Parameters.AddWithValue("@apellidos", autor.Apellidos);
                command.Parameters.AddWithValue("@fNacimiento", autor.FNacimiento);


                conexion.Open();

                command.ExecuteNonQuery();

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return autor;
            }
        }

        // DELETE
        public void delete(int codAutor) {
            const string SQL = "borrarAutor";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codAutor", codAutor);
                command.Connection = conexion;
                conexion.Open();
                command.ExecuteNonQuery();
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }
    }
}