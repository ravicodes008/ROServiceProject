using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROServiceProject.DataHelper;
using ROServiceProject.Models;

namespace ROServiceProject.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceRequest(ServiceRequestModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SqlParameter[] parameters =
                    {
                DbHelper.CreateParameter("@Name", model.Name),
                DbHelper.CreateParameter("@Mobile", model.Mobile),
                DbHelper.CreateParameter("@Address", model.Address),
                DbHelper.CreateParameter("@ProblemDescription", model.ProblemDescription),
                DbHelper.CreateOutputParameter("@RequestCode", SqlDbType.NVarChar, 10)
            };

                    object requestCode =
                        DbHelper.ExecuteWithOutputParam("sp_SaveServiceRequest", parameters, "@RequestCode");

                    ViewBag.SuccessMessage =
                        "Your request has been submitted. Request No: " + requestCode;

                    ModelState.Clear();
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }
    }
}
