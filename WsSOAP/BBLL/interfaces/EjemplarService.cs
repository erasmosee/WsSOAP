using WsSOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WsSOAP.BBLL.interfaces
{
    public interface EjemplarService
    {

        IList<Ejemplar> getAll();
        IList<Ejemplar> getAllNoBorrados();
        IList<Ejemplar> getAllBorrados();
        Ejemplar getById(int codEjemplar);
        Ejemplar update(Ejemplar ejemplar);
        void delete(int codEjemplar);
        Ejemplar create(Ejemplar ejemplar);
        IList<Ejemplar> getEjemplaresByLibro(int codLibro);
        IList<Ejemplar> getAllEjemplaresByEditorial(int codEditorial);
    }

}