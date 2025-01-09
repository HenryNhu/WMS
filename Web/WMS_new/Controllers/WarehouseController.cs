using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WMS_new.Controllers
{
    public class WarehouseController : Controller
    {
        private String URL_Api_SelectWorkingWarehouse = "http://localhost:5269/api/API_Warehouse?";
        private readonly HttpClient _httpClient;
        public WarehouseController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult SelectWorkingWarehouse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SelectWorkingWarehouse(int warehouseId)
        {
            try
            {
                var response = await _httpClient.PostAsync(URL_Api_SelectWorkingWarehouse + "warehouseId=" + warehouseId, null);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<dynamic>(result);
                    if (responseData?.message == "correct warehouse")
                    {
                        string json = JsonConvert.SerializeObject(warehouseId);
                        HttpContext.Session.SetString("CurrentWarehouse", json);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Mã kho không tồn tại!";
                        return View("SelectWorkingWarehouse");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Lỗi không xác định!!! Hãy liên hệ phòng Công nghệ thông tin";
                    return View("SelectWorkingWarehouse");
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "Lỗi kết nối tới sever!!! Hãy kiểm tra mạng hoặc liên hệ phòng Công nghệ thông tin";
                return View("Login");
            }
        }
    }
}
