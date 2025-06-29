namespace Naitv1.Models
{
    using X.PagedList;
    using System;

    public class RegistroEmailFiltroViewModel
    {
        public EstadoEmail? EstadoEmail { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int Page { get; set; } = 1;

        public IPagedList<Naitv1.Models.RegistroEmail> Resultados { get; set; }
    }
  
}
