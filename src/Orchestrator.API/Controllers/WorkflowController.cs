using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Orchestrator.DataAccess.Models;

namespace Orchestrator.API.Controllers
{
    public class WorkflowController : ControllerBase
    {
        private readonly IMongoCollection<WorkflowModel> _mongoWorkflowCollection;

        public WorkflowController(IMongoCollection<WorkflowModel> mongoWorkflowCollection)
        {
            _mongoWorkflowCollection = mongoWorkflowCollection;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkflowAsync([FromBody] WorkflowModel entity)
        {
            if (entity.Id == ObjectId.Empty)
            {
                entity.Id = ObjectId.GenerateNewId();
            }

            var count = await _mongoWorkflowCollection.CountDocumentsAsync(item => item.Name == entity.Name);

            if (count > 0)
            {
                return BadRequest($"Workflow with name {entity.Name} already exists.");
            }

            await _mongoWorkflowCollection.InsertOneAsync(entity);

            return Ok();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetWorkflowAsync(string name)
        {
            var workflow = await _mongoWorkflowCollection.Find(item => item.Name == name).SingleOrDefaultAsync();

            if (workflow is null)
            {
                return NotFound();
            }

            return Ok(workflow);
        }

        [HttpPost("start/{name}")]
        public async Task<IActionResult> StartWorkflowAsync(string name)
        {

        }
    }
}
