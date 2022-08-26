using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniatureParakeet.Core.Entities
{
    [Table("terminal")]
    public class Terminal
    {
        [Key]
        [Column("idterminal")]
        public int IdTerminal { get; set; }

        [Column("nameterminal")]
        [Required]
        public string NameTerminal { get; set; }


        [Column("cnpjterminal")]
        public string CNPJTerminal { get; set; }

        [Column("idcity")]
        public int CityIdCity { get; set; }

        [NotMapped]
        public City? City { get; set; }

        [Column("addressterminal")]
        public string AddressTerminal { get; set; }


        [Column("activeterminal")]
        public bool ActiveTerminal { get; set; }

        [Column("specificinstructionterminal")]
        [MaxLength(100)]
        public string? SpecificInstructionTerminal { get; set; }

        [Column("generalobservationterminal")]
        [MaxLength(100)]
        public string? GeneralObservationTerminal { get; set; }


        [Column("stateregistrationterminal")]
        public string? StateRegistrationTerminal { get; set; }

        [Column("municipalregistrationterminal")]
        public string? MunicipalRegistrationTerminal { get; set; }

        [Column("zipcodeterminal")]
        public string? ZipcodeTerminal { get; set; }
    }
}
