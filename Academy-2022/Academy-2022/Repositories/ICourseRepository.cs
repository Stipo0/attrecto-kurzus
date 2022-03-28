using Academy_2022.Models;
using Academy_2022.Models.Dto;

namespace Academy_2022.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetbyIdAsync(int id);
        Task<Course>CreateAsync(CourseDto courseDto);
        Course? Update(int id, CourseDto courseDto);
        bool Delete(int id);
    }
}
