using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRestaurante.DAL;
using SistemaRestaurante.ENT;




namespace SistemaRestaurante.BLL
{
    public class PlatoBLL
    {
        private readonly PlatoDAL _platoDAL = new PlatoDAL();

        public List<Plato> ObtenerPlatos()
        {
            return _platoDAL.ObtenerPlatos();
        }

        public void AgregarPlato(Plato plato)
        {
            if (string.IsNullOrWhiteSpace(plato.nombre))
                throw new Exception("El nombre del plato no puede estar vacío.");
            if (plato.precio <= 0)
                throw new Exception("El precio del plato debe ser mayor que cero.");
            _platoDAL.agregarPlato(plato);
        }

        public void ActualizarPlato(Plato plato)
        {
            if (string.IsNullOrWhiteSpace(plato.nombre))
                throw new Exception("El nombre del plato no puede estar vacío.");
            if (plato.precio <= 0)
                throw new Exception("El precio del plato debe ser mayor que cero.");
            _platoDAL.ActualizarPlato(plato);
        }

        public void eliminarPlato(int idPlato)
        {
            _platoDAL.EliminarPlato(idPlato);
        }
    }
}
