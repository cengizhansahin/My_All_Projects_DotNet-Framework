using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcbasics.Models
{
    public class Repository
    {
        public static List<Course> Courses { get; set; } = new List<Course>(){
            new Course()
        {
            Id = 1,
                    Title = "AspNet Core",
                    Description = "Güzel keyifli bir kurs",
                    Image = "2.png"
                },
                new Course()
        {
            Id = 2,
                    Title = "ReactJs",
                    Description = "Seri, hızlı bir kurs",
                    Image = "1.png"
                },
                new Course()
        {
            Id = 3,
                    Title = "Redux Toolkit",
                    Description = "Güzerl keyifli bir kurs",
                    Image = "4.jpg"
                },
                new Course()
        {
            Id = 4,
                    Title = "Falan Toolkit",
                    Description = "Güzerl keyifli bir kurs",
                    Image = "4.jpg"
                }
    };
        public static Course GetCourseById(int id)
        {
            return Courses.FirstOrDefault(u => u.Id == id);
        }
    }
}