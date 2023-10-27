using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace AdvancedTask2
{
    public class StudentList<T> where T : Student
    {
        List<T> students = new List<T>();
        public void AddStudent(T student)
        {
            students.Add(student);
        }

        public T GetStudentById(int id)
        {
            T student = students.FirstOrDefault(x => x.RollNumber == id);
            return student;
        }

        public List<T> GetStudentByName(string name)
        {
            List<T> foundStudents = students.Where(x => x.Name == name).ToList();
            return foundStudents;
        }

        public string Serialize()
        {
            string jsonString = JsonSerializer.Serialize(students);
            return jsonString;
        }

        public List<Student> DeSerialize(string filePath)
        { 
            if (File.Exists(filePath)) {
                string jsonFile = File.ReadAllText(filePath);
                List<Student> deserializedList = JsonSerializer.Deserialize<List<Student>>(jsonFile);
                return deserializedList;
            }
            return null;
        }

    }
}
    