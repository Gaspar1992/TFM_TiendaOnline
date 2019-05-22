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
using TFM_VentaOnline;

namespace TFM_VentaOnline.Controllers
{
    public class accionesController : ApiController
    {
        private venta_onlineEntities db = new venta_onlineEntities();

        // GET: api/acciones
        public IQueryable<acciones> Getacciones()
        {
            return db.acciones;
        }

        // GET: api/acciones/5
        [ResponseType(typeof(acciones))]
        public IHttpActionResult Getacciones(int id)
        {
            acciones acciones = db.acciones.Find(id);
            if (acciones == null)
            {
                return NotFound();
            }

            return Ok(acciones);
        }

        // PUT: api/acciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putacciones(int id, acciones acciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acciones.id)
            {
                return BadRequest();
            }

            db.Entry(acciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accionesExists(id))
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

        // POST: api/acciones
        [ResponseType(typeof(acciones))]
        public IHttpActionResult Postacciones(acciones acciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.acciones.Add(acciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = acciones.id }, acciones);
        }

        // DELETE: api/acciones/5
        [ResponseType(typeof(acciones))]
        public IHttpActionResult Deleteacciones(int id)
        {
            acciones acciones = db.acciones.Find(id);
            if (acciones == null)
            {
                return NotFound();
            }

            db.acciones.Remove(acciones);
            db.SaveChanges();

            return Ok(acciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool accionesExists(int id)
        {
            return db.acciones.Count(e => e.id == id) > 0;
        }
    }
}