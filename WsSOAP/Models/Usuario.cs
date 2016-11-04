using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WsSOAP.Models {
    public class Usuario {

        private int _codUsuario;
       
        private string _nombre;
        private string _apellidos;
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        private DateTime? _fNacimiento;
        private string _passwd;
        private string _username;
        private string _email;
        private string _dni;

        public Usuario()
        {
            this._codUsuario = -1;
            this._nombre = "";
            this._apellidos = "";
            this.FNacimiento = null;
            this._passwd = "";
            this._username = "";
            this._email = "";
            this._dni = "";
        }
        public int CodUsuario {
            get {
                return _codUsuario;
            }

            set {
                _codUsuario = value;
            }
        }

        [DisplayName("Nombre: ")]
        public string Nombre {
            get {
                return _nombre;
            }

            set {
                _nombre = value;
            }
        }

        [DisplayName("Apellidos: ")]
        public string Apellidos {
            get {
                return _apellidos;
            }

            set {
                _apellidos = value;
            }
        }

        [DisplayName("Fecha de Nacimiento: ")]
        public DateTime? FNacimiento {
            get {
                return _fNacimiento;
            }

            set {
                _fNacimiento = value;
            }
        }
        [DataType(DataType.Password)]
        [DisplayName("Contraseña: ")]
        public string Passwd {
            get {
                return _passwd;
            }

            set {
                _passwd = value;
            }
        }

        [DisplayName("Usuario: ")]
        public string Username {
            get {
                return _username;
            }

            set {
                _username = value;
            }
        }

        [DisplayName("Email: ")]
        public string Email {
            get {
                return _email;
            }

            set {
                _email = value;
            }

        }

        [DisplayName("Documento Identificativo: ")]
        public string Dni {
            get {
                return _dni;
            }

            set {
                _dni = value;
            }
        }

    }
}