using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.EsFinale.Core.Interfaces;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMainBL mainBusinessLayer;

        public OrderController(IMainBL mainBusinessLayer)
        {
            this.mainBusinessLayer = mainBusinessLayer;
        }

        //Implementare le action -> chiamano metodi del business layer

        //Esempio nella GetOrders

        // GET: api/Order
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = mainBusinessLayer.FetchOrders();
            return Ok(orders);
        }

        // GET api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetOrderBy(int id)
        {
            if (id <= 0)
                return BadRequest("Errore body non valido");
            var v = mainBusinessLayer.GetOrderById(id);
            if (v != null)
                return Ok(v);
            else
                return StatusCode(502, "Errore server side");
        }

        // POST api/order
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Body non valido");
            if (!mainBusinessLayer.CreateOrder(order))
                return StatusCode(502, "Errore server side");
            else
                return CreatedAtAction("AddOrdine", order);
        }

        // PUT api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (id <= 0 || order == null || id != order.OrderId)
                return BadRequest("Errore");
            if (mainBusinessLayer.EditOrder(order))
                return StatusCode(204);
            else
                return StatusCode(502, "Errore server side");
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Errore bosy non valido");
            if (mainBusinessLayer.DeleteOrder(id))
                return StatusCode(204);
            else
                return StatusCode(502, "Errore server side");
        }

        
    }
}
