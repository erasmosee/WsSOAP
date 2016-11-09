using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WsSOAP.Models;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAutor {

        [OperationContract]
        string GetVersion();

        [OperationContract]
        Autor getAutorById(int codAutor);

        [OperationContract]
        IList<Autor> getAll();

        [OperationContract]
        IList<Autor> getAllNoBorrados();

        [OperationContract]
        IList<Autor> getAllBorrados();

        [OperationContract]
        Autor update(Autor autor);

        [OperationContract]
        void delete(int codAutor);

        [OperationContract]
        Autor create(Autor autor);


        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Autor {
        int codAutor = -1;
        string nombre = "";
        string apellidos = "";
        DateTime fNacimiento = new DateTime();
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
        public string ErrorMessage {
            get {
                return errorMessage;
            }

            set {
                errorMessage = value;
            }
        }

        [DataMember]
        public int CodAutor {
            get {
                return codAutor;
            }

            set {
                codAutor = value;
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
