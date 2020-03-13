using appSchool.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace appSchool.Controllers
{
    [RoutePrefix("api/alunos")]
    public class AlunosController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/Alunos
        [HttpGet]
        
        public IQueryable<Aluno> GetAlunos()
        {
            return db.Alunos;
        }

        // GET: api/Alunos/5
        [ResponseType(typeof(Aluno))]
        [HttpGet]
        public IHttpActionResult GetAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Alunos/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("alterar")]
        public IHttpActionResult PutAluno(int id, Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.ID)
            {
                return BadRequest();
            }

            db.Entry(aluno).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Alunos
        [ResponseType(typeof(Aluno))]
        [HttpPost]
        [Route("incluir")]
        public IHttpActionResult PostAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alunos.Add(aluno);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aluno.ID }, aluno);
        }

        // DELETE: api/Alunos/5
        [ResponseType(typeof(Aluno))]
        [HttpDelete]
        [Route("excluir")]
        public IHttpActionResult DeleteAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            db.Alunos.Remove(aluno);
            db.SaveChanges();

            return Ok(aluno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlunoExists(int id)
        {
            return db.Alunos.Count(e => e.ID == id) > 0;
        }
    }
}