using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DataAccessLayer;

namespace AppServiceLayer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpInfoController : ApiController
    {
        private BlogDbContext db = new BlogDbContext();

        // GET: api/EmpInfo
        public IQueryable<EmpInfo> GetEmpInfo()
        {
            return db.EmpInfo;
        }

        // GET: api/EmpInfo/5
        [ResponseType(typeof(EmpInfo))]
        public IHttpActionResult GetEmpInfo(string id)
        {
            EmpInfo empInfo = db.EmpInfo.Find(id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return Ok(empInfo);
        }

        // PUT: api/EmpInfo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpInfo(string id, EmpInfo empInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empInfo.EmailId)
            {
                return BadRequest();
            }

            db.Entry(empInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpInfoExists(id))
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

        // POST: api/EmpInfo
        [ResponseType(typeof(EmpInfo))]
        public IHttpActionResult PostEmpInfo(EmpInfo empInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpInfo.Add(empInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmpInfoExists(empInfo.EmailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = empInfo.EmailId }, empInfo);
        }

        // DELETE: api/EmpInfo/5
        [ResponseType(typeof(EmpInfo))]
        public IHttpActionResult DeleteEmpInfo(string id)
        {
            EmpInfo empInfo = db.EmpInfo.Find(id);
            if (empInfo == null)
            {
                return NotFound();
            }

            db.EmpInfo.Remove(empInfo);
            db.SaveChanges();

            return Ok(empInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpInfoExists(string id)
        {
            return db.EmpInfo.Count(e => e.EmailId == id) > 0;
        }
    }
}