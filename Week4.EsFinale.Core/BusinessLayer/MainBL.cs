using System;
using System.Collections.Generic;
using System.Text;
using Week4.EsFinale.Core.Interfaces;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.Core.BusinessLayer
{
    public class MainBL : IMainBL
    {
        private readonly IOrderRepository orderRepo;
        private readonly ICustomerRepository customerRepo;

        public MainBL(IOrderRepository orderRepo, ICustomerRepository customerRepo
        )
        {
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }

        #region Customers
        //Metodi per i clienti 
        public List<Customer> FetchCustomers()
        {
            return customerRepo.FetchAll();
        }

        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer != null) 
                return customerRepo.Add(newCustomer);
            return false;
        }
        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer != null) 
                return customerRepo.Update(editedCustomer);
            return false;
        }

        public bool DeleteCustomer(Customer customerToBeDeleted)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Orders
        //Metodi per gli ordini
        public bool CreateOrder(Order newOrder)
        {
            if (newOrder != null)
                return orderRepo.Add(newOrder);
            else
                return false;
        }


        public bool EditOrder(Order editedOrder)
        {
            if (editedOrder != null)
                return orderRepo.Update(editedOrder);
            else
                return false;
        }

        public List<Order> FetchOrders()
        {
            return orderRepo.FetchAll();
        }

        public Order GetOrderById(int id)
        {
            return orderRepo.GetById(id);
        }

        public bool DeleteOrder(int id)
        {
            if (id <= 0)
                return false;
            else
                return orderRepo.Delete(id);

        }
        #endregion
    }
}

