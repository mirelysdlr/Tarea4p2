using System;
using System.ComponentModel.DataAnnotations;

namespace organizadordeventos.Domain.DTOs
{
    public class EventoCreateDto
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
    }
}