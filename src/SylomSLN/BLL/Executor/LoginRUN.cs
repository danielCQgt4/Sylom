using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class LoginRUN {

        private readonly DMZDataContext Sec;
        private readonly BitacoraRUN Bitacora;

        public LoginRUN() {
            Sec = new DMZDataContext();
            Bitacora = new BitacoraRUN();
            Bitacora.SetUsuario(null);
        }

        public consultaLoginAuthResult IniciarSesion(string usuario, string contra, bool encript) {
            try {
                //Contemplar encriptacion
                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contra)) {
                    if (encript) {
                        usuario = Encriptar(usuario);
                        contra = Encriptar(contra);
                    }
                    var r = Sec.consultaLoginAuth(usuario, contra).ToList();
                    if (r.Count() == 0) {
                        return null;
                    }
                    return r[0];
                }
                return null;
            } catch (Exception e) {
                Bitacora.AgregarRegistro("LoginRUN", $"IniciarSesion({usuario},*)", e.ToString(), 'E');
                return null;
            }
        }

        public List<consultaLoginPermisosResult> GetPermisos(int idEmpleado) {
            try {
                var r = Sec.consultaLoginPermisos(idEmpleado);
                return r.ToList();
            } catch (Exception e) {
                Bitacora.AgregarRegistro("LoginRUN,", $"GetPermisos({idEmpleado})", e.ToString(), 'E');
                return null;
            }
        }

        public string Encriptar(string rawData) {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create()) {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0;i < bytes.Length;i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
