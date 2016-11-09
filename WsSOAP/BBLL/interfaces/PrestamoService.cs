using WsSOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsSOAP.BBLL.interfaces
{
    public interface PrestamoService
    {

        IList<Prestamo> getAll();
        Prestamo getById(int codPrestamo);
        IList<Prestamo> getAllPrestamosByUsuario(int codUsuario);
        IList<Prestamo> getByEjemplarPrestamo(int codEjemplar);
        Prestamo update(Prestamo prestamo);
        void delete(int codPrestamo);
        Prestamo create(Prestamo prestamo);
    }
}
