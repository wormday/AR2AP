using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AR2AP.BLL;

namespace AR2AP.WebApp.Models.AR
{
    public class AddVModel
    {
        public AddVModel()
        {
            AREntity = new AREntity();
            AREntity.CompaignEnd = DateTime.Today;
            AREntity.CompaignStart = DateTime.Today;
            AREntity.DueDate = DateTime.Today;
            AREntity.RevenueConfirmationDate = DateTime.Today;
            AREntity.InvoiceDate = null;
        }
        public AREntity AREntity { get; set; }
    }
}