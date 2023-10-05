using DuAnTuyetVoiPart1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace DuAnTuyetVoiPart1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]


        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValidUser(user.Username, user.Password))
                {
                    //ViewData["LoginSuccess"] = true;
                    return RedirectToAction("Index", "Admin");
      
                }
                else
                {
                    ModelState.AddModelError("", "Bạn đã đăng nhập sai tài khoản");
                }
            }

            return View(user);

        }


        private bool IsValidUser(string username, string password)
        {
            bool isValid = false;
            string connectionString = "Data Source=127.0.0.1;Initial Catalog=DuAnTuyetVoi;User ID=sa;Password=quypro2003";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    isValid = (count == 1);
                }

                connection.Close();
            }

            return isValid;
        }

    }
}
