using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourTimeSheet.SharedModels
{
    public interface TestTaskCreated
    {
        Guid Id { get; set; }
        string TaskName { get; set; }
    }
}
