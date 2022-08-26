using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniatureParakeet.Core.Entities
{
    [Table("currency")]
    public class Currency
    {
        [Key]
        [Column("idcurrency")]
        [Display(Name = "Currency ID")]
        public int? IdCurrency { get; set; }

        [Column("acronymcurrency")]
        [Display(Name = "Acronym")]
        public String AcronymCurrency { get; set; }

        [Column("descriptioncurrency")]
        [Display(Name = "Currency Description")]
        public String DescriptionCurrency { get; set; }

        [Column("bacencodecurrency")]
        [Display(Name = "Bacen Code of currency")]
        public String? BacenCodeCurrency { get; set; }

        [Column("statuscurrency")]
        [Display(Name = "Currency status")]
        public bool statusCurrency { get; set; }
    }
}
