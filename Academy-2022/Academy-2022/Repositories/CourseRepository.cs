using Academy_2022.Data;
using Academy_2022.Models;
using Academy_2022.Models.Dto;
using Microsoft.EntityFrameworkCore;



namespace Academy_2022.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<Course>> GetAllAsync()
        {

            return _applicationDbContext.Courses.ToListAsync();
        }

        public Task<Course?> GetbyIdAsync(int id)
        {
            return _applicationDbContext.Courses.FirstOrDefaultAsync(course => course.Id == id);
        }

        public async Task<Course> CreateAsync(CourseDto courseDto)
        {
            var course = new Models.Course
            {
                Title = courseDto.Title,
                Description = courseDto.Description,
                Url = courseDto.Url,
                AuthorId=courseDto.AuthorId
            };

            var addCourse = await _applicationDbContext.AddAsync(course);
            var saveCourse = await _applicationDbContext.SaveChangesAsync();

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
            course.AuthorId = courseDto.AuthorId;

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
