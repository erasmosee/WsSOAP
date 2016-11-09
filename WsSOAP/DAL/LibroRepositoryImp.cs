using WsSOAP.DAL.interfaces;
using System;
using System.Collections.Generic;
using WsSOAP.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WsSOAP.DAL {
    public class LibroRepositoryImp : LibroRepository {
        private string conexionString = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        public Libro create(Libro libro) {
            const string SQL = "crearLibro";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                command.Parameters.AddWithValue("@codAutor", libro.Autor.CodAutor);
                command.Parameters.AddWithValue("@titulo", libro.Titulo);


                conexion.Open();

                command.ExecuteNonQuery();

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return libro;
            }
        }

        public void delete(int codLibro) {
            const string SQL = "borrarLibro";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codLibro", codLibro);
                command.Connection = conexion;
                conexion.Open();
                command.ExecuteNonQuery();
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }

        public IList<Libro> getAll() {
            IList<Libro> libros = new List<Libro>();

            const string SQL = "getAllLibros";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            libros.Add(parseLibro(reader));
                        }
                    }
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }


            return libros;
        }

        //PARSER
        private Libro parseLibro(SqlDataReader reader) {
            Libro libro = new Libro();
           
            libro.CodLibro = Int32.Parse(reader["codLibro"].ToString());
            libro.Titulo = reader["titulo"].ToString();
            libro.Autor.CodAutor= Int32.Parse(reader["codAutor"].ToString());
            libro.Autor.Nombre = reader["nombre"].ToString();
            libro.Autor.Apellidos = reader["apellidos"].ToString();
            libro.Autor.FNacimiento= Convert.ToDateTime(reader["fNacimiento"]);


            return libro;
        }
        // GET ALL BORRADOS
        public IList<Libro> getAllBorrados() {
            IList<Libro> librosBorrados = new List<Libro>();

            const string SQL = "getAllLibrosBorrados";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            librosBorrados.Add(parseLibro(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }


            return librosBorrados;
        }
        // GET ALL NO BORRADOS
        public IList<Libro> getAllNoBorrados() {
            IList<Libro> librosNoBorrados = new List<Libro>();

            const string SQL = "getAllLibrosNoBorrados";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            librosNoBorrados.Add(parseLibro(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }


            return librosNoBorrados;
        }
        // GET BY ID
        public Libro getById(int codLibro) {
            Libro libro = new Libro();
            const string SQL = "getByIdLibro";
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
                            libro = parseLibro(reader);
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return libro;
        }
        // UPDATE
        public Libro update(Libro libro) {
            const string SQL = "actualizarLibro";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {
                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conexion;
                command.Parameters.AddWithValue("@codAutor", libro.Autor.CodAutor);
                command.Parameters.AddWithValue("@titulo", libro.Titulo);


                conexion.Open();

                command.ExecuteNonQuery();

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();

                return libro;
            }
        }

        public IList<Libro> getAllLibrosByAutor(int codAutor) {
            IList<Libro> libros = new List<Libro>();
            const string SQL = "getAllLibrosByAutor";
            using (SqlConnection conexion = new SqlConnection(conexionString)) {

                SqlCommand command = conexion.CreateCommand();
                command.CommandText = SQL;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codAutor", codAutor);
                command.Connection = conexion;
                conexion.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {

                    if (reader.HasRows) {
                        while (reader.Read()) {
                            libros.Add(parseLibro(reader));
                        }
                    }
                }
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return libros;
        }
    }
}