using WsSOAP.BBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioService : IUsuario {
        
        WsSOAP.BBLL.interfaces.UsuarioService uS;

        public UsuarioService() {
            uS = new UsuarioServiceImp();
        }

        public Usuario getUsuarioById(int codUsuario) {
            Usuario usuario = new Usuario();
            
            WsSOAP.Models.Usuario aux = uS.getById(codUsuario);

            if(aux==null) {
                usuario.ErrorMessage = "El usuario no se ha encontrado";
            } else {
                usuario.CodUsuario = aux.CodUsuario;
                usuario.Nombre = aux.Nombre;
                usuario.Apellidos = aux.Apellidos;
                usuario.Dni = aux.Dni;
                usuario.FNacimiento = (DateTime) aux.FNacimiento;
                usuario.Email = aux.Email;
                usuario.Username = aux.Username;
                usuario.Passwd = aux.Passwd;
            }

            return usuario;
        }


        public IList<Usuario> getAll() {
            IList<Usuario> usuarios = new List<Usuario>();
            IList<WsSOAP.Models.Usuario> aux = uS.getAll();
            Usuario usuario;  

            if(aux==null) {
                usuario = new Usuario();
                usuario.ErrorMessage = "No se encuentran usuarios.";
            } else {
                foreach(var item in aux) {
                    usuario = new Usuario();
                    usuario.CodUsuario = item.CodUsuario;
                    usuario.Nombre = item.Nombre;
                    usuario.Apellidos = item.Apellidos;
                    usuario.Dni = item.Dni;
                    usuario.FNacimiento = (DateTime) item.FNacimiento;
                    usuario.Email = item.Email;
                    usuario.Username = item.Username;
                    usuario.Passwd = item.Passwd;

                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        public IList<Usuario> getAllBorrados() {
            IList<Usuario> usuarios = new List<Usuario>();
            IList<WsSOAP.Models.Usuario> aux = uS.getAllBorrados();
            Usuario usuario;  

            if(aux==null) {
                usuario = new Usuario();
                usuario.ErrorMessage = "No se encuentran usuarios.";
            } else {
                foreach(var item in aux) {
                    usuario = new Usuario();
                    usuario.CodUsuario = item.CodUsuario;
                    usuario.Nombre = item.Nombre;
                    usuario.Apellidos = item.Apellidos;
                    usuario.Dni = item.Dni;
                    usuario.FNacimiento = (DateTime) item.FNacimiento;
                    usuario.Email = item.Email;
                    usuario.Username = item.Username;
                    usuario.Passwd = item.Passwd;

                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        public IList<Usuario> getAllNoBorrados() {
            IList<Usuario> usuarios = new List<Usuario>();
            IList<WsSOAP.Models.Usuario> aux = uS.getAllNoBorrados();
            Usuario usuario;  

            if(aux==null) {
                usuario = new Usuario();
                usuario.ErrorMessage = "No se encuentran usuarios.";
            } else {
                foreach(var item in aux) {
                    usuario = new Usuario();
                    usuario.CodUsuario = item.CodUsuario;
                    usuario.Nombre = item.Nombre;
                    usuario.Apellidos = item.Apellidos;
                    usuario.Dni = item.Dni;
                    usuario.FNacimiento = (DateTime) item.FNacimiento;
                    usuario.Email = item.Email;
                    usuario.Username = item.Username;
                    usuario.Passwd = item.Passwd;

                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        public int getByUsernameUsuario(string username, string passwd) {
            Usuario usuario = new Usuario();
                        
            int aux = uS.getByUsernameUsuario(username, passwd);

            if(aux>0) {
                usuario.ErrorMessage = "El usuario no se ha encontrado";
            } else {
                usuario.CodUsuario = aux;
            }

            return aux;
        }

        public Usuario create(Usuario usuario) {
            WsSOAP.Models.Usuario aux = new WsSOAP.Models.Usuario();

            aux.Nombre = usuario.Nombre;
            aux.Apellidos = usuario.Apellidos;
            aux.Dni = usuario.Dni;
            aux.FNacimiento = (DateTime) usuario.FNacimiento;
            aux.Email = usuario.Email;
            aux.Username = usuario.Username;
            aux.Passwd = usuario.Passwd;
            aux=uS.create(aux);

            usuario.CodUsuario=aux.CodUsuario;
            
            return usuario;
        }

        public void delete(int codUsuario) {
            uS.delete(codUsuario);
        }

        public Usuario update(Usuario usuario) {
            WsSOAP.Models.Usuario aux = new WsSOAP.Models.Usuario();

            aux.CodUsuario = usuario.CodUsuario;
            aux.Nombre = usuario.Nombre;
            aux.Apellidos = usuario.Apellidos;
            aux.Dni = usuario.Dni;
            aux.FNacimiento = (DateTime) usuario.FNacimiento;
            aux.Email = usuario.Email;
            aux.Username = usuario.Username;
            aux.Passwd = usuario.Passwd;
            aux=uS.update(aux);
            
            return usuario;
        }

        public string GetVersion() {
            return "v1.0";
        }

    }
}
