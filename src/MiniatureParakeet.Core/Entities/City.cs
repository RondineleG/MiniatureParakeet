using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniatureParakeet.Core.Entities
{
    [Table("city")]
    public class City
    {
        [Key]
        [Column("idcity")]
        [Display(Name = "City ID")]
        public int? IdCity { get; set; }

        [Column("namecity")]
        [Display(Name = "Name")]
        public String NameCity { get; set; }

        [Column("ibgecodecity")]
        [Display(Name = "IBGE Code")]
        public String IbgeCodeCity { get; set; }

        [Column("inttracodecity")]
        [Display(Name = "INTTRA Code")]
        public String? InttraCodeCity { get; set; }

        [Column("activecity")]
        [Display(Name = "Active")]
        public bool ActiveCity { get; set; }

        [Column("idstate")]
        [Display(Name = "State of City")]
        public int? StateIdState { get; set; }

        public State? State { get; set; }

    }
}
