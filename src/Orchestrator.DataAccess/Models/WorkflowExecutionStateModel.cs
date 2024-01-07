using MongoDB.Bson;
using Orchestrator.DataAccess.Enums;
using Orchestrator.DataAccess.Models.Misc;

namespace Orchestrator.DataAccess.Models;

public class WorkflowExecutionStateModel : BaseModel
{
    public Guid WorkflowId { get; set; }
    public EWorkflowExecutionStatus Status { get; set; }

    public BsonDocument Result { get; set; }

    public ErrorInfo Error { get; set; }

    public bool IsSuccess => Error is null;
}