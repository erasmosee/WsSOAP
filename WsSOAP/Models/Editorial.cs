using System.ComponentModel;

namespace WsSOAP.Models {
    public class Editorial
    {
        private int _codEditorial;
        private string _nombre;

        public Editorial()
        {
            this._codEditorial = -1;
            this._nombre = "";
        }

        public int CodEditorial {
            get {
                return _codEditorial;
            }

            set {
                _codEditorial = value;
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
    }
}