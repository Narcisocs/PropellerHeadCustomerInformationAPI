using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropellerheadCI.Api.ViewModels;
using PropellerheadCI.Business.Interfaces;
using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerheadCI.Api.Controllers
{
    [Route("api/notes")]
    public class NotesController : MainController
    {
        private readonly INoteRepository _noteRepository;
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public NotesController(INoteRepository noteRepository, 
                                INoteService noteService,
                                IMapper mapper,
                                INotifier notifier) : base(notifier)
        {
            _noteRepository = noteRepository;
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<NoteViewModel>> AddNote(NoteViewModel noteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _noteService.Add(_mapper.Map<Note>(noteViewModel));

            return CustomResponse(noteViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CustomerViewModel>> UpdateNote(Guid id, NoteViewModel noteViewModel)
        {
            if (id != noteViewModel.Id)
            {
                NotificarErro("The id informed is not the same as the one in the url.");
                return CustomResponse(noteViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _noteService.Update(_mapper.Map<Note>(noteViewModel));

            return CustomResponse(noteViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<NoteViewModel>> Delete(Guid id)
        {
            var noteViewModel = await GetNoteById(id);

            if (noteViewModel == null) return NotFound();

            await _noteService.Remove(id);

            return CustomResponse(noteViewModel);
        }

        public async Task<NoteViewModel> GetNoteById(Guid id)
        {
            return _mapper.Map<NoteViewModel>(await _noteRepository.GetById(id));
        }
    }
}
