using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using ApiWeb.Models;

namespace ApiWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Directorio";
            //Proceso de la base de datos
            string mainConn = ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString;
            SqlConnection connection = new SqlConnection(mainConn);
            string sqlquery = "select Nombredepartamento from dbo.Departamentos";
            
            SqlCommand command = new SqlCommand(sqlquery, connection);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            List<SelectListItem> departmentnamelist = new List<SelectListItem>();

            foreach(System.Data.DataRow dataRow in dataTable.Rows)
            {
                departmentnamelist.Add(new SelectListItem { Text = dataRow["Nombredepartamento"].ToString(), Value = dataRow["Nombredepartamento"].ToString() });
               
            }
            ViewBag.Departamentos = departmentnamelist;
                


            connection.Close();
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(Empleados emp)
        {
           
            ViewBag.Title = "Directorio";

            // //DropdownListFor
            string mainConn = ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString;
            SqlConnection connection = new SqlConnection(mainConn);
            string sqlquery = "select Nombredepartamento from dbo.Departamentos";

            SqlCommand command = new SqlCommand(sqlquery, connection);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            List<SelectListItem> departmentnamelist = new List<SelectListItem>();

            foreach (System.Data.DataRow dataRow in dataTable.Rows)
            {
                departmentnamelist.Add(new SelectListItem { Text = dataRow["Nombredepartamento"].ToString(), Value = dataRow["Nombredepartamento"].ToString() });

            }
            ViewBag.Departamentos = departmentnamelist;



            connection.Close();

            try
            {
                DataTable table = new DataTable();

                string consulta = @"Insert into dbo.Empleados(
                    NombreEmpleado,ApellidoEmpleado, Departamento, MailID) 
                    values(
                    '" + emp.NombreEmpleado + @"'
                        , '" + emp.ApellidoEmpleado + @"'
                      , '" + emp.Departamento + @"'
                      , '" + emp.MailID + @"'
                            
                
                ) 

                ";
                
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString))
                using (var comando = new SqlCommand(consulta, conexion))
                using (var ad = new SqlDataAdapter(comando))
                {
                    comando.CommandType = CommandType.Text;
                    ad.Fill(table);
                }
            }
            catch (Exception)
            {
                ViewBag.error = "error";
 
            };

            ModelState.Clear();

            return View();
        }

        }
    }
