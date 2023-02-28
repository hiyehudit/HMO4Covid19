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
using WebApi.DAL;

namespace WebApi.Controllers
{
    public class ClientsController : ApiController
    {
        private HMO4Covid19_dbEntities db = new HMO4Covid19_dbEntities();

        // GET: api/Clients
        public IQueryable<Person> GetClient()
        {
            return db.People;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetClient(string id)
        {
            Person client = db.People.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(string id, Person client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.tz)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostClient(Person client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(client);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClientExists(client.tz))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = client.tz }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeleteClient(string id)
        {
            Person client = db.People.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.People.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(string id)
        {
            return db.People.Count(e => e.tz == id) > 0;
        }
    }
}