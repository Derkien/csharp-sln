using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GB1Lesson8.DBModel
{
    internal class StudentRepository
    {
        public const string AvailableDbFileExtensionsFilter = "Только *.XML|*.XML";

        private readonly string Filename;

        public StudentRepository(bool stateIsSaved = true)
        {
            StateIsSaved = stateIsSaved;
        }

        private StudentRepository(string filename) : this()
        {
            Filename = filename;
        }

        public bool StateIsSaved { get; set; }

        public static StudentRepository BindToFile(string filename) => new StudentRepository(filename);

        public List<Student> GetEmptyStudentsLIst()
        {
            StateIsSaved = false;

            return new List<Student>() { };
        }
        public List<Student> LoadStudents()
        {
            using (Stream fStream = new FileStream(Filename, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));

                var list = (List<Student>)xmlFormat.Deserialize(fStream);

                StateIsSaved = true;

                return list;
            }
        }

        public void SaveStudents(List<Student> students)
        {
            using (Stream fStream = new FileStream(Filename, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));

                xmlFormat.Serialize(fStream, students);

                StateIsSaved = true;
            }
        }
    }
}
