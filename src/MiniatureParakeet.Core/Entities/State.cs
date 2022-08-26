using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniatureParakeet.Core.Entities
{
    [Table("state")]
    public class State
    {
        [Key]
        [Column("idstate")]
        [Display(Name = "State ID")]
        public int? IdState { get; set; }

        [Column("namestate")]
        [Display(Name = "State Name")]
        public String NameState { get; set; }

        [Column("acronymstate")]
        [Display(Name = "Acronym")]
        public String AcronymState { get; set; }

        [Column("activestate")]
        [Display(Name = "Active")]
        public bool ActiveState { get; set; }

        [Column("idcountry")]
        [Display(Name = "Country of State")]
        public int? CountryIdCountry { get; set; }

        public Country? Country { get; set; }
    }
}
