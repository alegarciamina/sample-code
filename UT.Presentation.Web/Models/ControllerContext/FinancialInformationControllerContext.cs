using UT.Application.Storage;
using UT.Domain.Interfaces;

namespace UT.Presentation.Web.Models.ControllerContext
{
    public class FinancialInformationControllerContext
    {
        public ISitecoreContext SitecoreContext { get; set; }
        public IFinancialInstitutionsRepository FinancialInstitutionsRepository { get; set; }
        public ISessionStorage Session { get; set; }
    }
}