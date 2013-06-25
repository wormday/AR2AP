using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(AgencyEntityMetadata))]
    partial class AgencyEntity
    {
        public CurrencyTypeEnum CurrencyTypeEnum {
            get { return (CurrencyTypeEnum)this.CurrencyType; }
            set { this.CurrencyType = (byte)value; }
        }

        public class AgencyEntityMetadata
        {
            [Required(ErrorMessage = "*")]
            public object AgencyName { get; set; }
            [Required(ErrorMessage = "*")]
            public object CurrencyType { get; set; }
        }
    }
}
