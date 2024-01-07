namespace Orchestrator.Decider.Interfaces
{
    public interface IDeciderService
    {
        Task StartWorkflowAsync(Guid id);
    }
}
