using Academy_2022.Data;
using Academy_2022.Models;
using Academy_2022.Models.Dto;

namespace Academy_2022.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CourseRepository()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public IEnumerable<Course> GetAll()
        {

            return _applicationDbContext.Courses.ToList();
        }

        public Course? GetbyId(int id)
        {
            return _applicationDbContext.Courses.FirstOrDefault(course => course.Id == id);
        }

        public Course Create(CourseDto courseDto)
        {
            var course = new Models.Course
            {
                Title = courseDto.Title,
                Description = courseDto.Description,
                Url = courseDto.Url
            };

            _applicationDbContext.Add(course);
            _applicationDbContext.SaveChanges();

            return course;
        }

        public Course? Update(int id, CourseDto courseDto)
        {
            var course = _applicationDbContext.Courses.FirstOrDefault(course => course.Id == id);
            if (course == null)
            {
                return null;
            }

            course.Title = courseDto.Title;
            course.Description = courseDto.Description;
            course.Url = courseDto.Url;

            _applicationDbContext.SaveChanges();

            return course;
        }

        public bool Delete(int id)
        {
            var course = _applicationDbContext.Courses.FirstOrDefault(course => course.Id == id);

            try
            {
                _applicationDbContext.Remove(course);
                _applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
