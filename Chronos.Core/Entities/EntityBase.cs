
namespace Chronos.Core.Entities;

public class EntityBase
{
    public string? IsActive { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
}
