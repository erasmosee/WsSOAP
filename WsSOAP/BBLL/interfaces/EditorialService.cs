using WsSOAP.Models;
using System.Collections.Generic;

namespace WsSOAP.BBLL.interfaces {
    public interface EditorialService
    {

        IList<Editorial> getAll();
        IList<Editorial> getAllNoBorrados();
        IList<Editorial> getAllBorrados();
        Editorial getById(int codEditorial);
        Editorial update(Editorial editorial);
        void delete(int codEditorial);
        Editorial create(Editorial editorial);
    }
}
