using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Data;
using System.Xml.Linq;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace _2lab
{
    [Serializable]
    [XmlType("student")]
    public class Student : IStudent,IPerson
    {
        public Student(){}
        public Student(string firstName, string surname, string lastName,
            string specType, int group, int course, int average, int experience) : this()
        {
            FirstName = firstName;
            Surname = surname;
            LastName = lastName;
            SpecType = specType;
            Group = group;
            Course = course;
            Average = average;
            workplace = new WorkPlace(experience);
        }
        public Student(string firstName, string surname, string lastName, int age,
            string specType, string genderType, int group, int course, int average, DateTime birthday, 
            string City, string Street, int House, int Flat, int Index, string Company, string Position,int Experience) : this()
        {
            FirstName = firstName;
            Surname = surname;
            LastName = lastName;
            Age = age;
            SpecType = specType;
            GenderType = genderType;
            Group = group;
            Course = course;
            Average = average;
            Birthday = birthday;
            address = Student.addAddress(City, Street, House, Flat, Index);
            workplace = Student.addWorkplace(Company, Position, Experience);
        }
        public string position => "Студент";
        public string GetInfoPerson() => position;

        public Student Clone()
        {
            return new Student(this.FirstName, this.Surname,this.LastName,this.SpecType, this.Group, this.Course,this.Average,this.workplace.Experience);
        }
        public string GetInfo()
        {
            return $"Создан студент:\n {FirstName}\n {Surname}\n {LastName}\n {SpecType}\n {Group}\n {Course}\n {Average}\n {workplace.Experience}";
        }

        private string _university = "BSTU";
        private string _country = "Belarus";

        public void SetUniversity(string _university)
        {
            this._university = _university;
        }

        public void SetCountry(string _country)
        {
            this._country = _country;
        }

        public StudentMomento SaveState()
        {
            return new StudentMomento(_country,_university);
        }

        // восстановление состояния
        public string RestoreState(StudentMomento memento)
        {
            this._country = memento.Country;
            this._university = memento.University;
            return $"Страна: {_country}\nУниверситет: {_university}";
        }

        public string GetAddInfo()
        {
            return $"Страна: {_country}\nУниверситет: {_university}";
        }

        //public void SetState(StudentMomento memento)
        //{
        //    this._country = memento.Data;
        //}

        //public StudentMomento GetState()
        //{
        //    var data = $"{_university}:{_country}";
        //    return new StudentMomento(data);
        //}

        [XmlElement(ElementName = "name")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "surname")]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }
        [XmlElement(ElementName = "lastname")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [XmlElement(ElementName = "age")]
        [Range(1, 100)]
        public int Age { get; set; }
        [XmlElement(ElementName = "specType")]
        public string SpecType { get; set; }
        [XmlElement(ElementName = "genderType")]
        public string GenderType { get; set; }
        [XmlElement(ElementName = "group")]
        [Range(1, 10)]
        public int Group { get; set; }
        [XmlElement(ElementName = "course")]
        [Range(1, 4)]
        public int Course { get; set; }
        [XmlElement(ElementName = "average")]
        [Range(1, 10)]
        public int Average { get; set; }
        [XmlElement(ElementName = "birthday")]
        public DateTime Birthday { get; set; }
        [XmlElement(ElementName = "address")]
        public Address address { get; set; }
        [XmlElement(ElementName = "workplace")]
        public WorkPlace workplace { get; set; }

        static public WorkPlace addWorkplace(string Company, string Position, int Experience)
        {
            var workplace = new WorkPlace(Company, Position, Experience);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(workplace);
            if (!Validator.TryValidateObject(workplace, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return workplace;
        }
        static public Address addAddress(string City, string Street, int House, int Flat, int Index)
        {
            var address = new Address(City, Street, House, Flat, Index);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(address);
            if (!Validator.TryValidateObject(address, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return address;
        }


    }
    [Serializable]
    [UserValidation]
    public class Address
    {
        [XmlElement(ElementName = "city")]
        public string City { get; set; }
        [XmlElement(ElementName = "street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "house")]
        public int House { get; set; }
        [XmlElement(ElementName = "flat")]
        public int Flat { get; set; }
        [XmlElement(ElementName = "index")]
        public int Index { get; set; }
        public Address() { }
        public Address(string City, string Street, int House, int Flat, int Index)
        {
            this.City = City;
            this.Street = Street;
            this.House = House;
            this.Flat = Flat;
            this.Index = Index;
        }
    }
    [Serializable]
    public class WorkPlace
    {
        [XmlElement(ElementName = "company")]
        public string Company { get; set; }
        [XmlElement(ElementName = "position")]
        public string Position { get; set; }
        [XmlElement(ElementName = "experience")]
        public int Experience { get; set; }
        
        public WorkPlace() { }
        public WorkPlace(string Company)
        {
            this.Company = Company;
        }
        public WorkPlace(int Experience)
        {
            this.Experience = Experience;
        }
        public WorkPlace(string Company, string Position, int Experience)
        {
            this.Company = Company;
            this.Position = Position;
            this.Experience = Experience;          
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
        public static void SerializeStudent<T>(Student obj, string filename)
        {
            XElement element = null;
            var objStudent = (Student)obj;
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                element = XElement.Load(stream);
            }
            
            XElement studentList = new XElement("student");
            element.Add(studentList);
            studentList.Add(new XElement("name", objStudent.FirstName), new XElement("surname", objStudent.Surname), new XElement("lastname", objStudent.LastName),
                new XElement("specType", objStudent.SpecType), new XElement("course", objStudent.Course), new XElement("average", objStudent.Average)
                , new XElement("group", objStudent.Group));
            XElement workPlace = new XElement("workplace");
            studentList.Add(workPlace);
            workPlace.Add(new XElement("experience", objStudent.workplace.Experience));

            element.Save(filename);
        }
        public static Student[] DeserializeArrayStudent<T>(string filename)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(Student[]), new XmlRootAttribute("students"));
            using (FileStream myFileStream = new FileStream(filename, FileMode.Open))
            {
                Student[] r;
                r = (Student[])mySerializer.Deserialize(myFileStream);
                return r;
            }
        }

        public static void SerializeWorkplace<Workplace>(WorkPlace obj, string filename)
        {
            XElement element = null;
            var objWorker = (WorkPlace)obj;
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                element = XElement.Load(stream);
            }
            element.Add( new XElement("company", objWorker.Company));

            element.Save(filename);
        }
        public static String DeserializeStudent<T>(string filename)
        {
            Student obj;
            String str;
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                obj = (Student)formatter.Deserialize(fs);
                    str = $"Имя - {obj.FirstName}\n" +
                        $"Фамилия - {obj.Surname}\n" +
                        $"Отчество - {obj.LastName}\n" +
                        $"Возраст - {obj.Age}\n" +
                        $"Специальность - {obj.SpecType}\n" +
                        $"Пол - {obj.GenderType}\n" +
                        $"Группа - {obj.Group}\n" +
                        $"Курс - {obj.Course}\n" +
                        $"Средний балл - {obj.Average}\n" +
                        $"Дата рождения - {obj.Birthday}\n" +
                        $"Адрес:\n" +
                        $"Город - {obj.address.City}\n" +
                        $"Улица - {obj.address.Street}\n" +
                        $"Дом - {obj.address.House}\n" +
                        $"Квартира - {obj.address.Flat}\n" +
                        $"Индекс - {obj.address.Index}\n"+
                        $"Место работы:\n" +
                    $"Компания - {obj.workplace.Company}\n" +
                    $"Должность - {obj.workplace.Position}\n" +
                    $"Опыт работы - {obj.workplace.Experience}\n";
            }
            return str;
        }
        
    }
}
