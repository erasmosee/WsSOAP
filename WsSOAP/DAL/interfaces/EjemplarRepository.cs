using WsSOAP.Models;

using System.Collections.Generic;

namespace WsSOAP.DAL.interfaces {
    interface EjemplarRepository
        {

        IList<Ejemplar> getAll();
        IList<Ejemplar> getAllNoBorrados();
        IList<Ejemplar> getAllBorrados();
        Ejemplar getById( int codEjemplar );
        Ejemplar update( Ejemplar ejemplar );
        void delete( int codEjemplar );
        Ejemplar create( Ejemplar ejemplar );
        IList<Ejemplar> getEjemplaresByLibro(int codLibro);
        IList<Ejemplar> getAllEjemplaresByEditorial(int codEditorial);

    }
    }