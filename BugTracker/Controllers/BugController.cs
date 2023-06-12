using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly BugContext _bugContext;
        public BugController(BugContext bugContext)
        {
            _bugContext = bugContext;
        }


        // GET: api/<BugController>
        [HttpGet]
        public ActionResult<IEnumerable<Bug>> GetBug()
        {
            var bugs = _bugContext.Bug.ToList();
            return Ok(bugs);
        }

        // GET api/<BugController>/5
        [HttpGet("{id}")]
        public ActionResult<Bug> GetBugByID(Guid id)
        {
             var bug = _bugContext.Bug.Find(id);

            if(bug == null)
            {
                return NotFound();
            }

            return Ok(bug);

        }

        // POST api/<BugController>
        [HttpPost]
        public ActionResult<Bug> CreateBug(Bug bug)
        {
            Console.WriteLine(bug);
            _bugContext.Bug.Add(bug);
            _bugContext.SaveChanges();

            return CreatedAtAction(nameof(Bug), new {id = bug.Id}, bug);
        }

        // PUT api/<BugController>/5
        [HttpPut("{id}")]
        public ActionResult UpdatedBug(int id, Bug updatedBug)
        {
            var Bug = _bugContext.Bug.Find(id);
            if(Bug == null)
            {
                return NotFound();
            }

            Bug.Project = updatedBug.Project;
            Bug.Priority = updatedBug.Priority;
            Bug.Type = updatedBug.Type;
            Bug.State = updatedBug.State;
            Bug.Assignee = updatedBug.Assignee;
            Bug.Reporter = updatedBug.Reporter;
            Bug.Summary = updatedBug.Summary;
            Bug.Description = updatedBug.Description;
            Bug.Date = updatedBug.Date;
            _bugContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/<BugController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteBug(int id)
        {
            var bug = _bugContext.Bug.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            _bugContext.Bug.Remove(bug);
            _bugContext.SaveChanges();

            return NoContent();
        }
    }
}
