
using System.ComponentModel.DataAnnotations.Schema;

namespace Chronos.Core.Entities;

[Table("Teams", Schema = "dbo")]
public class Team : EntityBase
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid OrganizationId { get; set; }
}
