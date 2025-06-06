using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Core.DTOs;

public class ProjectTaskCreateRequest
{
    [Required(ErrorMessage = "{0} is required.")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} length must be between {2} and {1} characters.")]
    [DisplayName("Task Description")]
    public string? Name { get; set; }

    [DisplayName("Project")]
    public Guid? ProjectId { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [DisplayName("Task Team")]
    public Guid TeamId { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [DisplayName("Task Status")]
    public TaskStatus Status { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [DisplayName("Scheduled End Date")]
    public DateTime ScheduledEndDate { get; set; }

    [DisplayName("Completion Date")]
    public DateTime? CompletionDate { get; set; }
}
