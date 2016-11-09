using WsSOAP.BBLL.interfaces;
using System.Collections.Generic;
using WsSOAP.Models;
using WsSOAP.DAL.interfaces;
using WsSOAP.DAL;

namespace WsSOAP.BBLL {
    public class EditorialServiceImp : EditorialService {

        private EditorialRepository eRepo = new EditorialRepositoryImp();

        public Editorial create(Editorial editorial) {
            return eRepo.create(editorial);
        }

        public void delete(int codEditorial) {
            eRepo.delete(codEditorial);
        }

        public IList<Editorial> getAll() {
            return eRepo.getAll();
        }

        public IList<Editorial> getAllBorrados() {
            return eRepo.getAllBorrados();
        }

        public IList<Editorial> getAllNoBorrados() {
            return eRepo.getAllNoBorrados();
        }

        public Editorial getById(int codEditorial) {
            return eRepo.getById(codEditorial);
        }

        public Editorial update(Editorial editorial) {
            return eRepo.update(editorial);
        }
    }
}