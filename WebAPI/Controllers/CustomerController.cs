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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: api/Customer
        public IQueryable<CM> GetCMS()
        {
            return db.CMS;
        }

        // GET: api/Customer/5
        [ResponseType(typeof(CM))]
        public IHttpActionResult GetCM(int id)
        {
            CM cM = db.CMS.Find(id);
            if (cM == null)
            {
                return NotFound();
            }

            return Ok(cM);
        }

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCM(int id, CM cM)
        {
            

            if (id != cM.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(cM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CMExists(id))
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

        // POST: api/Customer
        [ResponseType(typeof(CM))]
        public IHttpActionResult PostCM(CM cM)
        {
            

            db.CMS.Add(cM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CMExists(cM.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cM.CustomerID }, cM);
        }

        // DELETE: api/Customer/5
        [ResponseType(typeof(CM))]
        public IHttpActionResult DeleteCM(int id)
        {
            CM cM = db.CMS.Find(id);
            if (cM == null)
            {
                return NotFound();
            }

            db.CMS.Remove(cM);
            db.SaveChanges();

            return Ok(cM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CMExists(int id)
        {
            return db.CMS.Count(e => e.CustomerID == id) > 0;
        }
    }
}