using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    public class Employee :person
    {  // الخصائص الأساسية للموظف
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }


        //مشيد (constructor) فارغ لتسهيل إنشاء الكائن
        public Employee() { }

        // مشيد لاستقبال البيانات مباشرة عند إنشاء موظف جديد

        public Employee(int id, string fullName, int age, decimal salary, string department)
            :base(fullName, age)
       
        {
            Id = id;
           Salary = salary;
           Department = department;
        }

        //إعادة تعريف دالة العرض (Polymorphism)
        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id} | Name:{FullName} | Age:{Age} | Department:{Department}| Salary:{Salary:C}");
        }

        // دالة لطباعة بيانات الموظف بشكل منسق
        public override string ToString()
        {

            return $"ID:{Id} | Name: {FullName} | Age:{Age} |Department: {Department} | Salary:{Salary:C}";
        }



    }
}
