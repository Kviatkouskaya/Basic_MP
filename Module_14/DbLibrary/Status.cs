using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLibrary
{
    public enum Status
    {
        NotStarted = 0,
        Loading = 1,
        InProgress = 2,
        Arrived = 3,
        Unloading = 4,
        Cancelled = 5,
        Done = 6
    }
}
