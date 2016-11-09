using WsSOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsSOAP.BBLL.interfaces
{
    public interface LibroService
    {

        IList<Libro> getAll();
        Libro getById(int codLibro);
        IList<Libro> getAllLibrosByAutor(int codAutor);
        IList<Libro> getAllNoBorrados();
        IList<Libro> getAllBorrados();
        Libro update(Libro libro);
        void delete(int codLibro);
        Libro create(Libro libro);
    }
}
