using SistemaRestaurante.DAL;
using SistemaRestaurante.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.BLL
{
    public class LoginBLL
    {
        private readonly LoginDAL _dal;

        public LoginBLL()
        {
            _dal = new LoginDAL();
        }

        // Intenta autenticar; devuelve Usuario si OK, null si falla
        public Usuario Autenticar(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
                return null;

            try
            {
                return _dal.Autenticar(username.Trim(), password);
            }
            catch (Exception)
            {
                // En BLL solo devolvemos null en caso de fallo; loguear si lo deseas
                return null;
            }
        }

        // Obtiene un usuario por username (útil para mostrar datos sin autenticar)
        public Usuario ObtenerPorUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            try
            {
                return _dal.ObtenerPorUsername(username.Trim());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
