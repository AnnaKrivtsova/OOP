using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public interface ITeach
    {
        string Teach();
    }

    class University : ITeach
    {
        public string Teach()
        {
            return "Обучение проходит в университете";
        }
    }

    public interface IDistanceTeach
    {
        string DistanceTeach();
    }

    class Distance : IDistanceTeach
    {
        public string DistanceTeach()
        {
            return "Обучение проходит дистанционно";
        }
    }

    class DistanceToTeachingAdapter : ITeach
    {
        Distance distance;
        public DistanceToTeachingAdapter(Distance c)
        {
            distance = c;
        }

        public string Teach()
        {
            return distance.DistanceTeach();
        }
    }
}
