using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using TFM_VentaOnline.Classes;


namespace TFM_VentaOnline.Controllers
{
    public class usuariosController : ApiController
    {
        private venta_onlineEntities db = new venta_onlineEntities();

        // GET: api/usuarios
        public IQueryable<usuarios> Getusuarios()
        {
            return db.usuarios;
        }

        
        // GET: api/usuarios/5
        [ResponseType(typeof(usuarios))]
        public IHttpActionResult Getusuarios(int id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        // PUT: api/usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putusuarios(int id, usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.id)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuariosExists(id))
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

        // POST: api/usuarios
        [ResponseType(typeof(usuarios))]
        public IHttpActionResult Postusuarios(usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarios.constrasenya = MD5Actions.getMd5Hash(usuarios.constrasenya);

            db.usuarios.Add(usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuarios.id }, usuarios);
        }

        /*
         * 
        [HttpPost]
        [ResponseType(typeof(usuarios))]
        // POST: api/usuarios/login
        public IHttpActionResult Login(string email, string password)
        {

            usuarios usuarios = db.usuarios.FirstOrDefault(u => u.email == email && u.constrasenya == MD5Actions.getMd5Hash(password));

            if (usuarios == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            return Ok(usuarios);
        }
         * 
         * */
        // DELETE: api/usuarios/5
        [ResponseType(typeof(usuarios))]
        public IHttpActionResult Deleteusuarios(int id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuariosExists(int id)
        {
            return db.usuarios.Count(e => e.id == id) > 0;
        }
    }
}