using System.Collections.Generic;
using WsSOAP.Models;

namespace WsSOAP.DAL.interfaces {
    public interface AutorRepository
        {

        IList<Autor> getAll();
        IList<Autor> getAllNoBorrados();
        IList<Autor> getAllBorrados();
        Autor getById( int codAutor );
        Autor update( Autor autor );
        void delete( int codAutor );
        Autor create( Autor autor );
        }
    }