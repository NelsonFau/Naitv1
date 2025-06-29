using Naitv1.Data;
using Naitv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Naitv1.Services
{
    public class GeneradorReportesService
    {
        private readonly AppDbContext _context;

        public GeneradorReportesService(AppDbContext context)
        {
            _context = context;
        }

        public int CrearRegistro(DateTime fechaProgramada, string destinatario, string asunto)
        {
            var registro = new RegistroEmail
            {
                Destinatario = destinatario,
                Asunto = asunto,
                FechaProgramada = fechaProgramada,
                FechaCreacion = DateTime.UtcNow,
                Estado = EstadoEmail.Pendiente

            };

            try
            {
                string html = GenerarHtmlConReporte();
                registro.CuerpoHtml = html;
            }
            catch (Exception ex)
            {
                // Log del error si es necesario
                registro.CuerpoHtml = $"<p>Error al generar el reporte: {ex.Message}</p>";
                registro.Estado = EstadoEmail.Fallido;
            }

            _context.RegistroEmails.Add(registro);
            _context.SaveChanges();
            return registro.Id;

        }


        public string GenerarHtmlConReporte()
        {
            string rutaImagen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "graficos", "graficoKpis.png");

            // ⚠️ Asegurate de tener estas entidades en tu DbContext
            int totalActividades = _context.Actividades.Count();
            int totalCiudades = _context.Ciudades.Count();
            int totalUsuarios = _context.Usuarios.Count();

            // Leer imagen del gráfico
            byte[] imagenBytes = File.ReadAllBytes(rutaImagen);
            string base64Imagen = Convert.ToBase64String(imagenBytes);

            return $@"
            <html>
            <head><meta charset='utf-8'></head>
            <body>
                <h2>Reporte Semanal</h2>
                <ul>
                    <li><b>Total de Actividades:</b> {totalActividades}</li>
                    <li><b>Total de Ciudades:</b> {totalCiudades}</li>
                    <li><b>Total de Usuarios:</b> {totalUsuarios}</li>
                </ul>
                <h3>Gráfico:</h3>
                <img src='data:image/png;base64,{base64Imagen}' width='400' height='200' />
            </body>
            </html>";
        }


    }
}