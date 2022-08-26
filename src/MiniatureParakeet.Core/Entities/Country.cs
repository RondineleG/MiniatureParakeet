using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniatureParakeet.Core.Entities
{
    [Table("country")]
    public class Country
    {
        [Key]
        [Column("idcountry")]
        [Display(Name = "Country ID")]
        public int? IdCountry { get; set; }

        [Column("namecountry")]
        [Display(Name = "Country Name")]
        public String NameCountry { get; set; }

        [Column("translatednamecountry")]
        [Display(Name = "Translated Country Name")]
        public String TranslatedNameCountry { get; set; }

        [Column("acronymcountry")]
        [Display(Name = "Acronym")]
        public String Acronym { get; set; }

        [Column("nifcountry")]
        [Display(Name = "Nif")]
        public bool Nif { get; set; }

        [Column("taxedcountry")]
        [Display(Name = "Taxed")]
        public bool Taxed { get; set; }

        [Column("idcurrency")]
        [Display(Name = "Currency of Country")]
        public int? CurrencyIdCurrency { get; set; }

        public Currency? Currency { get; set; }
    }
}
