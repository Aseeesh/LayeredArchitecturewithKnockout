using Nimble.Data.Infrastructure;
using Nimble.Data.Repository;
using Nimble.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimble.Services.Services
{
    
     public interface IAddressService
    {
        IEnumerable<Address> GetAddresss();
        //  IEnumerable<Address> GetActiveAddress();

        Address GetAddress(int id);
        void CreateAddress(Address Address);
        void EditAddress(Address AddressToEdit);
        void DeleteAddress(int id);
        void SaveAddress();
        //  IEnumerable<Address> SearchAddress(string Address);

    }

    public class AddressService : IAddressService
    {
        private readonly IAddressRepository AddressRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddressService(IAddressRepository AddressRepository, IUnitOfWork unitOfWork)
        {
            this.AddressRepository = AddressRepository;
            this.unitOfWork = unitOfWork;
        }


        #region IAddressService Members
        public IEnumerable<Address> GetAddresss()

        {
            var Address = AddressRepository.GetAddress();
            return Address;
        }


        //public IEnumerable<Address> GetActiveAddress()
        //{
        //    var Address = AddressRepository.GetMany(g => (g.Status == true));
        //    return Address;
        //}
        //public IEnumerable<Address> SearchAddress(string Address)
        //{
        //    return AddressRepository.GetMany(g => g.LinkText.ToLower().Contains(Address.ToLower()) && g.Status == true).OrderBy(g => g.Id);
        //}
        public Address GetAddress(int id)
        {
            var Address = AddressRepository.GetById(id);
            return Address;
        }
        public void CreateAddress(Address Address)
        {
            AddressRepository.Add(Address);
            SaveAddress();
        }
        public void DeleteAddress(int id)
        {
            var Address = AddressRepository.GetById(id);
            AddressRepository.Delete(Address);
            SaveAddress();
        }
        public void EditAddress(Address AddressToEdit)
        {
            AddressRepository.Update(AddressToEdit);
            SaveAddress();
        }
        public void SaveAddress()
        {
            unitOfWork.Commit();
        }

        #endregion
    }

}
