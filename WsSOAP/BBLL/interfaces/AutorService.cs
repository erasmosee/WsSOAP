using System.Collections.Generic;
using WsSOAP.Models;

namespace WsSOAP.BBLL.interfaces {
    public interface AutorService
    {
        IList<Autor> getAll();
        IList<Autor> getAllNoBorrados();
        IList<Autor> getAllBorradso();
        Autor getById(int codAutor);
        Autor update(Autor autor);
        void delete(int codAutor);
        Autor create(Autor autor);
    }
}
