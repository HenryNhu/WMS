using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using WMS_new.Models;
using Microsoft.AspNetCore.Http;

namespace WMS_new.Controllers
{
    public class UsersController : Controller
    {
        private String URL_Login = "http://localhost:5269/api/API_Users?";
        private readonly HttpClient _httpClient;
        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                var response = await _httpClient.PostAsync(URL_Login + $"UserId={user.UserId}&Password={user.Password}", null);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<dynamic>(result);
                    if (responseData?.message == "correct")
                    {
                        var data = responseData.data;
                        string json = JsonConvert.SerializeObject(data);
                        HttpContext.Session.SetString("User", json);
                        return RedirectToAction("SelectWorkingWarehouse", "Warehouse");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Sai tài khoản hoặc mật khẩu";
                        return View("Login");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Hãy nhập đầy đủ tài khoản và mật khẩu";
                    return View("Login");
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "Lỗi kết nối tới sever!!! Hãy kiểm tra mạng hoặc liên hệ phòng Công nghệ thông tin";
                return View("Login");
            }
        }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login", "Users");
        }
    }
}
