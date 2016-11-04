using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfBiblioteca {
    public class UsuarioWS {
        int? codUsuario;
        string nombre;
        string apellidos;
        DateTime? fNacimiento;
        string dni;
        string email;
        string username;
        string passwd;
        string errorMessage;

        public int? CodUsuario {
            get {
                return codUsuario;
            }

            set {
                codUsuario = value;
            }
        }

        public string Nombre {
            get {
                return nombre;
            }

            set {
                nombre = value;
            }
        }

        public string Apellidos {
            get {
                return apellidos;
            }

            set {
                apellidos = value;
            }
        }

        public DateTime? FNacimiento {
            get {
                return fNacimiento;
            }

            set {
                fNacimiento = value;
            }
        }

        public string Dni {
            get {
                return dni;
            }

            set {
                dni = value;
            }
        }

        public string Email {
            get {
                return email;
            }

            set {
                email = value;
            }
        }

        public string Username {
            get {
                return username;
            }

            set {
                username = value;
            }
        }

        public string Passwd {
            get {
                return passwd;
            }

            set {
                passwd = value;
            }
        }

        public string ErrorMessage {
            get {
                return errorMessage;
            }

            set {
                errorMessage = value;
            }
        }

    }
}