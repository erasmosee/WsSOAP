using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WsSOAP.DAL.interfaces;
using WsSOAP.Models;

namespace WsSOAP.DAL {
    public class EjemplarRepositoryImp : EjemplarRepository {
        private PrestamoService pS = new PrestamoServiceImp();
        private string conexionString = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        // PARSE
        // CREATE
        // GETALL
        // GETALL BORRADOS
        // GETALL NO BORRADOS
        // GET BY ID
        // UPDATE
        // DELETE
        // GET EJEMPLARES BY LIBRO
        // GET EJEMPLARES BY EDITORIAL

        //PARSER
        private Ejemplar parseEjemplar(SqlDataReader reader) {
            Ejemplar ejemplar = new Ejemplar();
            
            

            ejemplar.CodEjemplar = Int32.Parse(reader["codEjemplar"].ToString());
            ejemplar.Isbn = reader["isbn"].ToString();
            ejemplar.NPaginas = Int32.Parse(reader["nPaginas"].ToString());
            ejemplar.FPublicacion = Convert.ToDateTime(reader["fPublicacion"]);
            ejemplar.CodLibro= Int32.Parse(reader["codLibro"].ToString());
            ejemplar.Titulo= reader["titulo"].ToString();
            ejemplar.Editorial.CodEditorial= Int32.Parse(reader["codEditorial"].ToString());
            ejemplar.Editorial.Nombre= reader["nombreEditorial"].ToString();
            ejemplar.Autor.CodAutor= Int32.Parse(reader["codAutor"].ToString());
            ejemplar.Autor.Nombre= reader["nombreAutor"].ToString();
            ejemplar.Autor.Apellidos= reader["apellidosAutor"].ToString();
            ejemplar.Autor.FNacimiento= Convert.ToDateTime(reader["fNacimientoAutor"]);

               

            return ejemplar;
        }

        // CREATE
        public Ejemplar create(Ejemplar ejemplar) {
            const string SQL = "crearEjemplar";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                command.Parameters.AddWithValue("@codEditorial", ejemplar.Editorial.CodEditorial);
                command.Parameters.AddWithValue("@codLibro", ejemplar.CodLibro);
                command.Parameters.AddWithValue("@isbn", ejemplar.Isbn);
                command.Parameters.AddWithValue("@nPaginas", ejemplar.NPaginas);
                command.Parameters.AddWithValue("@fPublicacion", ejemplar.FPublicacion);
                command.Parameters.Add("@codEjemplar", SqlDbType.Int).Direction = ParameterDirection.Output;

                conexion.Open();

                command.ExecuteNonQuery();

                ejemplar.CodEjemplar = Convert.ToInt32(command.Parameters["@codEjemplar"].Value);

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return ejemplar;
            }
        }

        // GETALL
        public IList<Ejemplar> getAll() {
            IList<Ejemplar> ejemplares = new List<Ejemplar>();

            const string SQL = "getAllEjemplares";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            ejemplares.Add(parseEjemplar(reader));
                        }
                    }
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }

           
            //foreach (Ejemplar e in ejemplares) {
            //    e.Prestamos = pS.getByEjemplarPrestamo(e.CodEjemplar);
            //}

            


            return ejemplares;
        }

        // GETALL BORRADOS
        public IList<Ejemplar> getAllBorrados() {
            IList<Ejemplar> ejemplaresBorrados = new List<Ejemplar>();

            const string SQL = "getAllEjemplaresBorrados";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            ejemplaresBorrados.Add(parseEjemplar(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            //foreach (Ejemplar e in ejemplaresBorrados) {
            //    e.Prestamos = pS.getByEjemplarPrestamo(e.CodEjemplar);
            //}


            return ejemplaresBorrados;
        }

        // GETALL NO BORRADOS
        public IList<Ejemplar> getAllNoBorrados() {
            IList<Ejemplar> ejemplaresNoBorrados = new List<Ejemplar>();

            const string SQL = "getAllEjemplaresNoBorrados";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            ejemplaresNoBorrados.Add(parseEjemplar(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            //foreach (Ejemplar e in ejemplaresNoBorrados) {
            //    e.Prestamos = pS.getByEjemplarPrestamo(e.CodEjemplar);
            //}


            return ejemplaresNoBorrados;
        }

        // GET BY ID
        public Ejemplar getById(int codEjemplar) {
            Ejemplar ejemplar = new Ejemplar();
            const string SQL = "getByIdEjemplar";
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
                            ejemplar = parseEjemplar(reader);
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            //ejemplar.Prestamos = pS.getByEjemplarPrestamo(codEjemplar);

            return ejemplar;
        }

        // UPDATE
        public Ejemplar update(Ejemplar ejemplar) {
            const string SQL = "actualizarEjemplar";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                command.Parameters.AddWithValue("@codEditorial", ejemplar.Editorial.CodEditorial);
                command.Parameters.AddWithValue("@codLibro", ejemplar.CodLibro);
                command.Parameters.AddWithValue("@isbn", ejemplar.Isbn);
                command.Parameters.AddWithValue("@nPaginas", ejemplar.NPaginas);
                command.Parameters.AddWithValue("@fPublicacion", ejemplar.FPublicacion);


                conexion.Open();

                command.ExecuteNonQuery();

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return ejemplar;
            }
        }

        // DELETE
        public void delete(int codEjemplar) {
            const string SQL = "borrarEjemplar";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codEjemplar", codEjemplar);
                command.Connection = conexion;
                conexion.Open();
                command.ExecuteNonQuery();
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }



        // GET EJEMPLARES BY LIBRO
        public IList<Ejemplar> getEjemplaresByLibro(int codLibro) {
            IList<Ejemplar> ejemplaresByLibro = new List<Ejemplar>();
            const string SQL = "getByLibroEjemplar";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codLibro", codLibro);
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            ejemplaresByLibro.Add(parseEjemplar(reader));

                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return ejemplaresByLibro;
        }
        
        // GET EJEMPLARES BY EDITORIAL
        public IList<Ejemplar> getAllEjemplaresByEditorial(int codEditorial) {
            IList<Ejemplar> ejemplaresByEditorial = new List<Ejemplar>();
            const string SQL = "getAllEjemplaresByEditorial";
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
                            ejemplaresByEditorial.Add(parseEjemplar(reader));

                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return ejemplaresByEditorial;
        }

    }
}