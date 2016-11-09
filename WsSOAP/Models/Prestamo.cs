using System;
using WsSOAP.Models;

namespace WsSOAP.Models {
    public class Prestamo {
        private int _codPrestamo;

        private Usuario _usuario;       // Dado que es el objeto Usuario, a pesar de ser obtenido del codigo Usuario, lo llamamos usuario por que hace referencia al objeto entero
        private Ejemplar _ejemplar;     // Dado que es el objeto Ejemplar, a pesar de ser obtenido del codigo Ejemplar, lo llamamos usuario por que hace referencia al objeto entero

        private DateTime _fRecogida;
        private DateTime? _fDevolucion;


        public Prestamo() {
            this._codPrestamo = -1;
            this._usuario = new Usuario();
            this._ejemplar = new Ejemplar();
            this._fRecogida = new DateTime();
            this._fDevolucion = new DateTime();

            }

        public int CodPrestamo {
            get {
                return _codPrestamo;
                }

            set {
                _codPrestamo = value;
                }
            }
        public Usuario Usuario {
            get {
                return _usuario;
                }

            set {
                _usuario = value;
                }
            }

        public Ejemplar Ejemplar {
            get {
                return _ejemplar;
                }

            set {
                _ejemplar = value;
                }
            }

        public DateTime FRecogida {
            get {
                return _fRecogida;
                }

            set {
                _fRecogida = value;
                }
            }

        public DateTime? FDevolucion {
            get {
                return _fDevolucion;
                }

            set {
                _fDevolucion = value;
                }
            }


        }
    }