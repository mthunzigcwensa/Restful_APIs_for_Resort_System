using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using presentation.Models.Dto;

namespace presentation.Models.VM
{
    public class ResortNumberCreateVM
    {
        public ResortNumberCreateVM()
        {
            ResortNumber = new ResortNumberCreateDTO();
        }
        public ResortNumberCreateDTO ResortNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ResortsList { get; set; }
    }
}
