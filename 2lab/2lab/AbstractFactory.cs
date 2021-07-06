using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    interface IStudent
    {
        Student Clone();
        string GetInfo();
    }
    public interface IPerson
    {
        string GetInfoPerson();
    }

    public interface IGoal
    {
        string GetInfoGoal();
    }
    public class Study : IGoal
    {
        public string mainGoal => "Получить навыки для будущей профессии!";
        public string GetInfoGoal() => mainGoal;
    }
    public class Teach : IGoal
    {
        public string maainGoal => "Передать полученные знания и опыт!";
        public string GetInfoGoal() => maainGoal;
    }
    
    public interface IFactory
    {
        IPerson CreatePerson();
        IGoal CreateGoal();
    }

    public class FactoryStudent : IFactory
    {
        public IPerson CreatePerson()
        {
            return new Student();
        }
        public IGoal CreateGoal()
        {
            return new Study();
        }
    }

    public class FactoryTutor : IFactory
    {
        public IPerson CreatePerson()
        {
            return new Tutor();
        }
        public IGoal CreateGoal()
        {
            return new Teach();
        }
    }

}
