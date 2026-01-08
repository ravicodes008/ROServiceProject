using ROServiceProject.DataHelper;
using ROServiceProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ROServiceProject.Controllers
{
    public class AccountController : Controller
    {


        // GET: Account/Login
        public ActionResult Login()
        {
            // If user is already logged in, redirect to dashboard
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Prepare parameterss
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        DbHelper.CreateParameter("@UserName", model.UserName),
                        DbHelper.CreateParameter("@Password", model.Password)
                    };

                    // Execute login stored procedure
                    DataTable dt = DbHelper.ExecuteDataTable("SP_UserLogin", parameters);

                    // Check if user found
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        // Create user data for authentication cookie
                        string userData = string.Format("{0}",
                            row["UserId"]
                            );

                        // Create authentication ticket
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            1,                              // Version
                            row["Username"].ToString(),       // Username (Mobile)
                            DateTime.Now,                   // Issue time
                            DateTime.Now.AddHours(1),       // Expiration time
                            model.RememberMe,               // Persistent
                            userData,                       // User data
                            FormsAuthentication.FormsCookiePath
                        );

                        // Encrypt the ticket
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                        // Create cookie
                        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        authCookie.HttpOnly = true;
                        Response.Cookies.Add(authCookie);

                        // Redirect to dashboard
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Username or password");
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Login error: " + ex.Message;
                return View(model);
            }
        }



    }
}