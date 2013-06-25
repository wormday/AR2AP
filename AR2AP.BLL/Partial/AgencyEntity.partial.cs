using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(AgencyEntityMetadata))]
    public partial class AgencyEntity
    {


        private class AgencyEntityMetadata
        {
            [Required(ErrorMessage = "*")]
            public object AgencyName { get; set; }
            [Required(ErrorMessage = "*")]
            public object CurrencyType { get; set; }
        }
    }
}
