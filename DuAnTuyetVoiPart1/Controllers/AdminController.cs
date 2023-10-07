using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using DuAnTuyetVoiPart1.Models;
using System.Reflection;

namespace DuAnTuyetVoiPart1.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            List<Book> books = getAll();
            return View(books);
        }


        [HttpPost]
        public IActionResult Index(Book model)
        {
            getBook(model);
            List<Book> books = getAll();
            return View(books);

        }

        private void getBook(Book model)
        {
            string connectionString = AppSettings.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Book(Title, Price) VALUES (@Title, @Price)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", model.Title);
                    cmd.Parameters.AddWithValue("@Price", model.Price);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        string message = "Created the record successfully";
                        ViewBag.Message = message;
                    }
                    else
                    {
                        string errorMessage = "Failed to create the record";
                        ViewBag.ErrorMessage = errorMessage;
                    }
                }
                connection.Close();

            }
            
        }
        private List<Book> getAll()
        {
            List<Book> list = new List<Book>();

            //-----
            string connectionString = AppSettings.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo truy vấn SQL
                string sqlQuery = "SELECT title, Price FROM book";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Thực hiện truy vấn và đọc dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["title"].ToString();
                            double price = Convert.ToDouble(reader["Price"]);

                            // Tạo đối tượng Book và thêm vào danh sách
                            Book book = new Book
                            {
                                Title = title,
                                Price = price
                            };
                            list.Add(book);
                        }
                    }
                }
                connection.Close();
                //----
            }
            return list;

        }


    }
}
