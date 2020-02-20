using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerheadCI.Api.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get { return DateTime.Now; } }
        [Required]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters.", MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters.", MinimumLength = 5)]
        public string Surname { get; set; }
        public string Gender { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The field {0} must have between {2} and {1} characters.", MinimumLength = 9)]
        public string Phone { get; set; }

        /* EF Relation */
        public AddressViewModel Address { get; set; }
        public IEnumerable<NoteViewModel> Notes { get; set; }
    }
}
