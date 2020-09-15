using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ApiWeb.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using ApiWeb.Controllers;
using System.Web.Mvc;

namespace ApiWeb.Controllers    
{
    public class EmpleadosController : Controller
    {

        public ActionResult Index()
        {
            DataTable table = new DataTable();

            string consulta = @"select IdEmpleado, NombreEmpleado, ApellidoEmpleado, Departamento, MailID
            from dbo.Empleados";

            using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString))
            using (var comando = new SqlCommand(consulta, conexion))
            using (var ad = new SqlDataAdapter(comando))

                ad.Fill(table);

            List<SelectListItem> empleadoList = new List<SelectListItem>();

            foreach(System.Data.DataRow dataRow in table.Rows)
            {
                empleadoList.Add(new SelectListItem { Text = dataRow["IdEmpleado"].ToString(), Value =dataRow["IdEmpleado"].ToString() });
            }

            ViewBag.Empleados = table;


            
            return View();
        
        }

    }
}
