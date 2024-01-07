using MongoDB.Bson;
using Orchestrator.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace Orchestrator.DataAccess.Models;

public class TaskModel : BaseModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string ReferenceName { get; set; }

    [Required]
    public BsonDocument InputParameters { get; set; }

    [Required]
    public ETaskType Type { get; set; }
}