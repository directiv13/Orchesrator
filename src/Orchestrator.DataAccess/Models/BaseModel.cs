using MongoDB.Bson;

namespace Orchestrator.DataAccess.Models;

public class BaseModel
{
    public ObjectId Id { get; set; }
}