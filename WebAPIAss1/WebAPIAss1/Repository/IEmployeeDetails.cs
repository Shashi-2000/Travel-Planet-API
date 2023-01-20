using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIAss1.Models;

namespace WebAPIAss1.Repository
{
    public interface IEmployeeDetails
    {
        List<EmployeeModel> getAllEmployees();
        EntityEmployee getEmployeeByID(int id);
        string updateEmployees(EmployeeModel employee);
        string deleteEmployee(int id);
        string insertEmployee(EmployeeModel newEmployee);
        string insertBulkEmployees(List<EmployeeModel> employees);
        string modifyAgeColumn();
        string deleteTableData();
    }
    class EmployeeDetails : IEmployeeDetails
    {
        
        
         
        List<EmployeeModel> IEmployeeDetails.getAllEmployees()
        {
            Student_AssigEntities sa = new Student_AssigEntities();
            List<EmployeeModel> employeeRecords = sa.EntityEmployees.Select(e => new EmployeeModel()
            {
                EmployeeID = e.EmployeeID,
                Name = e.Name,
                Age = e.Age,
                Address = e.Address,
                Email = e.Email,
                MobileNumber = e.MobileNumber,

            }).ToList<EmployeeModel>();
            sa.Dispose();
            return employeeRecords;
        }
        EntityEmployee IEmployeeDetails.getEmployeeByID(int id)
        {
            Student_AssigEntities sa = new Student_AssigEntities();
            EntityEmployee employeeByID = sa.EntityEmployees.FirstOrDefault(e => e.EmployeeID == id);
            sa.Dispose();
            return employeeByID;
        }
        string IEmployeeDetails.updateEmployees(EmployeeModel employee)
        {
            Student_AssigEntities sa = new Student_AssigEntities();
            var existingStudent = sa.EntityEmployees.Where(e => e.EmployeeID == employee.EmployeeID).FirstOrDefault();
            if(existingStudent != null)
            {
                //existingStudent.Salary = employee.Salary;
                existingStudent.MobileNumber = employee.MobileNumber;
                sa.SaveChanges();
                sa.Dispose();
                return "Updated";
            }
            sa.SaveChanges();
            sa.Dispose();
            return "Not Updated";
        }

        string IEmployeeDetails.deleteEmployee(int id)
        {
            Student_AssigEntities sa = new Student_AssigEntities();
            var deleteEmplyee = sa.EntityEmployees.Where(e => e.EmployeeID == id).FirstOrDefault();
            if(deleteEmplyee != null)
            {
                sa.EntityEmployees.Remove(deleteEmplyee);
            }
            sa.SaveChanges();
            sa.Dispose();
            return "Employee Deleted";
        }
        string IEmployeeDetails.insertEmployee(EmployeeModel newEmployee)
        {
            Student_AssigEntities sa = new Student_AssigEntities();
            var existingEmployee = sa.EntityEmployees.Where(e => e.EmployeeID == newEmployee.EmployeeID).FirstOrDefault();
            if(existingEmployee == null)
            {
                sa.EntityEmployees.Add(new EntityEmployee
                {
                    EmployeeID = newEmployee.EmployeeID,
                    Name = newEmployee.Name,
                    Age = newEmployee.Age,
                    Address = newEmployee.Address,
                    Email = newEmployee.Email,
                    MobileNumber = newEmployee.MobileNumber
                });
            }
            sa.SaveChanges();
            sa.Dispose();
            return "Employee Inserted";
        }

        string IEmployeeDetails.insertBulkEmployees(List<EmployeeModel> employees)
        {
            Student_AssigEntities sa = new Student_AssigEntities();
            if(employees.Count != 0)
            {
                foreach(var emp in employees){
                    var existing = sa.EntityEmployees.Where(e => e.EmployeeID == emp.EmployeeID).FirstOrDefault();
                    if(existing == null)
                    {
                        sa.EntityEmployees.Add(new EntityEmployee
                        {
                            EmployeeID = emp.EmployeeID,
                            Name = emp.Name,
                            Age = emp.Age,
                            Address = emp.Address,
                            Email = emp.Email,
                            MobileNumber = emp.MobileNumber
                        });
                    }
                }
                sa.SaveChanges();
                sa.Dispose();
                return "Bulk Employees Inserted";
            }
            sa.SaveChanges();
            sa.Dispose();
            return "Data Not Inserted";
        }
        string IEmployeeDetails.modifyAgeColumn()
        {
            Student_AssigEntities sa = new Student_AssigEntities();
            foreach(var emp in sa.EntityEmployees)
            {
                emp.Age +=  2;
            }
            sa.SaveChanges();
            sa.Dispose();
            return "Age Updated";
        }

        string IEmployeeDetails.deleteTableData()
        {
            Student_AssigEntities sa = new Student_AssigEntities();
            foreach(var emp in sa.EntityEmployees)
            {
                sa.EntityEmployees.Remove(emp);
            }
            sa.SaveChanges();
            sa.Dispose();
            return "Table Data Erased";
        }
    }
}
