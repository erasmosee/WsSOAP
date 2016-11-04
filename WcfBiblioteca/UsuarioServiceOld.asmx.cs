using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WsSOAP.BBLL;

namespace WcfBiblioteca {
    /// <summary>
    /// Summary description for UsuarioServiceOld
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UsuarioServiceOld : System.Web.Services.WebService {
        WsSOAP.BBLL.interfaces.UsuarioService uS;

        public UsuarioServiceOld() {
            uS = new UsuarioServiceImp();
        }

        public string GetVersion() {
            return "v1.0";
        }

        [WebMethod]
        public UsuarioWS GetUsuarioById(int codUsuario){
            UsuarioWS usuario = null;
            WsSOAP.Models.Usuario aux = uS.getById(codUsuario);
            usuario = new UsuarioWS();

            if(uS==null) {
                usuario.ErrorMessage = "Usuario no encontrado.";
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


        [WebMethod]
        public List<UsuarioWS> GetAllUsuarios(){
            UsuarioWS usuario = null; 
            List<UsuarioWS> usuarios = null;
            IList<WsSOAP.Models.Usuario> aux = uS.getAll();
            usuario = new UsuarioWS();
            usuarios = new List<UsuarioWS>();

            if(aux==null) {
                usuario.ErrorMessage = "No se encuentran usuarios.";
            } else {
                foreach(var item in aux) {
                    usuario = new UsuarioWS();
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

        [WebMethod]
        public List<UsuarioWS> GetAllUsuariosNoBorrados(){
            UsuarioWS usuario = null; 
            List<UsuarioWS> usuarios = null;
            IList<WsSOAP.Models.Usuario> aux = uS.getAllNoBorrados();
            usuario = new UsuarioWS();
            usuarios = new List<UsuarioWS>();

            if(aux==null) {
                usuario.ErrorMessage = "No se encuentran usuarios.";
            } else {
                foreach(var item in aux) {
                    usuario = new UsuarioWS();
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

        [WebMethod]
        public List<UsuarioWS> GetAllUsuariosBorrados(){
            UsuarioWS usuario = null; 
            List<UsuarioWS> usuarios = null;
            IList<WsSOAP.Models.Usuario> aux = uS.getAllBorrados();
            usuario = new UsuarioWS();
            usuarios = new List<UsuarioWS>();

            if(aux==null) {
                usuario.ErrorMessage = "No se encuentran usuarios.";
            } else {
                foreach(var item in aux) {
                    usuario = new UsuarioWS();
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

        [WebMethod]
        public UsuarioWS delete(int codUsuario) {
            UsuarioWS usuario = null;
            WsSOAP.Models.Usuario aux = uS.getById(codUsuario);

            if(aux == null) {
                usuario = new UsuarioWS();
                usuario.ErrorMessage = "Usuario no encontrado.";
            } else {
                uS.delete(codUsuario);
            }

            return usuario;   
        }

        [WebMethod]
        public UsuarioWS create(UsuarioWS usuario) {
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

        [WebMethod]
        public UsuarioWS update(UsuarioWS usuario) {
            WsSOAP.Models.Usuario aux = new WsSOAP.Models.Usuario();

            aux.CodUsuario = usuario.CodUsuario.Value;
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
    }
}
