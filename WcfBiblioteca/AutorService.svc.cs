using WsSOAP.BBLL;
using System;
using System.Collections.Generic;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AutorService : IAutor {
        
        WsSOAP.BBLL.interfaces.AutorService aS;

        public AutorService() {
            aS = new AutorServiceImp();
        }

        public Autor getAutorById(int codAutor) {
            Autor autor = new Autor();
            
            WsSOAP.Models.Autor aux = aS.getById(codAutor);

            if(aux==null) {
                autor.ErrorMessage = "El autor no se ha encontrado";
            } else {
                autor.CodAutor = aux.CodAutor;
                autor.Nombre = aux.Nombre;
                autor.Apellidos = aux.Apellidos;
                autor.FNacimiento = (DateTime) aux.FNacimiento;

            }

            return autor;
        }


        public IList<Autor> getAll() {
            IList<Autor> autores = new List<Autor>();
            IList<WsSOAP.Models.Autor> aux = aS.getAll();
            Autor autor;  

            if(aux==null) {
                autor = new Autor();
                autor.ErrorMessage = "No se encuentran autores.";
            } else {
                foreach(var item in aux) {
                    autor = new Autor();
                    autor.CodAutor = item.CodAutor;
                    autor.Nombre = item.Nombre;
                    autor.Apellidos = item.Apellidos;
                    autor.FNacimiento = (DateTime) item.FNacimiento;

                    autores.Add(autor);
                }
            }

            return autores;
        }

        public IList<Autor> getAllBorrados() {
            IList<Autor> autores = new List<Autor>();
            IList<WsSOAP.Models.Autor> aux = aS.getAllBorradso();
            Autor autor;  

            if(aux==null) {
                autor = new Autor();
                autor.ErrorMessage = "No se encuentran autores.";
            } else {
                foreach(var item in aux) {
                    autor = new Autor();
                    autor.CodAutor = item.CodAutor;
                    autor.Nombre = item.Nombre;
                    autor.Apellidos = item.Apellidos;
                    autor.FNacimiento = (DateTime) item.FNacimiento;


                    autores.Add(autor);
                }
            }

            return autores;
        }

        public IList<Autor> getAllNoBorrados() {
            IList<Autor> autores = new List<Autor>();
            IList<WsSOAP.Models.Autor> aux = aS.getAllNoBorrados();
            Autor autor;  

            if(aux==null) {
                autor = new Autor();
                autor.ErrorMessage = "No se encuentran autores.";
            } else {
                foreach(var item in aux) {
                    autor = new Autor();
                    autor.CodAutor = item.CodAutor;
                    autor.Nombre = item.Nombre;
                    autor.Apellidos = item.Apellidos;
                    autor.FNacimiento = (DateTime) item.FNacimiento;

                    autores.Add(autor);
                }
            }

            return autores;
        }


        public Autor create(Autor autor) {
            WsSOAP.Models.Autor aux = new WsSOAP.Models.Autor();

            aux.Nombre = autor.Nombre;
            aux.Apellidos = autor.Apellidos;
            aux.FNacimiento = (DateTime) autor.FNacimiento;

            aux=aS.create(aux);

            autor.CodAutor=aux.CodAutor;
            
            return autor;
        }

        public void delete(int codAutor) {
            aS.delete(codAutor);
        }

        public Autor update(Autor autor) {
            WsSOAP.Models.Autor aux = new WsSOAP.Models.Autor();

            aux.CodAutor = autor.CodAutor;
            aux.Nombre = autor.Nombre;
            aux.Apellidos = autor.Apellidos;
            aux.FNacimiento = (DateTime) autor.FNacimiento;

            aux=aS.update(aux);
            
            return autor;
        }

        public string GetVersion() {
            return "v1.0";
        }

    }
}
