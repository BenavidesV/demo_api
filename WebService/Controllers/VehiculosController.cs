using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebService.Models;

namespace WebService.Controllers
{
    public class VehiculosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Vehiculos
        public IQueryable<Vehiculo> GetVehiculos()
        {
            return db.Vehiculos;
        }

        // GET: api/Vehiculos/5
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult GetVehiculo(int id)
        {
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }

        // PUT: api/Vehiculos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehiculo.Id)
            {
                return BadRequest();
            }

            db.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vehiculos
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult PostVehiculo(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehiculos.Add(vehiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehiculo.Id }, vehiculo);
        }

        // DELETE: api/Vehiculos/5
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult DeleteVehiculo(int id)
        {
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            db.Vehiculos.Remove(vehiculo);
            db.SaveChanges();

            return Ok(vehiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehiculoExists(int id)
        {
            return db.Vehiculos.Count(e => e.Id == id) > 0;
        }
    }
}