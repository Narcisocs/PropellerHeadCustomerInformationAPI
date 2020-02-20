using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Models;
using PropellerheadCI.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropellerheadCI.Business.Services
{
    public class NoteService : BaseService, INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository,
                               INotifier notifier) : base(notifier)
        {
            _noteRepository = noteRepository;
        }

        public async Task Add(Note note)
        {
            if (!ExecuteValidation(new NoteValidations(), note)) return;

            await _noteRepository.Add(note);
        }

        public async Task Update(Note note)
        {
            if (!ExecuteValidation(new NoteValidations(), note)) return;

            await _noteRepository.Update(note);
        }

        public async Task Remove(Guid id)
        {
            await _noteRepository.Delete(id);
        }

        public void Dispose()
        {
            _noteRepository?.Dispose();
        }
    }
}
