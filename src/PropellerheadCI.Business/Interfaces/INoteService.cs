using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropellerheadCI.Business.Interfaces
{
    public interface INoteService : IDisposable
    {
        Task Add(Note note);
        Task Update(Note note);
        Task Remove(Guid id);
    }
}
