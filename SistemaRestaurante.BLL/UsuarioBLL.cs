using SistemaRestaurante.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRestaurante.DAL;
using SistemaRestaurante.ENT;

namespace SistemaRestaurante.BLL
{
    public class UsuarioBLL
    {

        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarioDAL.ObetenerUsuarios();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.nombre))
                throw new Exception("El nombre del usuario no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(usuario.password))
                throw new Exception("La contraseña no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(usuario.username))
                throw new Exception("El nombre de usuario no puede estar vacio.");

            if (!Enum.IsDefined(typeof(Rol), usuario.rol))
                throw new Exception("El rol del usuario no es válido");
        

            _usuarioDAL.AgregarUsuario(usuario);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.nombre))
                throw new Exception("El nombre del usuario no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(usuario.password))
                throw new Exception("La contraseña no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(usuario.username))
                throw new Exception("El nombre de usuario no puede estar vacio.");

            if (!Enum.IsDefined(typeof(Rol), usuario.rol) || usuario.rol == Rol.Seleccionar)
                throw new Exception("Debe seleccionar un rol válido para el usuario.");

            _usuarioDAL.ActualizarUsuario(usuario);
        }

        public void EliminarUsuario(int idUsuario)
        {
            _usuarioDAL.EliminarUsuario(idUsuario);
        }
    }
}
