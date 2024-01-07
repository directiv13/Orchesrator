using System.ComponentModel.DataAnnotations;

namespace Orchestrator.DataAccess.Models;

public class WorkflowModel : BaseModel
{
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<string>? InputParameters { get; set; }
    public Dictionary<string, string>? OutputParameters { get; set; }

    [Required]
    public List<TaskModel> Tasks { get; set; }
}
