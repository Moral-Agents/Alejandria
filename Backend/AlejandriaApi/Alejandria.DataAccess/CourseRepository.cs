using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alejandria.DataAccess
{
	public class CourseRepository : ICourseRepository
	{
		private readonly AlejandriaDbContext _context;

		public CourseRepository(AlejandriaDbContext context)
        {
			_context = context;
		}

		public void Create(Course entity)
		{
			_context.Set<Course>().Add(entity);

			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context.Entry(new Course
			{
				Id = id

			}).State = EntityState.Deleted;

			_context.SaveChanges();
		}

		public ICollection<Course> GetCollection(string filter)
		{
			return _context.Course
				.Where(c => c.Name.Contains(filter))
				.ToList();
		}

		public Course GetItem(int id)
		{
			return _context.Course.Find(id);
		}

		public void Update(Course entity)
		{
			_context.Set<Course>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;

			_context.SaveChanges();
		}
	}
}
