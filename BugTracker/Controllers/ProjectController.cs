using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracker.Controllers
{
    [Route("api/[controller]/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectContext _projectContext;
        public ProjectController(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }


        // GET: api/<ProjectController>
        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProject()
        {
            var projects = _projectContext.project.ToList();
            return Ok(projects);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectByID(int id)
        {
             var project = _projectContext.project.Find(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);

        }

        // POST api/<ProjectController>
        [HttpPost]
        public ActionResult<Project> CreateProject(Project project)
        {
            _projectContext.project.Add(project);
            _projectContext.SaveChanges();

            return CreatedAtAction(nameof(Project), new {id = project.Id}, project);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public ActionResult UpdatedProject(int id, Project updatedProject)
        {
            var project = _projectContext.project.Find(id);
            if(project == null)
            {
                return NotFound();
            }

            project.Name = updatedProject.Name;
            _projectContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id)
        {
            var project = _projectContext.project.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            _projectContext.project.Remove(project);
            _projectContext.SaveChanges();

            return NoContent();
        }
    }
}
