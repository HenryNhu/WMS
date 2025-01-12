using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WMS_new.Models;

namespace WMS_new.Controllers
{
    public class NationController : Controller
    {
        private string URL_GetAll = "http://localhost:5269/api/API_Nation";
        private string URL_Add = "http://localhost:5269/api/API_Nation";
        public async Task<IActionResult> Index()
        {
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync(URL_GetAll);
                if (!response.IsSuccessStatusCode)
                {
                    // Xử lý khi API trả về lỗi (Có thể trả về một trang lỗi hoặc thông báo)
                    return View("Error");
                }
                var responseBody = await response.Content.ReadAsStringAsync();
                var nations = JsonConvert.DeserializeObject<List<Nation>>(responseBody);
                ViewBag.Nations = nations;
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Nation nation)
        {
            using (var client = new HttpClient())
            {
                // Chuyển đối tượng Nation thành JSON
                var jsonContent = JsonConvert.SerializeObject(nation);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST đến API
                var response = await client.PostAsync(URL_Add, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
            }

            // Chuyển hướng về trang Index sau khi thêm thành công
            return RedirectToAction("Index");
        }
    }
}
