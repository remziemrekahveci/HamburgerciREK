using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace feane.Models
{
    public class Discount
    {
        public int ID { get; set; }
        [DisplayName("Food Name")]
        public int? FoodId { get; set; }
        [ForeignKey("FoodId")]
        public Menu Menu { get; set; }
        [DisplayName("Discount Rate")]
        public double DiscountRate { get; set; }//indirim oranı
        [DisplayName("Promotional Price")]
        public double PromotionalPrice { get; set; }
    }
}
