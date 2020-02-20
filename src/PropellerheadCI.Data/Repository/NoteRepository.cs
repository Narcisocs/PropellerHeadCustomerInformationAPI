using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Models;
using PropellerheadCI.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Data.Repository
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(PropHeadDbContext context) : base(context)
        {

        }
    }
}
