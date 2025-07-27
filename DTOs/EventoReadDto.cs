using System;

namespace organizadordeventos.Domain.DTOs
{
    public class EventoReadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
    }
}