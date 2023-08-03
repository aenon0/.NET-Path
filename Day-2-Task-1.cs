
double GetValueOfGrade(string grade) {
    double value = 0.00d;
    if (grade.StartsWith("A") || grade == "A+") { value =  4.00d; }
    else if (grade.StartsWith("A-")) { value = 3.75d;}
    else if (grade.StartsWith("B+")) { value = 3.50d;} 
    else if (grade.StartsWith("B")) { value = 3.00d; }
    else if (grade.StartsWith("B-")) { value = 2.75d;}
    else if (grade.StartsWith("C+")) { value = 2.00d;}
    else if (grade.StartsWith("C")) { value = 1.50d;}
    else if (grade.StartsWith("C-")) { value = 1.25d;}
    else if (grade.StartsWith("D+")) { value = 1.00d;}
    else if (grade.StartsWith("D-")) { value = 0.50d;}
    return value;
}
///////////////////////////////////////////////////////////////////////////////////////
double CalculateGrade(List<string> grades, List<double> creditHours)
{
    double result = 0;
    for (int idx = 0; idx < grades.Count; idx++)
    {
        result += (GetValueOfGrade(grades[idx]) * creditHours[idx]);
    }
    result /= (creditHours.Sum());
    Console.WriteLine("Grade: " + result);
    return result;
}
///////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine("Welcome to the grade calculator console app.\n Put you grade and its credit hour respectively. Type 's'//'S' to stop entering.");
List<String> grades = new List<String>();
List<double> creditHours = new List<double>();
while (true)
{
    string input = Console.ReadLine().Trim();
    if (input.StartsWith("S") || input.StartsWith("s"))
    {
        break;
    }
    else if (input.Length < 2)
    {
        Console.WriteLine("Wrong entry");
    }
    else
    {
        try
        {
            string grade = input.Substring(0, input.Length - 1);
            double creditHour = Convert.ToDouble(Convert.ToInt32(input[input.Length - 1]));
            grades.Add(grade);
            creditHours.Add(creditHour);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }
}
CalculateGrade(grades, creditHours);

