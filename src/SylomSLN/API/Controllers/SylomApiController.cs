using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using API.BancoCentral;
using BLL.Executor;
using API.Models;

namespace API.Controllers {

    [Authorize]
   
    [RoutePrefix("Sylom")]
    public class SylomApiController : ApiController {
        private wsindicadoreseconomicosSoapClient ApiBn = new wsindicadoreseconomicosSoapClient("wsindicadoreseconomicosSoap");
        private string correo = WebConfigurationManager.AppSettings["correo"],
                    token = WebConfigurationManager.AppSettings["token"],
                    nombre = WebConfigurationManager.AppSettings["nombre"];

        [HttpPost]
        [Route("TipoCambio")]
        // GET: api/TipoCambio
        public IHttpActionResult TipoCambio(object obj) {
            try {
                dynamic jsonObj = obj;
                //indicador = coheMYrtlh, fechaInicio = dgTrbYqeRi, fechaFin = ByyExJqgmf
                var subNiveles = "N";
                var indicador = jsonObj.coheMYrtlh.Value;
                var fechaInicio = jsonObj.dgTrbYqeRi.Value;
                var fechaFin = jsonObj.ByyExJqgmf.Value;
                DataSet data = ApiBn.ObtenerIndicadoresEconomicos(indicador, fechaInicio, fechaFin, nombre, subNiveles, correo, token);
                var codigo = data.Tables[0].Rows[0].ItemArray[0].ToString();
                var fechaConsulta = data.Tables[0].Rows[0].ItemArray[1].ToString();
                var valor = data.Tables[0].Rows[0].ItemArray[2].ToString();
                Cambio cambio = new Cambio() { cambio = valor, fecha = fechaConsulta };
                return Ok(cambio);
            } catch (Exception e) {
                return BadRequest("Error al socilicitar esta informacion, intente mas tarde ");
            }
        }

        public struct Cambio {
            public string cambio;
            public string fecha;
        }

        [HttpPost]
        [Route("obtenerPersona")]
        // GET: api/obtenerPersona
        public IHttpActionResult ObtenerPersona(object obj) {
            try {

                TokenValidationHandler vld = new TokenValidationHandler();
                dynamic json = obj;
                //eeHpcXLYQp = cedula
                var cedula = json.eeHpcXLYQp.Value;
                if (string.IsNullOrEmpty(cedula)) {
                    return BadRequest("Error al socilicitar esta informacion, intente mas tarde");
                }
                PadronRUN persona = new PadronRUN();
                var person = persona.getPersona(cedula);
                if (person.Count > 0) {
                    return Ok(person);
                } else {
                    return BadRequest("Error al socilicitar esta informacion, intente mas tarde ");
                }
            } catch (Exception e) {
                return BadRequest("Error al socilicitar esta informacion, intente mas tarde ");
            }
        }

    }
}
