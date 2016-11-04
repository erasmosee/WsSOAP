using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsSOAP.Models;

namespace WsSOAP.BBLL.interfaces {
    public interface UsuarioService {
        IList<Usuario> getAll();
        IList<Usuario> getAllNoBorrados();
        IList<Usuario> getAllBorrados();
        Usuario getById(int codUsuario);
        int getByUsernameUsuario(string username, string passwd);
        Usuario update(Usuario usuario);
        void delete(int codUsuario);
        Usuario create(Usuario usuario);
    }
}
