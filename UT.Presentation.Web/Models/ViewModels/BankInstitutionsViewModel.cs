using System.Collections.Generic;
using System.Web;
using UT.Domain.Entities;

namespace UT.Presentation.Web.Models.ViewModels
{
    public class BankInstitutionsViewModel
    {
        public HtmlString Title { get; set; }
        public HtmlString InstitutionLabel { get; set; }
        public HtmlString AccountNumberLabel { get; set; }
        public HtmlString EditLabel { get; set; }
        public HtmlString DeleteLabel { get; set; }
        public HtmlString AddLabel { get; set; }
        public HtmlString AddAnotherLabel { get; set; }
        public HtmlString AccountMaskText { get; set; }
        public HtmlString EndingText { get; set; }
        public HtmlString AutopayText { get; set; }
        public List<BankAccount> BankInstitutions { get; set; }
    }
}