using Chronos.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Chronos.Core.DTOs;

public class ProjectCreateRequest
{
    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} length must be between {2} and {1} characters.")]
    [DisplayName("Project Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [DisplayName("Project Team")]
    public Guid TeamId { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [DisplayName("Scheduled End Date")]
    public DateTime ScheduledEndDate { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [DisplayName("Project Status")]
    public ProjectStatus Status { get; set; }

    [DisplayName("Completion Date")]
    public DateTime? CompletionDate { get; set; }
}
