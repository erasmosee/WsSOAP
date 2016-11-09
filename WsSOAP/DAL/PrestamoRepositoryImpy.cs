using System;
using System.Collections.Generic;
using WsSOAP.Models;
using System.Data.SqlClient;
using System.Configuration;
using WsSOAP.DAL.interfaces;
using System.Data;

namespace WsSOAP.DAL {
    public class PrestamoRepositoryImp : PrestamoRepository
        {

        private string conexionString = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        //PARSER
        private Prestamo parsePrestamo(SqlDataReader reader) {
            Prestamo prestamo = new Prestamo();

            prestamo.CodPrestamo = Int32.Parse(reader["codPrestamo"].ToString());
            prestamo.Ejemplar.CodEjemplar = Int32.Parse(reader["codEjemplar"].ToString());
            prestamo.Ejemplar.CodLibro = Int32.Parse(reader["codLibro"].ToString());
            prestamo.Ejemplar.Titulo = reader["titulo"].ToString();
            prestamo.Ejemplar.FPublicacion = Convert.ToDateTime(reader["fPublicacion"]);
            prestamo.Ejemplar.Isbn = reader["isbn"].ToString();
            prestamo.Ejemplar.NPaginas = Int32.Parse(reader["codLibro"].ToString());
            prestamo.Ejemplar.Editorial.CodEditorial = Int32.Parse(reader["codEditorial"].ToString());
            prestamo.Ejemplar.Editorial.Nombre = reader["nombreEditorial"].ToString();
            prestamo.Ejemplar.Autor.CodAutor = Int32.Parse(reader["codAutor"].ToString());
            prestamo.Ejemplar.Autor.Nombre = reader["nombreAutor"].ToString();
            prestamo.Ejemplar.Autor.Apellidos = reader["apellidosAutor"].ToString();
            prestamo.Ejemplar.Autor.FNacimiento = Convert.ToDateTime(reader["fNacimientoAutor"]);
            prestamo.Usuario.CodUsuario = Int32.Parse(reader["codUsuario"].ToString());
            prestamo.Usuario.Nombre= reader["nombreUsuario"].ToString();
            prestamo.Usuario.Apellidos= reader["apellidosUsuario"].ToString();
            prestamo.Usuario.FNacimiento= Convert.ToDateTime(reader["fNacimientoUsuario"]);
            prestamo.Usuario.Dni= reader["dni"].ToString();
            prestamo.Usuario.Passwd= reader["passwd"].ToString();
            prestamo.Usuario.Username= reader["username"].ToString();
            prestamo.Usuario.Email= reader["email"].ToString();
            prestamo.FRecogida = Convert.ToDateTime(reader["fRecogida"]);
    //         if (reader["fDevolucion"]!=null) {
    //        prestamo.FDevolucion = Convert.ToDateTime(reader["fDevolucion"]);
    //       }
            return prestamo;
        }

        // CREATE
        public Prestamo create(Prestamo prestamo) {
            const string SQL = "crearPrestamo";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                command.Parameters.AddWithValue("@codUsuario", prestamo.Usuario.CodUsuario);
                command.Parameters.AddWithValue("@codEjemplar", prestamo.Ejemplar.CodEjemplar);
                command.Parameters.AddWithValue("@fRecogida", prestamo.FRecogida);
                command.Parameters.AddWithValue("@fDevolucion", prestamo.FDevolucion);
                conexion.Open();

                command.ExecuteNonQuery();

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return prestamo;
            }
        }

        // GETALL
        public IList<Prestamo> getAll() {
            IList<Prestamo> prestamos = new List<Prestamo>();

            const string SQL = "getAllPrestamos";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            prestamos.Add(parsePrestamo(reader));
                        }
                    }
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }

            return prestamos;
        }

        // GET ALL PRESTAMOS BY USUARIO
        public IList<Prestamo> getAllPrestamosByUsuario(int codUsuario) {
            IList<Prestamo> prestamos = new List<Prestamo>();
            const string SQL = "getAllPrestamosByUsuario";
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
                            prestamos.Add(parsePrestamo(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return prestamos;
        }

        // GET BY ID
        public Prestamo getById(int codPrestamo) {
            Prestamo prestamo = new Prestamo();
            const string SQL = "getByIdPrestamo";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codPrestamo", codPrestamo);
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            prestamo = parsePrestamo(reader);
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return prestamo;
        }

        // GET BY EJEMPLAR PRESTAMO
        public IList<Prestamo> getByEjemplarPrestamo(int codEjemplar) {
            IList<Prestamo> prestamos = new List<Prestamo>();
            //Prestamo prestamo = new Prestamo();
            const string SQL = "getByEjemplarPrestamo";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codEjemplar", codEjemplar);
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            
                            prestamos.Add(parsePrestamo(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return prestamos;
        }

        // UPDATE
        public Prestamo update(Prestamo prestamo) {
            const string SQL = "actualizarPrestamo";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                command.Parameters.AddWithValue("@codUsuario", prestamo.Usuario.CodUsuario);
                command.Parameters.AddWithValue("@codEjemplar", prestamo.Ejemplar.CodEjemplar);
                command.Parameters.AddWithValue("@fRecogida", prestamo.FRecogida);
                command.Parameters.AddWithValue("@fDevolucion", prestamo.FDevolucion);
                conexion.Open();

                command.ExecuteNonQuery();

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return prestamo;
            }
        }

        // DELETE
        public void delete(int codPrestamo) {
            const string SQL = "borrarPrestamo";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codPrestamo", codPrestamo);
                command.Connection = conexion;
                conexion.Open();
                command.ExecuteNonQuery();
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

        }

    }
}
     