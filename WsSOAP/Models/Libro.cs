using System.ComponentModel;

namespace WsSOAP.Models {
    public class Libro
    {
        private int _codLibro;
        private string _titulo;
        private Autor _autor;

        public Libro()
        {
            this._codLibro = -1;
            this._titulo = "";
            this._autor = new Autor();
        }

        public int CodLibro {
            get {
                return _codLibro;
            }

            set {
                _codLibro = value;
            }
        }

        [DisplayName("Titulo: ")]
        public string Titulo {
            get {
                return _titulo;
            }

            set {
                _titulo = value;
            }
        }

        [DisplayName("Autor: ")]
        public Autor Autor {
            get {
                return _autor;
            }

            set {
                _autor = value;
            }
        }
    }
}