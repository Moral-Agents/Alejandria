using System;
using System.Collections.Generic;
using System.Text;


namespace Alejandria.Dtos
{
	public class CourseDto
	{
	public int Id { get; set; }
	public string Name { get; set; }
	public string TeacherName { get; set; }
	public bool TeacherLink { get; set; }
	public int TeacherCode { get; set; }
	public string TeacherMessage { get; set; }
	}
}
