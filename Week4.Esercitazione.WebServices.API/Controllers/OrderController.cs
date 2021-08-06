using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.EsercitazioneWebServices.Core.MainBusinessLayer;
using Week4.EsercitazioneWebServices.Core.Models;

namespace Week4.Esercitazione.WebServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MainBusinessLayer mainBL;

        public OrdersController(MainBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }

        // api/orders
        [HttpGet]
        public IActionResult Get()
        {
            
            var result = mainBL.FetchOrders();

            return Ok(result);
        }

        // api/orders/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");


            var result = mainBL.FetchOrders().First(a => a.Id == id);

            if (result == null)
                return NotFound("Order not found.");

            return Ok(result);
        }

        // api/orders
        [HttpPost]  //costruisco l'ordine
        public IActionResult Post(Order newOrder) 
        {
            if (newOrder == null)
                return BadRequest("Invalid file");

            if (!mainBL.CreateOrder(newOrder))
                return StatusCode(500, "Cannot save file.");

            return CreatedAtAction("order", newOrder);
        }

        // api/order/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, Order updatedOrder)
        {
            if (id <= 0 || updatedOrder == null)
                return BadRequest("No correct parameters");

            if (id != updatedOrder.Id)
                return BadRequest("ID not found");



            if (!mainBL.EditOrder(updatedOrder))
                return StatusCode(404, "not found");



            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid ID");

                var result = mainBL.DeleteOrderById(id);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error executing operation.");
            }
        }
    }
}
