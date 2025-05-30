using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Core.Entities;

[Table("OrgAdminMap", Schema = "dbo")]
public class OrgAdminMap : EntityBase
{
    public Guid OrganizationId { get; set; }
    public Guid AdminId { get; set; }
}
