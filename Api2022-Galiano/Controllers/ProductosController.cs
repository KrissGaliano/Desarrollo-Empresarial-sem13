using Api2022_Quito.Models.Request;
using Api2022_Quito.Models.Response;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api2022_Quito.Controllers
{
    public class ProductosController : ApiController
    {
        // GET: Lista
        [HttpGet]
        public List<ProductoResponse> List()
        {
            var service = new ProductoService();
            var productos = service.Get();

            //Convert Domaint to Response
            var response = productos.Select(x => new ProductoResponse
            {
                productoID = x.productoID,
                nombre = x.nombre,
                descripcion = x.descripcion,
                fechaCreacion = x.fechaCreacion,
                fechaVencimiento = x.fechaVencimiento,
                IsEnable = x.IsEnable,
                precioVenta = x.precioVenta,
                igv = x.igv
            }).ToList();
            return response;
        }


        // GET: By ID
        [HttpGet]
        public IHttpActionResult GetProdById(int id)
        {
            var service = new ProductoService();
            var prod = service.GetById(id);

            return Ok(prod);
        }

        // POST
        [HttpPost]
        public bool Create(ProductoRequest request)
        {
            var response = true;
            try
            {
                var service = new ProductoService();
                service.Insert(new Domain.Producto
                {
                    nombre = request.nombre,
                    descripcion = request.descripcion,
                    fechaCreacion = request.fechaCreacion,
                    fechaVencimiento = request.fechaVencimiento,
                    precioVenta = request.precioVenta
                });
            }
            catch (Exception)
            {
                //log ex
                response = false;
            }
            return response;
        }

        // PUT
        [HttpPut]
        public bool Actualizar(int id, ProductoResponse request)
        {

            var response = true;
            try
            {
                var service = new ProductoService();
                service.Update(new Domain.Producto
                {
                    nombre = request.nombre,
                    descripcion = request.descripcion,
                    fechaCreacion = request.fechaCreacion,
                    fechaVencimiento = request.fechaVencimiento,
                    precioVenta = request.precioVenta
                }, id);

            }
            catch (Exception)
            {
                //log ex
                response = false;
            }
            return response;
        }

        // DELETE: 
        public IHttpActionResult DeleteProduct(int id)
        {
            var response = true;
            try
            {
                var service = new ProductoService();
                service.Delete(id);

            }
            catch (Exception)
            {
                //log ex
                response = false;
            }
            return Ok(response);
        }



    }
}