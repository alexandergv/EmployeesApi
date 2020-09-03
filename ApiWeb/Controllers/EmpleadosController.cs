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
    public class EmpleadosController : ApiController
    {
     
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string consulta = @"select IdEmpleado, NombreEmpleado, ApellidoEmpleado, Departamento, MailID
            from dbo.Empleados";

            using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString))
            using (var comando = new SqlCommand(consulta, conexion))
            using (var ad = new SqlDataAdapter(comando))
            {
                comando.CommandType = CommandType.Text;
                ad.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
            
        }
        
        public string Post(Empleados emp)
        {
            try
            {
                DataTable table = new DataTable();
                
                string consulta = @"Insert into dbo.Empleados(
                    NombreEmpleado, Departamento, MailID) 
                    values(
                    '" + emp.NombreEmpleado + @"'
                        , '"+ emp.ApellidoEmpleado + @"'
                      , '"+ emp.Departamento + @"'
                      , '"+ emp.MailID+ @"'
                            
                
                ) 

                ";

                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString))
                using (var comando = new SqlCommand(consulta, conexion))
                using (var ad = new SqlDataAdapter(comando))
                {
                    comando.CommandType = CommandType.Text;
                    ad.Fill(table);
                }
                return consulta;
            }
            catch (Exception)
            {
                return "Error en la publicacion";
            }

        }

    }
}
