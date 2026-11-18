using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    public class Employee : Person
    { // 2. Encapsulation: حقول خاصة (Private Fields) مخفية عن الخارج لحماية البيانات
        private decimal _salary;

        // الخصائص الأساسية للموظف
        public int Id { get; set; }
        
        public decimal Salary
        {
            get { return _salary; }
            set
            {
                // منع إدخال راتب سالب
                if (value < 0)
                    throw new ArgumentException("الراتب لا يمكن أن يكون قيمة سالبة.");
                _salary = value;
            }
        }
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
