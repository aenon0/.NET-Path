using AdvancedTask2;

StudentList<Student> obj = new StudentList<Student>();
obj.AddStudent(new Student(1, "Mr.A", 10, "F"));
obj.AddStudent(new Student(2, "Mr.A", 11, "F" ));
obj.AddStudent(new Student(3, "Mr.B", 9,  "D" ));
obj.AddStudent(new Student(4, "Mr.C", 9, "D" ));

Console.WriteLine("Getting student by id: ");
var student = obj.GetStudentById(4);
Console.WriteLine($"Rollnumber: {student.RollNumber} Name: {student.Name} Age: {student.Age} Grade: {student.Grade}");


Console.WriteLine("Getting student by name: ");
var students = obj.GetStudentByName("Mr.A");
foreach(var stud in students)
{
    Console.WriteLine($"Rollnumber: {stud.RollNumber} Name: {stud.Name} Age: {stud.Age} Grade: {stud.Grade}");       //gives { Name = "Mr.C", Age = 9, Grade = "D" }
}


Console.WriteLine("Serializing the list of students to json: ");
var serialized = obj.Serialize();
Console.WriteLine(serialized);


Console.WriteLine("Deserializing text in json file to list of students: ");
var filePath = "C:\\Users\\HP\\source\\repos\\AdvancedTask2\\AdvancedTask2\\file.json";
var deserialized = obj.DeSerialize(filePath);
foreach(var stud in deserialized)
{
    Console.WriteLine($"Rollnumber: {stud.RollNumber} Name: {stud.Name} Age: {stud.Age} Grade: {stud.Grade}");
}

