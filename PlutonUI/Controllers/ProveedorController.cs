using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlutonUI.Models;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text;
using AutoMapper;
using PlutonBE;
using Libreria;
namespace PlutonUI.Controllers
{
    [Route("proveedor")]
    public class ProveedorController : Controller
    {
        private readonly IMapper _mapper;
        public ProveedorController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            _mapper = config.CreateMapper();

        }

        [HttpGet]
        [Route("eliminar")]
        public IActionResult Eliminar()
        {
            return View();
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {
            return View();
        }


        [HttpGet]
        [Route("nuevo")]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpGet]
        [Route("editar/{idProveedor}")]
        public IActionResult Editar(int idProveedor)
        {
            ViewBag.IdProveedor = idProveedor;


            return View();
        }


        [HttpGet]
        [Route("select-by-id/{idProveedor}")]
        public async Task<ProveedorModel> SelecById(int idProveedor)
        {
            try
            {
                ProveedorModel dtoProveedor = null;
                Proveedor beProveedor = null;

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("PlutonApi"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await cliente.GetAsync("api/proveedor/select-by-id/" + idProveedor + "/");
                    if (res.IsSuccessStatusCode)
                    {
                        var proveedorResult = res.Content.ReadAsStringAsync().Result;
                        beProveedor = JsonConvert.DeserializeObject<Proveedor>(proveedorResult)!;
                        dtoProveedor = _mapper.Map<ProveedorModel>(beProveedor);
                    }
                }
                return dtoProveedor;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPost]
        [Route("insert")]
        public async Task Insert(string proveedor) 
        {
            try
            {
                var dtoProveedor = JsonConvert.DeserializeObject<ProveedorModel>(proveedor);

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("PlutonApi"));
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var beProveedor = _mapper.Map<Proveedor>(dtoProveedor);
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(beProveedor), Encoding.UTF8, "application/json");
                    var res = await cliente.PostAsync("api/proveedor/insert", jsonContent);
                    if (!res.IsSuccessStatusCode)
                    {
                        throw new Exception(res.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut]
        [Route("update/{idProveedor}")]
        public async Task Update(int idProveedor, string proveedor)
        {
            var dtoProveedor = JsonConvert.DeserializeObject<ProveedorModel>(proveedor);

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("PlutonApi"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var beProveedor = _mapper.Map<Proveedor>(dtoProveedor);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(beProveedor), Encoding.UTF8, "application/json");
                var res = await cliente.PutAsync("api/proveedor/update/" + idProveedor, jsonContent);
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }

        [HttpDelete]
        [Route("delete/{idProveedor}")]
        public async Task Delete(int idProveedor)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationJson.GetAppSettings("PlutonApi"));
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await cliente.DeleteAsync("api/proveedor/delete/" + idProveedor + "/");
                if (!res.IsSuccessStatusCode)
                {
                    throw new Exception(res.StatusCode.ToString());
                }
            }
        }
    }
}
