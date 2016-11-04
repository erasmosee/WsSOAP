using System.Collections.Generic;
using System;
using WsSOAP.BBLL.interfaces;
using WsSOAP.DAL.interfaces;
using WsSOAP.Models;
using WsSOAP.DAL;

namespace WsSOAP.BBLL {
    public class UsuarioServiceImp : UsuarioService {

        private UsuarioRepository uRepo = new UsuarioRepositoryImp();

        public Usuario create( Usuario usuario ){
            return uRepo.create(usuario);
        }

        public void delete(int codUsuario) {
            uRepo.delete(codUsuario);
        }

        public IList<Usuario> getAll() {
            return uRepo.getAll();
        }

        public IList<Usuario> getAllBorrados() {
            return uRepo.getAllBorrados();
        }

        public IList<Usuario> getAllNoBorrados() {
            return uRepo.getAllNoBorrados();
        }

        public Usuario getById(int codUsuario) {
            return uRepo.getById(codUsuario);
        }

        public int getByUsernameUsuario(string username, string passwd) {
            return uRepo.getByUsernameUsuario(username, passwd);
        }

        public Usuario update(Usuario usuario) {
            return uRepo.update(usuario);
        }
    }
}