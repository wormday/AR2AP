using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(ClientEntityMetadata))]
    partial class ClientEntity
    {
        public ClientTypeEnum ClientTypeEnum
        {
            get { return (ClientTypeEnum)ClientType; }
            set { this.ClientType = (byte)value; }
        }

        public class ClientEntityMetadata
        {
            [Required(ErrorMessage = "*")]
            public object ClientType { get; set; }
            [Required(ErrorMessage = "*")]
            public object ClientGroup { get; set; }
            [Required(ErrorMessage = "*")]
            public object ClientName { get; set; }
        }
    }
}
