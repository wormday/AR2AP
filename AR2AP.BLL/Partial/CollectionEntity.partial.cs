using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(CollectionEntityMetadata))]
    partial class CollectionEntity
    {
        private class CollectionEntityMetadata
        {
            [Display(Name = "ID")]
            public object CollectionID { get; set; }
            [Display(Name = "Client")]
            public object ClientID { get; set; }
            [Display(Name = "Collection Date")]
            [Required(ErrorMessage = "*")]
            public object CollectionDate { get; set; }
            [Display(Name = "Agency")]
            [Required(ErrorMessage = "*")]
            public object AgencyID { get; set; }
            [Display(Name = "Amount")]
            [Required(ErrorMessage = "*")]
            public object CollectionAmount { get; set; }
            [Display(Name = "Remark")]
            public object CollectionRemark { get; set; }
        }
    }
}
