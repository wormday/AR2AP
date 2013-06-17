using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(TeamEntityMetadata))]
    partial class TeamEntity
    {
        public class TeamEntityMetadata
        {
            [Required(ErrorMessage = "*")]
            public string Market { get; set; }
            [Required(ErrorMessage = "*")]
            public string Depart { get; set; }
        }
    }
}
