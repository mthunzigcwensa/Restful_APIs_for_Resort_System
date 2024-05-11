using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using presentation.Models.Dto;

namespace presentation.Models.VM
{
    public class ResortNumberDeleteVM
    {
        public ResortNumberDeleteVM()
        {
            ResortNumber = new ResortNumberDTO();
        }
        public ResortNumberDTO ResortNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ResortsList { get; set; }
    }
}
