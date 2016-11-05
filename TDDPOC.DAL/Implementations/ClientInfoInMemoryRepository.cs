using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDPOC.DAL.Contracts;
using TDDPOC.DAL.Entities;

namespace TDDPOC.DAL.Implementations
{
    public class ClientInfoInMemoryRepository : IClientInfoRepository
    {
        private IList<ClientInfoEntity> _mockClients;
        public IList<ClientInfoEntity> GetAll()
        {
            return _mockClients;
        }

        public ClientInfoEntity GetByID(int id)
        {
            ClientInfoEntity resultClient = null;
            var clients = from ClientInfoEntity c in _mockClients where c.ClientInfoID == id select c;
            if(clients!=null && clients.Count()>0)
            {
                resultClient = clients.FirstOrDefault();
            }
            return resultClient;
        }

        public void Seed(IList<ClientInfoEntity> mockClients)
        {
            if (mockClients == null) throw new ArgumentNullException("Dependency not met (IList<ClientInfoEntity>)");
            _mockClients = mockClients;
        }
        
    }
}
