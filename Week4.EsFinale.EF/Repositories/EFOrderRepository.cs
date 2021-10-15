using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.EsFinale.Core.Interfaces;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.EF.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly OrderContext ctx;

        public EFOrderRepository() : this(new OrderContext())
        {

        }

        public EFOrderRepository(OrderContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Order item)
        {
            try
            {
                ctx.Orders.Add(item);
                return Convert.ToBoolean(ctx.SaveChanges());
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                ctx.Orders.Remove(ctx.Orders.Find(id));
                return Convert.ToBoolean(ctx.SaveChanges());
            }
            catch
            {

                return false;
            }
        }

        public List<Order> FetchAll()
        {
            try
            {
                return ctx.Orders.ToList();
            }
            catch
            {

                return new List<Order>();
            }
        }

        public Order GetById(int id)
        {
            try
            {
                return ctx.Orders.Find(id);
            }
            catch
            {

                return null;
            }
        }

        public bool Update(Order item)
        {
            try
            {
                var orderbyid = ctx.Orders.Find(item.OrderId);
                orderbyid.DataOrdine = item.DataOrdine;
                orderbyid.CodiceOrdine = item.CodiceOrdine;
                orderbyid.CodiceProdotto = item.CodiceProdotto;
                orderbyid.Importo = item.Importo;
                orderbyid.Cliente = item.Cliente;

                return Convert.ToBoolean(ctx.SaveChanges());
            }
            catch
            {



                return false;
            }
        }
    }
}
