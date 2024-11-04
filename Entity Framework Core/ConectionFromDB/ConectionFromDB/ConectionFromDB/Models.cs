using System.Collections.Generic;

namespace SoftUniApp
{
    public class Employee
    {
        public Employee()
        {
            this.Departments = new HashSet<Department>();
            this.InverseManager = new HashSet<Employee>();
            this.EmployeesProjects = new HashSet<EmployeeProject>();
        }

        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public decimal Salary { get; set; }

        public string JobTitle { get; set; } = null!;

        public DateTime HireDate { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;

        public int? ManagerId { get; set; }

        public virtual Employee? Manager { get; set; }

        public int? AddressId { get; set; }

        public virtual Address? Address { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<Employee> InverseManager { get; set; }

        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
    }

    public class Address
    {
        public Address()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int AddressId { get; set; }

        public string AddressText { get; set; } = null!;

        public int? TownId { get; set; }

        public virtual Town? Town { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }

        public string Name { get; set; } = null!;

        public int ManagerId { get; set; }

        public virtual Employee Manager { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public partial class Town
    {
        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int TownId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
    }

    public class Project
    {
        public Project()
        {
            this.EmployeesProjects = new HashSet<EmployeeProject>();
        }

        public int ProjectId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }
    }

    public class EmployeeProject
    {
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}

