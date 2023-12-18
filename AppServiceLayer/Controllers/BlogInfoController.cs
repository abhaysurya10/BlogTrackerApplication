using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DataAccessLayer;

namespace AppServiceLayer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BlogInfoController : ApiController
    {
        private BlogDbContext db = new BlogDbContext();

        // GET: api/BlogInfo
        public IQueryable<BlogInfo> GetBlogInfo()
        {
            return db.BlogInfo;
        }

        // GET: api/BlogInfo/5
        [ResponseType(typeof(BlogInfo))]
        public IHttpActionResult GetBlogInfo(string id)
        {
            BlogInfo blogInfo = db.BlogInfo.Find(id);
            if (blogInfo == null)
            {
                return NotFound();
            }

            return Ok(blogInfo);
        }

        // PUT: api/BlogInfo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlogInfo(string id, BlogInfo blogInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blogInfo.BlogId)
            {
                return BadRequest();
            }

            db.Entry(blogInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogInfoExists(id))
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

        // POST: api/BlogInfo
        [ResponseType(typeof(BlogInfo))]
        public IHttpActionResult PostBlogInfo(BlogInfo blogInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BlogInfo.Add(blogInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BlogInfoExists(blogInfo.BlogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = blogInfo.BlogId }, blogInfo);
        }

        // DELETE: api/BlogInfo/5
        [ResponseType(typeof(BlogInfo))]
        public IHttpActionResult DeleteBlogInfo(string id)
        {
            BlogInfo blogInfo = db.BlogInfo.Find(id);
            if (blogInfo == null)
            {
                return NotFound();
            }

            db.BlogInfo.Remove(blogInfo);
            db.SaveChanges();

            return Ok(blogInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogInfoExists(string id)
        {
            return db.BlogInfo.Count(e => e.BlogId == id) > 0;
        }
    }
}