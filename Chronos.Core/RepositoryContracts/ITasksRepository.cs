using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Core.RepositoryContracts;

public interface ITasksRepository
{
    Task<ProjectTaskResponse?> GetAllTasks();
}
