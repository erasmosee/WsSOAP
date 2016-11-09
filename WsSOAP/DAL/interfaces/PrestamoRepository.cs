using WsSOAP.Models;

using System.Collections.Generic;

namespace WsSOAP.DAL.interfaces {
    interface PrestamoRepository
        {

        IList<Prestamo> getAll();
        Prestamo getById( int codPrestamo );
        IList<Prestamo> getAllPrestamosByUsuario(int codUsuario);
        IList<Prestamo> getByEjemplarPrestamo(int codEjemplar);
        Prestamo update( Prestamo prestamo );
        void delete( int codPrestamo );
        Prestamo create( Prestamo prestamo );
        }
    }