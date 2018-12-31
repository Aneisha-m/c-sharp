using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace deletemerazor_03{
    public class SuppliersModel : PageModel{

        public IEnumerable<string> Suppliers {get;set;}
        public void OnGet(){
            ViewData["Title"]="Suppliers";
            Suppliers = new[] { "Alpha Co", "Beta Limited", "Gamma Corp" };
        }
    }
}