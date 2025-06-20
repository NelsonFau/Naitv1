﻿using Naitv1.Data;
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

        public void CrearRegistro(DateTime fechaProgramada, string destinatario, string asunto)
        {
            var registro = new RegistroEmail
            {
                Destinatario = destinatario,
                Asunto = asunto,
                FechaProgramada = fechaProgramada,
                FechaCreacion = DateTime.UtcNow
            };

            try
            {
                string html = GenerarHtmlConReporte();
                registro.CuerpoHtml = html;
                registro.Estado = EstadoEmail.Completado;
            }
            catch (Exception ex)
            {
                // Log del error si es necesario
                registro.CuerpoHtml = $"<p>Error al generar el reporte: {ex.Message}</p>";
                registro.Estado = EstadoEmail.Fallido;
            }

            _context.RegistroEmails.Add(registro);
            _context.SaveChanges();
        }


        public string GenerarHtmlConReporte()
        {
            string rutaImagen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "graficos", "graficoKpis.png");

            // Leemos la imagen como base64
            byte[] imagenBytes = File.ReadAllBytes(rutaImagen);
            string base64Imagen = Convert.ToBase64String(imagenBytes);

            return $@"
            <html>
            <head><meta charset='utf-8'></head>
            <body>
                <h2>Reporte Semanal</h2>
                <ul>
                    <li><b>Ventas:</b> $3,200</li>
                    <li><b>Actividades creadas:</b> 57</li>
                </ul>
                <h3>Gráfico:</h3>
                <img src='data:image/png;base64,{base64Imagen}' width='400' height='200' />
            </body>
            </html>";
        }

    }
}