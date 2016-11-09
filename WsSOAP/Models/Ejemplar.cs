using System;
using System.Collections.Generic;

namespace WsSOAP.Models {
    public class Ejemplar : Libro
    {

        // public int CodigoEjemplar { get; set; }
        // [Required(ErrorMessage = "El ISBN es de introduccion ibligatoria")]
        // [StringLength(13,ErrorMessage ="La longitud debe ser de 13 caracteres")]
        // public string ISBN { get; set; }
        // [DisplayName("numero de paginas")]
        // [Range(5,10000,ErrorMessage ="El numero de paginas debe estar entre 5 y 10000")]
        // public int Npaginas { get; set; }
        // public Editorial Editorial { get; set; }
        // [DataType(DataType.Date)]
        // public DateTime Fpublicacion { get; set; }
        // public IList<Prestamo>

        private int _codEjemplar;
        private string _isbn;
        private int _nPaginas;
        private DateTime _fPublicacion;
        private Editorial _editorial;
        private IList<Prestamo> _prestamos;

        public Ejemplar()
        {
            this._codEjemplar = -1;
            this._isbn = "";
            this._nPaginas = 0;
            this._editorial = new Editorial();
            this._fPublicacion = new DateTime();
            this._prestamos = null;
        }

        public int CodEjemplar {
            get {
                return _codEjemplar;
            }

            set {
                _codEjemplar = value;
            }
        }

        public string Isbn {
            get {
                return _isbn;
            }

            set {
                _isbn = value;
            }
        }

        public int NPaginas {
            get {
                return _nPaginas;
            }

            set {
                _nPaginas = value;
            }
        }

        public DateTime FPublicacion {
            get {
                return _fPublicacion;
            }

            set {
                _fPublicacion = value;
            }
        }

        public Editorial Editorial {
            get {
                return _editorial;
            }

            set {
                _editorial = value;
            }
        }

        public IList<Prestamo> Prestamos {
            get {
                return _prestamos;
            }

            set {
                _prestamos = value;
            }
        }
    }
}