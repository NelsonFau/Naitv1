namespace Naitv1.Models
{
    public class RegistroEmail
    {
        public int Id { get; set; } 
        public string Destinatario {  get; set; }   
        public string Asunto { get; set; }
        public string CuerpoHtml { get; set; }  
        public DateTime FechaProgramada { get; set; }
        public EstadoEmail Estado { get; set; } = EstadoEmail.Pendiente;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    }
    public enum EstadoEmail
    {
        Pendiente = 0,
        Completado = 1,
        Fallido = 2
    }

}
