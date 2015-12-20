using Nimble.Data.Infrastructure;
using Nimble.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Data.Repository
{
  
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {

        public AddressRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }


        public IEnumerable<Address> GetAddress()
        {

            var Address = this.GetAll();

           
            return Address.ToList();
        }
    }

    public interface IAddressRepository : IRepository<Address>
    {
      
        IEnumerable<Address> GetAddress();
    }

}
