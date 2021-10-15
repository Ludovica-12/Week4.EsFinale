using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.EsFinale.Core.Interfaces;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly OrderContext ctx;

        public EFCustomerRepository() : this(new OrderContext())
        {

        }

        public EFCustomerRepository(OrderContext ctx)
        {
            this.ctx = ctx;
        }


        public bool Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
