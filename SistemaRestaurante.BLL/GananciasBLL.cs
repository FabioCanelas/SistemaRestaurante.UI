using SistemaRestaurante.DAL;
using System;

namespace SistemaRestaurante.BLL
{
    public class GananciasBLL
    {
        private readonly GananciasDAL _gananciasDAL;

        public GananciasBLL()
        {
            _gananciasDAL = new GananciasDAL();
        }

        public decimal ObtenerGananciaDelDia()
        {
            return _gananciasDAL.ObtenerGananciaDelDia();
        }

        public decimal ObtenerGananciaDelMes()
        {
            return _gananciasDAL.ObtenerGananciaDelMes();
        }

        public int ObtenerTotalPedidosDelDia()
        {
            return _gananciasDAL.ObtenerTotalPedidosDelDia();
        }

        // Método para calcular el promedio diario del mes
        public decimal ObtenerPromedioDiarioDelMes()
        {
            var gananciaDelMes = ObtenerGananciaDelMes();
            var diasDelMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var diaActual = DateTime.Now.Day;
            
            // Calcular promedio basado en los días transcurridos del mes
            return diaActual > 0 ? gananciaDelMes / diaActual : 0;
        }

        // Método para formatear moneda
        public string FormatearMoneda(decimal cantidad)
        {
            return cantidad.ToString("N2") + " Bs";
        }
    }
}