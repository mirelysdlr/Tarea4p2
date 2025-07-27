using organizadordeventos.Domain.DTOs;

namespace organizadordeventos.Domain.Contracts
{
    public interface IEventoService : IBaseService<EventoReadDto, EventoCreateDto, EventoUpdateDto>
    {
        // Métodos específicos adicionales para Evento si los necesitas
    }
}