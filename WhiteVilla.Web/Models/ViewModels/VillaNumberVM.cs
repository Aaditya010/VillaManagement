using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteVilla.Domain.Entities;

namespace WhiteVilla.Web.Models.ViewModels
{
    public class VillaNumberVM
    {
        public VillaNumber? VillaNumber { get; set; }

        [ValidateNever]
        public IEnumerable <SelectListItem>? VillaList { get; set; }
    }
}
