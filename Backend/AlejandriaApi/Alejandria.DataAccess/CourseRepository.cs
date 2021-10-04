using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
	public class CourseRepository : ICourseRepository
	{
		private readonly AlejandriaDbContext _context;

		public CourseRepository(AlejandriaDbContext context)
        {
			_context = context;
		}

		public async Task Create(Course entity)
		{
			await _context.Set<Course>().AddAsync(entity);

			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var course = new Course()
			{
				Id = id
			};

			_context.Courses.Remove(course);

			await _context.SaveChangesAsync();
		}

		public async Task<ICollection<Course>> GetCollection(string filter)
		{
			var collection = await _context.Courses
				.Where(c => c.Name.Contains(filter))
				.ToListAsync();

			return collection;
		}

		public async Task<Course> GetItem(int id)
		{
			return await _context.Courses.FindAsync(id);
		}

		public async Task Update(Course entity)
		{
			_context.Set<Course>().Attach(entity);
			await _context.SaveChangesAsync();
		}
	}
}
