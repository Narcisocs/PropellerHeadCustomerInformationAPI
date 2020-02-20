using Microsoft.AspNetCore.Mvc;
using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerheadCI.Api.ViewModels
{
    public class NoteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters.", MinimumLength = 2)]
        public string Message { get; set; }

        [HiddenInput]
        public Guid CustomerId { get; set; }
    }
}
