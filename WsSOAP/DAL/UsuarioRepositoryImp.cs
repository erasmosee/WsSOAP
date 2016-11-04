using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WsSOAP.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WsSOAP.DAL.interfaces;

namespace WsSOAP.DAL {
    public class UsuarioRepositoryImp : UsuarioRepository {

        private string conexionString = "Data Source=FORMACION-TOSH4;Initial Catalog=gestionlibreria;Persist Security Info=True;User ID=curso;Password=curso";

        private Usuario parseUsuario(SqlDataReader reader) {
            Usuario usuario = new Usuario();
            // usuario.CodUsuario = new int(reader["codUsuario"].ToString());
            usuario.CodUsuario = Int32.Parse(reader["codUsuario"].ToString());
            usuario.Nombre = reader["nombre"].ToString();
            usuario.Apellidos = reader["apellidos"].ToString();
            usuario.FNacimiento = Convert.ToDateTime(reader["fNacimiento"]);
            usuario.Dni = reader["dni"].ToString();
            usuario.Email = reader["email"].ToString();
            usuario.Username = reader["username"].ToString();
            usuario.Passwd = reader["passwd"].ToString();

            return usuario;
        }

        // CREATE
        public Usuario create(Usuario usuario) {
            const string SQL = "crearUsuario";

            try {
                using (SqlConnection conexion = new SqlConnection(conexionString)) {
                    SqlCommand command = conexion.CreateCommand();
                    command.CommandText = SQL;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = conexion;
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                    command.Parameters.AddWithValue("@fNacimiento", usuario.FNacimiento);
                    command.Parameters.AddWithValue("@dni", usuario.Dni);
                    command.Parameters.AddWithValue("@email", usuario.Email);
                    command.Parameters.AddWithValue("@username", usuario.Username);
                    command.Parameters.AddWithValue("@passwd", usuario.Passwd);
                    command.Parameters.Add("@codUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conexion.Open();

                    command.ExecuteNonQuery();

                    usuario.CodUsuario = Convert.ToInt32(command.Parameters["@codUsuario"].Value);

                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            } catch(SqlException e) {
                // ERROR AL CREAR EL USUARIO
                String errorMensaje = "Error al crear el usuario: " + e.Message;
                //usuario.CodUsuario = -1;
            }

            return usuario;
        }
    
        // GETALL
        public IList<Usuario> getAll() {
            IList<Usuario> usuarios = new List<Usuario>();

            const string SQL = "getAllUsuarios";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            usuarios.Add(parseUsuario(reader));
                            }
                        }
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }

            return usuarios;
        }
        // GETALL BORRADOS
        public IList<Usuario> getAllBorrados() {
            IList<Usuario> usuariosBorrados = new List<Usuario>();

            const string SQL = "getAllUsuariosBorrados";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            usuariosBorrados.Add(parseUsuario(reader));
                            }
                        }
                    }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return usuariosBorrados;
            }
        // GETALL NO BORRADOS
        public IList<Usuario> getAllNoBorrados() {
            IList<Usuario> usuariosNoBorrados = new List<Usuario>();

            const string SQL = "getAllUsuariosNoBorrados";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            usuariosNoBorrados.Add(parseUsuario(reader));
                            }
                        }
                    }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return usuariosNoBorrados;
            }
        // GET BY ID
        public Usuario getById( int codUsuario ) {
            Usuario usuario = null;
            const string SQL = "getByIdUsuario";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codUsuario", codUsuario);
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            usuario = parseUsuario(reader);
                            }
                        }
                    }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
           
            return usuario;
        }

        // GET BY USERNAME USUARIO
        public int getByUsernameUsuario(string username, string passwd) {
            int codUsuario = -1;

            const string SQL = "getByUsernameUsuario";

            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@passwd", passwd);
                command.Parameters.Add("@pCodUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Connection = conexion;

                conexion.Open();

                command.ExecuteNonQuery();

                try {
                    codUsuario = Convert.ToInt32(command.Parameters["@pCodUsuario"].Value);
                } catch(Exception e) {
                    System.Diagnostics.Debug.Write("Mensaje de error: " + e.Message);
                    codUsuario = -1;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return codUsuario;
        }

        // UPDATE
        public Usuario update( Usuario usuario ) {
            const string SQL = "actualizarUsuario";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                command.Parameters.AddWithValue("@codUsuario", usuario.CodUsuario);
                command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                command.Parameters.AddWithValue("@fNacimiento", usuario.FNacimiento);
                command.Parameters.AddWithValue("@dni", usuario.Dni);
                command.Parameters.AddWithValue("@email", usuario.Email);
                command.Parameters.AddWithValue("@username", usuario.Username);
                command.Parameters.AddWithValue("@passwd", usuario.Passwd);

                conexion.Open();

                command.ExecuteNonQuery();

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return usuario;
            }
        }
        // DELETE
        public void delete( int codUsuario ) {
            const string SQL = "borrarUsuario";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codUsuario", codUsuario);
                command.Connection = conexion;
                conexion.Open();
                command.ExecuteNonQuery();
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
           
        }

    }
}