using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UT.Domain.Entities;
using UT.Presentation.Web.Constants;
using UT.Presentation.Web.Models.ControllerContext;
using UT.Presentation.Web.Models.ViewModels;

namespace UT.Presentation.Web.Controllers
{
    //[Authorize]
    public class FinancialInformationController : Controller
    {
        private readonly FinancialInformationControllerContext _context;

        public FinancialInformationController()
            : this(DependencyResolver.Current.GetService<FinancialInformationControllerContext>())
        {
        }

        public FinancialInformationController(FinancialInformationControllerContext context)
        {
            _context = context;
        }

        // GET: FinancialInformation
        [HttpGet]
        public ActionResult Index()
        {
            if (_context.Session[SessionKeys.CustomerNumber] == null)
                return Redirect("/login");

            try
            {
                var viewModel = new BankInstitutionsViewModel()
                {
                    BankInstitutions = GetBankInstitutions(),
                    Title = _context.SitecoreContext.SitecoreHelper.Field(Fields.BankInstitutionTitle),
                    AccountNumberLabel = _context.SitecoreContext.SitecoreHelper.Field(Fields.BankInstitutionAccountNumberLabel),
                    AddLabel = _context.SitecoreContext.SitecoreHelper.Field(Fields.BankInstitutionAddLabel),
                    AddAnotherLabel = _context.SitecoreContext.SitecoreHelper.Field(Fields.BankInstitutionAddAnotherLabel),
                    DeleteLabel = _context.SitecoreContext.SitecoreHelper.Field(Fields.BankInstitutionDeleteLabel),
                    EditLabel = _context.SitecoreContext.SitecoreHelper.Field(Fields.BankInstitutionEditLabel),
                    AccountMaskText = _context.SitecoreContext.SitecoreHelper.Field(Fields.AccountMaskLabel),
                    EndingText = _context.SitecoreContext.SitecoreHelper.Field(Fields.EndingLabel),
                    AutopayText = _context.SitecoreContext.SitecoreHelper.Field(Fields.AutopayLabel),
                    InstitutionLabel = _context.SitecoreContext.SitecoreHelper.Field(Fields.BankInstitutionInstitutionLabel)
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        private List<BankAccount> GetBankInstitutions()
        {
            int custNumber;
            if(int.TryParse(_context.Session[SessionKeys.CustomerNumber] as string, out custNumber))
                return _context.FinancialInstitutionsRepository.GetBankAccountList(custNumber).ToList();
            return new List<BankAccount>();
        }
    }
}