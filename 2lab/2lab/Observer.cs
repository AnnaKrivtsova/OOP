using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public interface IObserver
    {
        string Update(Object ob);
    }

    public interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        string NotifyObservers();
    }

    //наблюдатель
    public class Tutor : IPerson, IObserver
    {
        public string position => "Преподаватель";
        public string GetInfoPerson() => position;
        public string Name { get; set; }
        IObservable mark;

        public Tutor() { }

        public Tutor(string name, IObservable obs)
        {
            this.Name = name;
            mark = obs;
            mark.RegisterObserver(this);
        }
        public string Study(ITeach teaching)
        {
            return teaching.Teach();
        }
        public string Update(object ob)
        {
            MarkInfo mInfo = (MarkInfo)ob;

            if (mInfo.OOP > 4)
                return $"Преподаватель {this.Name} поставил студенту { mInfo.OOP} - экзамен сдан";
            else
                return $"Преподаватель {this.Name} поставил студенту { mInfo.OOP} - экзамен не сдан";
        }
        public void StopObserve()
        {
            mark.RemoveObserver(this);
            mark = null;
        }
    }

    public class MarkInfo
    {
        public int OOP { get; set; }
    }
    //наблюдаемый класс
    public class Mark : IObservable
    {
        MarkInfo mInfo; 

        List<IObserver> observers;
        public Mark()
        {
            observers = new List<IObserver>();
            mInfo = new MarkInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public string NotifyObservers()
        {
            string info = "";
            foreach (IObserver o in observers)
            {
               info += o.Update(mInfo);
            }
            return info;
        }

        public string GenerateMark()
        {
            Random rnd = new Random();
            mInfo.OOP = rnd.Next(0, 10);
            return NotifyObservers();
        }
    }
}
