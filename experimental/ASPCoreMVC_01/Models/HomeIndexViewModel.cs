using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ASPCoreMVC_01.Models
{
    public class HomeIndexViewModel
    {

        public int VisitorCount;
        
        public IList<NorthwindLibrary.Category> Categories { get; set; }

        public IList<NorthwindLibrary.Product> Products { get; set; }
    }
}
