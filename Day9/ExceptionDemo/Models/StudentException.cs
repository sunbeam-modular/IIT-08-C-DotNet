namespace validationDemo.Models
{
     public class StudentNotFoundException : Exception
        {
            public StudentNotFoundException(string message) : base(message)
            {
            }
        }
    
}
