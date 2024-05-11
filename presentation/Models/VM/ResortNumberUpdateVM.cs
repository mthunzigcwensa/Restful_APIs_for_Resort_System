using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using presentation.Models.Dto;

namespace presentation.Models.VM
{
    public class ResortNumberUpdateVM
    {
        public ResortNumberUpdateVM()
        {
            ResortNumber = new ResortNumberUpdateDTO();
        }
        public ResortNumberUpdateDTO ResortNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ResortsList { get; set; }
    }
}
