using Orchestrator.DataAccess.Models;

namespace Orchestrator.Decider.Interfaces
{
    public interface IExecutionService
    {
        Task<WorkflowExecutionStateModel> GetExecutionStatusAsync(Guid workflowId);
    }
}
