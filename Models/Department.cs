namespace CRUD_Using_One_To_Many_Relationship.Models
{
    public class Department
    {
        public int DepartmentId { set; get;}
        public string? DeptName { set; get; }

        //Navigation property

        public ICollection<Student> Students { set; get; }
    }
}
