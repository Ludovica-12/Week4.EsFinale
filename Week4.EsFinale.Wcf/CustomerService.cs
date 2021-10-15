using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.EsFinale.Core.BusinessLayer;
using Week4.EsFinale.Core.Models;
using Week4.EsFinale.EF.Repositories;

namespace Week4.EsFinale.Wcf
{
    public class CustomerService : ICustomerService
    {
        //Implementazione del Service Contract 
        //-> Ci saranno metodi che chiamano metodi del business layer.

        //Vedi fetch come esempio

        private readonly MainBL mainBusinessLayer;

        public CustomerService()
        {
            mainBusinessLayer = new MainBL(
                new EFOrderRepository(),
                new EFCustomerRepository()
            );
        }

        public bool AddCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            var result = mainBusinessLayer.FetchCustomers().ToList();
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer updatedCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
