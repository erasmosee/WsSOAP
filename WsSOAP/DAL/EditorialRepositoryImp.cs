using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WsSOAP.DAL.interfaces;

namespace WsSOAP.DAL {
    public class EditorialRepositoryImp : EditorialRepository {
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
        private Editorial parseEditorial(SqlDataReader reader) {
            Editorial editorial = new Editorial();
            editorial.CodEditorial = Int32.Parse(reader["codEditorial"].ToString());
            editorial.Nombre = reader["nombre"].ToString();

            return editorial;
        }

        // CREATE
        public Editorial create(Editorial editorial) {
            const string SQL = "crearEditorial";
              try {
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;

                command.Parameters.AddWithValue("@nombre", editorial.Nombre);
                command.Parameters.Add("@codEditorial", SqlDbType.Int).Direction = ParameterDirection.Output;

                conexion.Open();
               
                command.ExecuteNonQuery();

                editorial.CodEditorial = Convert.ToInt32(command.Parameters["@codEditorial"].Value);
                
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                  }
            } catch(SqlException e) {
                // ERROR AL CREAR EL USUARIO
                String errorMensaje = "Error al crear el usuario: " + e.Message;
                //usuario.CodUsuario = -1;
            }

            return editorial;
          
        }  

        // GETALL
        public IList<Editorial> getAll() {
            IList<Editorial> editoriales = new List<Editorial>();

            const string SQL = "getAllEditoriales";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            editoriales.Add(parseEditorial(reader));
                        }
                    }
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }

            return editoriales;
        }

        // GETALL BORRADOS
        public IList<Editorial> getAllBorrados() {
            IList<Editorial> editorialesBorradas = new List<Editorial>();

            const string SQL = "getAllEditorialesBorradas";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            editorialesBorradas.Add(parseEditorial(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return editorialesBorradas;
        }

        // GETALL NO BORRADOS
        public IList<Editorial> getAllNoBorrados() {
            IList<Editorial> editorialesNoBorradas = new List<Editorial>();

            const string SQL = "getAllEditorialesNoBorradas";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            editorialesNoBorradas.Add(parseEditorial(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return editorialesNoBorradas;
        }

        // GET BY ID
        public Editorial getById(int codEditorial) {
            Editorial editorial = new Editorial();
            const string SQL = "getByIdEditorial";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codEditorial", codEditorial);
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            editorial = parseEditorial(reader);
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return editorial;
        }

        // UPDATE
        public Editorial update(Editorial editorial) {
            const string SQL = "actualizarEditorial";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;

                command.Parameters.AddWithValue("@codEditorial", editorial.CodEditorial);
                command.Parameters.AddWithValue("@nombre", editorial.Nombre);

                conexion.Open();

                
                command.ExecuteNonQuery();

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return editorial;
            }
        }

        // DELETE
        public void delete(int codEditorial) {
            const string SQL = "borrarEditorial";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codEditorial", codEditorial);
                command.Connection = conexion;
                conexion.Open();
                command.ExecuteNonQuery();
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }
    }
}