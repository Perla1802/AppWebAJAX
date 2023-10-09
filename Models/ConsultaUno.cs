using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebAJAX.Models
{
    //Clase para el almacenamiento de las listas
    public class ConsultasViewModel
    {
        public List<ConsultaUno> ConsultaUno { get; set; }
        public List<ConsultaDos> ConsultaDos { get; set; }
    }

    //clases para almacenar los resultados de la consulta
    public class ConsultaUno
    { 
        public int OrderID { get; set; }
        public int VendorID { get; set; }
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockedQty { get; set; }
        public string NombreEnvio { get; set; }
        public decimal ShipBase { get; set; }
    }

    public class ConsultaDos
    {
        public int VendorID { get; set; }
        public int VendorIdV { get; set; }
        public int PurchaseOrderID { get; set; }
        public int PodPurchaseOrderID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal UnitPrice { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductColor { get; set; }
        public string VendorName { get; set; }
        public string VendorAccountNumber { get; set; }
    }

}