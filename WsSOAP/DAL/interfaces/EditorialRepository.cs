using System.Collections.Generic;
using WsSOAP.Models;

namespace WsSOAP.DAL.interfaces {
    interface EditorialRepository
        {

        IList<Editorial> getAll();
        IList<Editorial> getAllNoBorrados();
        IList<Editorial> getAllBorrados();
        Editorial getById( int codEditorial );
        Editorial update( Editorial editorial );
        void delete( int codEditorial );
        Editorial create( Editorial editorial );
        }
    }