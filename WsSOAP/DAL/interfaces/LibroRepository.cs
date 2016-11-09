using WsSOAP.Models;

using System.Collections.Generic;

namespace WsSOAP.DAL.interfaces {
    interface LibroRepository
        {

        IList<Libro> getAll();
        IList<Libro> getAllNoBorrados();
        IList<Libro> getAllBorrados();
        Libro getById( int codLibro );
        Libro update( Libro libro );
        void delete( int codLibro );
        Libro create( Libro libro );
        IList<Libro> getAllLibrosByAutor(int codAutor);
    }
    }