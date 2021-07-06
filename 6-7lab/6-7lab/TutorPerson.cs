using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _6_7lab
{
    [Serializable]
    [XmlType("tutor")]
    public class TutorPerson : DependencyObject
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "surname")]
        public string Surname { get; set; }

        [XmlElement(ElementName = "lastname")]
        public string Lastname { get; set; }

        [XmlElement(ElementName = "age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "language")]
        public string Lenguage { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "photo")]
        public string Photo { get; set; }

        [XmlElement(ElementName = "rating")]
        public int Rating
        {
            get { return (int)GetValue(RaitingProperty); }
            set { SetValue(RaitingProperty, value); }
        }

        [XmlElement(ElementName = "price")]
        public double Price { get; set; }

        public TutorPerson() { }
        public TutorPerson(int id,string name, string surname, string lastname, int age,
            string language, string description, string photo, int rating, double price) : this()
        {
            Id = id;
            Name = name;
            Surname = surname;
            Lastname = lastname;
            Age = age;
            Lenguage = language;
            Description = description;
            Photo = photo;
            Rating = rating;
            Price = price;
        }

        public static readonly DependencyProperty RaitingProperty;

        static TutorPerson()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            RaitingProperty = DependencyProperty.Register("Rating", typeof(int), typeof(TutorPerson), metadata,
                new ValidateValueCallback(ValidateValue));
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue > 100)  // если больше 100, возвращаем 100
                return 100;
            return currentValue; // иначе возвращаем текущее значение
        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0) // если текущее значение от нуля и выше
                return true;
            return false;
        }
    }

    public static class XmlSerializeWrapper
    {
        public static void Serialize<T>(T obj, string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public static void SerializeTutor<T>(TutorPerson obj, string filename)
        {
            XElement element = null;
            var objTutor = (TutorPerson)obj;
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                element = XElement.Load(stream);
            }

            XElement tutortList = new XElement("tutor");
            element.Add(tutortList);
            tutortList.Add(new XElement("id", objTutor.Id),
                new XElement("name", objTutor.Name), new XElement("surname", objTutor.Surname), new XElement("lastname", objTutor.Lastname),
                new XElement("age", objTutor.Age), new XElement("language", objTutor.Lenguage), new XElement("description", objTutor.Description), 
                new XElement("photo", objTutor.Photo), new XElement("rating", objTutor.Rating), new XElement("price", objTutor.Price));
            element.Save(filename);
        }

        public static TutorPerson[] DeserializeArrayTutors(string filename)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(TutorPerson[]), new XmlRootAttribute("tutors"));
            using (FileStream myFileStream = new FileStream(filename, FileMode.Open))
            {
                TutorPerson[] r;
                r = (TutorPerson[])mySerializer.Deserialize(myFileStream);
                return r;
            }
        }

        public static String DeserializeTutor<T>(string filename)
        {
            TutorPerson obj;
            String str = "";
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                obj = (TutorPerson)formatter.Deserialize(fs);
                var name = obj.Name;
                var surname = obj.Surname;
                var lastname = obj.Lastname;
                var age = obj.Age;
                var lenguage = obj.Lenguage;
                var description = obj.Description;
                var photo = obj.Photo;
                var rating = obj.Rating;
                var price = obj.Price;
            }
            return str;
        }

    }
}