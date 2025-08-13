using AutoMapper;
using ToDo.API.DTOs;
using ToDo.API.Models;
using ToDo.API.Repositories.Interfaces;
using ToDo.API.Services.Interfaces;

namespace ToDo.API.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ITodoRepository _todoRepo;
        private readonly IMapper _mapper;

        public ToDoItemService(ITodoRepository todoRepo, IMapper mapper)
        {
            _todoRepo = todoRepo;
            _mapper = mapper;
        }

        public async Task<ToDoReadDto> CreateAsync(ToDoCreateDto dto)
        {
            var todoDomain = _mapper.Map<ToDoItem>(dto);
            todoDomain = await _todoRepo.CreateAsync(todoDomain);
            var todoDto = _mapper.Map<ToDoReadDto>(todoDomain);
            return todoDto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _todoRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ToDoReadDto>> GetAllAsync()
        {
            var todosDomain = await _todoRepo.GetAllAsync();
            var todosDto = _mapper.Map<IEnumerable<ToDoReadDto>>(todosDomain);
            return todosDto;
        }

        public async Task<ToDoReadDto> GetByIdAsync(Guid id)
        {
            var todoDomain = await _todoRepo.GetByIdAsync(id);
            var todoDto = _mapper.Map<ToDoReadDto>(todoDomain);
            return todoDto;
        }

        public async Task<ToDoReadDto> UpdateAsync(Guid id, ToDoUpdateDto dto)
        {
            var todoDomain = await _todoRepo.GetByIdAsync(id);
            if (todoDomain == null) return null;
            _mapper.Map(dto, todoDomain);
            todoDomain = await _todoRepo.UpdateAsync(todoDomain);
            var updatedDto = _mapper.Map<ToDoReadDto>(todoDomain);
            return updatedDto;
        }
    }
}
