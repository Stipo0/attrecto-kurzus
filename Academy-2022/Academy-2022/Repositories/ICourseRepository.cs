using Academy_2022.Models;
using Academy_2022.Models.Dto;

namespace Academy_2022.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course? GetbyId(int id);
        Course Create(CourseDto courseDto);
        Course? Update(int id, CourseDto courseDto);
        bool Delete(int id);
    }
}
