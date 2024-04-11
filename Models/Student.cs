using System.ComponentModel.DataAnnotations;

namespace CRUD_Using_One_To_Many_Relationship.Models
{
    public class Student
    {
        [Key]
        public int Sno { set; get; }
        public string? Sname { set; get; }
        public int Fee { set; get; }

        public int DepartmentId { set; get; }

        //Navigtion property

        public Department Department { set; get; }
    }
}
