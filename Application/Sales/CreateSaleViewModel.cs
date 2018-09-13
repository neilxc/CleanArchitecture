using System.Collections.Generic;

namespace Application.Sales
{
    public struct SelectListItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    
    public class CreateSaleViewModel
    {
        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public List<SelectListItem> Products { get; set; }
    }
}