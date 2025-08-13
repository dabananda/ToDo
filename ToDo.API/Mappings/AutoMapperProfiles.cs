using AutoMapper;
using ToDo.API.DTOs;
using ToDo.API.Models;

namespace ToDo.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // ToDoItem mappings
            CreateMap<ToDoItem, ToDoReadDto>().ReverseMap();
            CreateMap<ToDoItem, ToDoCreateDto>().ReverseMap();
            CreateMap<ToDoItem, ToDoUpdateDto>().ReverseMap();
        }
    }
}
