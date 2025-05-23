
using System.ComponentModel.DataAnnotations.Schema;

namespace Chronos.Core.Entities;

[Table("Organizations", Schema = "dbo")]
public class Organization : EntityBase
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Address { get; set; }
}
