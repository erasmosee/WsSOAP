using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuario {

        [OperationContract]
        string GetVersion();

        [OperationContract]
        Usuario getUsuarioById(int codUsuario);

        [OperationContract]
        IList<Usuario> getAll();

        [OperationContract]
        IList<Usuario> getAllNoBorrados();

        [OperationContract]
        IList<Usuario> getAllBorrados();

        [OperationContract]
        int getByUsernameUsuario(string username, string passwd);

        [OperationContract]
        Usuario update(Usuario usuario);

        [OperationContract]
        void delete(int codUsuario);

        [OperationContract]
        Usuario create(Usuario usuario);


        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Usuario {
        int codUsuario = -1;
        string nombre = "";
        string apellidos = "";
        DateTime fNacimiento = new DateTime();
        string dni = "";
        string email = "";
        string username = "";
        string passwd  = "";
        int borrado = 0;
        string errorMessage = "";

        [DataMember]
        public string Nombre {
            get {
                return nombre;
            }

            set {
                nombre = value;
            }
        }

        [DataMember]
        public string Apellidos {
            get {
                return apellidos;
            }

            set {
                apellidos = value;
            }
        }

        [DataMember]
        public DateTime FNacimiento {
            get {
                return fNacimiento;
            }

            set {
                fNacimiento = value;
            }
        }

        [DataMember]
        public string Dni {
            get {
                return dni;
            }

            set {
                dni = value;
            }
        }

        [DataMember]
        public string Email {
            get {
                return email;
            }

            set {
                email = value;
            }
        }

        [DataMember]
        public string Username {
            get {
                return username;
            }

            set {
                username = value;
            }
        }

        [DataMember]
        public string Passwd {
            get {
                return passwd;
            }

            set {
                passwd = value;
            }
        }

        [DataMember]
        public string ErrorMessage {
            get {
                return errorMessage;
            }

            set {
                errorMessage = value;
            }
        }

        [DataMember]
        public int CodUsuario {
            get {
                return codUsuario;
            }

            set {
                codUsuario = value;
            }
        }

        [DataMember]
        public int Borrado {
            get {
                return borrado;
            }

            set {
                borrado = value;
            }
        }
    }
}
