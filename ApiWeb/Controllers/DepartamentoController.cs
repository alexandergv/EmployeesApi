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


namespace ApiWeb.Controllers
{
    public class DepartamentoController : ApiController
    {

        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string consulta = @"
            select IDdepartamento, Nombredepartamento from dbo.Departamentos  
";

            using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString))
            using (var command = new SqlCommand(consulta, conexion))
            using (var ad = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                ad.Fill(dt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
        public string Post(Departamento dep)
        {
            try
            {

                DataTable dt = new DataTable();

                string consulta = @"
                Insert into dbo.Departamentos values('" + dep.Nombredepartamento+@"')
                  ";

                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString))
                using (var command = new SqlCommand(consulta, conexion))
                using (var ad = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    ad.Fill(dt);
                }
                return consulta;
            }
            catch (Exception)
            {
                return "Fallo al añadir";
            }

        }
        public string Put (Departamento dep)
        {
            try
            {
                DataTable dt = new DataTable();

                string consulta = "update dbo.Departamentos set Nombredepartamento ='" + dep.Nombredepartamento+@"'
                 where   IDdepartamento = "+dep.IDdepartamento +@"

                        ";

                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AppEmpleadosBD"].ConnectionString))
                using (var comando = new SqlCommand(consulta, conexion))
                    using (var dataAdapter = new SqlDataAdapter(comando))
                {
                    comando.CommandType = CommandType.Text;
                    dataAdapter.Fill(dt);
                }

                    return "todo fue bien.";
            }
            catch (Exception)
            {
                return "Hubo un problema en la actualizacion de datos";
            }
        }
    }
}
