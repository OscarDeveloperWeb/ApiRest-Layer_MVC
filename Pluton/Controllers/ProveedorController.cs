using Libreria;
using PlutonBE;
using PlutonBL;
using Microsoft.AspNetCore.Mvc;

namespace PlutonApi.Controllers
{
    [ApiController]
    [Route("api/proveedor")]
    public class ProveedorController : ControllerBase
    {
        [HttpGet]
        [Route("select-by-id/{idProveedor}")]
        public Proveedor SelectById(int idProveedor)
        {
            var blProveedor = new ProveedorBusinessLogic();
            return blProveedor.SelectById(idProveedor);
        }

        [HttpPost]
        [Route("insert")]
        public void Insert(Proveedor beProveedor)
        {
            var blProveedor = new ProveedorBusinessLogic();
            blProveedor.Insert(beProveedor);
        }

        [HttpPut]
        [Route("update/{idProveedor}")]
        public void Update(int idProveedor, Proveedor beProveedor)
        {
            var blProveedor = new ProveedorBusinessLogic();
            blProveedor.Update(idProveedor, beProveedor);
        }

        [HttpDelete]
        [Route("delete/{idProveedor}")]
        public void Delete(int idProveedor)
        {
            var blProveedor = new ProveedorBusinessLogic();
            blProveedor.Delete(idProveedor);

        }

    }
}
