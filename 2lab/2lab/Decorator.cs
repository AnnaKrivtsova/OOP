using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    abstract class Courses
    {
        public Courses(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class UniversityCourses : Courses
    {
        public UniversityCourses() : base("Курсы в университете")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class CompanyCourses : Courses
    {
        public CompanyCourses() : base("Курсы в компании")
        { }
        public override int GetCost()
        {
            return 15;
        }
    }

    abstract class CoursesDecorator : Courses
    {
        protected Courses course;
        public CoursesDecorator(string n, Courses course) : base(n)
        {
            this.course = course;
        }
    }

    class Sharp : CoursesDecorator
    {
        public Sharp(Courses c) : base(c.Name + ", по С#", c)
        { }

        public override int GetCost()
        {
            return course.GetCost() + 4;
        }
    }

    class Java : CoursesDecorator
    {
        public Java(Courses c) : base(c.Name + ", по Java", c)
        { }

        public override int GetCost()
        {
            return course.GetCost() + 5;
        }
    }

    class Plus : CoursesDecorator
    {
        public Plus(Courses c) : base(c.Name + ", по C++", c)
        { }

        public override int GetCost()
        {
            return course.GetCost() + 3;
        }
    }
}
