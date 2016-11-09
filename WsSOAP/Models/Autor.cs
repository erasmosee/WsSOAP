using System;
using System.ComponentModel;


namespace WsSOAP.Models
{
    public class Autor
    {
        private int _codAutor;
        private string _nombre;
        private string _apellidos;
        private DateTime _fNacimiento;


        public Autor()
        {
            this._codAutor = -1;
            this._nombre = "";
            this._apellidos = "";
            this._fNacimiento = new DateTime();

        }

        public int CodAutor {
            get {
                return _codAutor;
            }

            set {
                _codAutor = value;
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
        public DateTime FNacimiento {
            get {
                return _fNacimiento;
            }

            set {
                _fNacimiento = value;
            }
        }
    }
}