using System.Collections.Generic;
using System.Threading.Tasks;

namespace organizadordeventos.Domain.Contracts
{
    public interface IBaseService<TReadDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TReadDto>> GetAllAsync();
        Task<TReadDto> GetByIdAsync(int id);
        Task<TReadDto> CreateAsync(TCreateDto createDto);
        Task<TReadDto> UpdateAsync(int id, TUpdateDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}