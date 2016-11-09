using WsSOAP.BBLL.interfaces;
using System.Collections.Generic;
using WsSOAP.Models;
using WsSOAP.DAL.interfaces;
using WsSOAP.DAL;

namespace WsSOAP.BBLL {
    public class AutorServiceImp : AutorService {

        private AutorRepository aRepo = new AutorRepositoryImp();

        public Autor create(Autor autor) {
            return aRepo.create(autor);
        }

        public void delete(int codAutor) {
            aRepo.delete(codAutor);
        }

        public IList<Autor> getAll() {
            return aRepo.getAll();
        }

        public IList<Autor> getAllBorradso() {
            return aRepo.getAllBorrados();
        }

        public IList<Autor> getAllNoBorrados() {
            return aRepo.getAllNoBorrados();
        }

        public Autor getById(int codAutor) {
            return aRepo.getById(codAutor);
        }

        public Autor update(Autor autor) {
            return aRepo.update(autor);
        }
    }
}