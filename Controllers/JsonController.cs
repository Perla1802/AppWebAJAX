using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using AppWebAJAX.Models;


namespace AppWebAJAX.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()

        {
                return View();
        }

        //Regresar Json

        public JsonResult ObtenerConsultas()
        {
            List<ConsultaUno> consultaUno;
            List<ConsultaDos> consultaDos;
            //Cadena de conexion
            using (AdventureWorks2012Entities db = new AdventureWorks2012Entities())
            {
                //Consulta de SQL a tipo LINQ
                consultaUno = (from poh in db.PurchaseOrderHeader
                               join pod in db.PurchaseOrderDetail on poh.PurchaseOrderID equals pod.PurchaseOrderID
                               join sm in db.ShipMethod on poh.ShipMethodID equals sm.ShipMethodID
                               where poh.VendorID == 1662
                               select new ConsultaUno //consulta LINQ para crear objetos de esta clase
                               {
                                   OrderID = poh.PurchaseOrderID,
                                   VendorID = poh.VendorID,
                                   OrderDetailID = pod.PurchaseOrderDetailID,
                                   ProductID = pod.ProductID,
                                   UnitPrice = pod.UnitPrice,
                                   StockedQty = (int)pod.StockedQty,
                                   NombreEnvio = sm.Name,
                                   ShipBase = sm.ShipBase
                               }).ToList();

                consultaDos = (from poh in db.PurchaseOrderHeaders
                               join pod in db.PurchaseOrderDetails on poh.PurchaseOrderID equals pod.PurchaseOrderID
                               join p in db.Products on pod.ProductID equals p.ProductID
                               join v in db.Vendors on poh.VendorID equals v.BusinessEntityID
                               where poh.VendorID >= 1568 && poh.VendorID <= 1572
                               select new ConsultaDos
                               {
                                   VendorID = poh.VendorID,
                                   VendorIdV = v.BusinessEntityID,
                                   PurchaseOrderID = poh.PurchaseOrderID,
                                   PodPurchaseOrderID = pod.PurchaseOrderID,
                                   SubTotal = poh.SubTotal,
                                   UnitPrice = pod.UnitPrice,
                                   OrderQty = pod.OrderQty,
                                   ProductID = pod.ProductID,
                                   ProductName = p.Name,
                                   ProductColor = p.Color,
                                   VendorName = v.Name,
                                   VendorAccountNumber = v.AccountNumber
                               }).ToList();
            }
            //Vraiable donde se almacenan las dos List (Consultas)
            var ConsultasViewModel = new ConsultasViewModel
            {
                ConsultaUno = consultaUno,
                ConsultaDos = consultaDos
            };
            //Retorno de un JSON con las consultas antes hechas
            return Json(ConsultasViewModel, JsonRequestBehavior.AllowGet); //Permite solicitudes get (Se vuelve asíncrono)


        }    
        
        
        
    }

}