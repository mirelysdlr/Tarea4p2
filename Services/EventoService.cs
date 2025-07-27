using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using organizadordeventos.Domain.Contracts;
using organizadordeventos.Domain.DTOs;
using organizadordeventos.Domain.Entities;
using organizadordeventos.Infrastructure.Interfaces;

namespace organizadordeventos.Domain.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _repository;
        private readonly IMapper _mapper;
        
        public EventoService(IEventoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<EventoReadDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EventoReadDto>>(entities);
        }
        
        public async Task<EventoReadDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity != null ? _mapper.Map<EventoReadDto>(entity) : null;
        }
        
        public async Task<EventoReadDto> CreateAsync(EventoCreateDto createDto)
        {
            var entity = _mapper.Map<Evento>(createDto);
            var createdEntity = await _repository.AddAsync(entity);
            return _mapper.Map<EventoReadDto>(createdEntity);
        }
        
        public async Task<EventoReadDto> UpdateAsync(int id, EventoUpdateDto updateDto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null) return null;
            
            _mapper.Map(updateDto, existingEntity);
            var updatedEntity = await _repository.UpdateAsync(existingEntity);
            return _mapper.Map<EventoReadDto>(updatedEntity);
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}