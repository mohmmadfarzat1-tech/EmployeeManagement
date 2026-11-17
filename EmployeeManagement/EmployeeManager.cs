using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement
{
    // 10. تعريف الـ Delegate الخاص بإضافة موظف
    public delegate void EmployeeNotificationHandler(string message);

    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        // كائن من الـ Delegate لاستدعائه عند الإضافة
        public EmployeeNotificationHandler OnEmployeeAdded;

        // 11. تعريف الـ Event الخاص بحذف موظف
        public event EmployeeNotificationHandler OnEmployeeDeleted;

        // 1. إضافة موظف جديد + استدعاء الـ Delegate
        public void AddEmployee(Employee emp)
        {
            if (employees.Any(x => x.Id == emp.Id))
            {
                Console.WriteLine("خطأ: يوجد موظف مسجل بنفس الرقم التعريفي مسبقاً.");
                return;
            }

            employees.Add(emp);

            // استدعاء الـ Delegate إذا كان مرتبطاً بدالة
            OnEmployeeAdded?.Invoke($"Employee Added Successfully: {emp.FullName}");
        }

        // 2. عرض جميع الموظفين (باستخدام دالة DisplayInfo الموروثة)
        public void ViewEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("لا يوجد موظفون مسجلون حالياً.");
                return;
            }

            Console.WriteLine("\n--- قائمة الموظفين ---");
            foreach (var emp in employees)
            {
                emp.DisplayInfo();
            }
        }

        // 3 & 8. البحث عن موظف مع رمي خطأ إذا لم يكن موجوداً لالتقاطه بـ try-catch
        public Employee SearchEmployeeById(int id)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
            {
                throw new KeyNotFoundException($"الموظف صاحب الرقم ({id}) غير موجود في النظام.");
            }
            return emp;
        }

        // 4, 8 & 11. حذف موظف + إطلاق الـ Event + رمي خطأ إذا لم يوجد
        public void DeleteEmployee(int id)
        {
            // نستخدم دالة البحث؛ إذا لم تجده سترمي استثناءً مباشرة
            var emp = SearchEmployeeById(id);

            employees.Remove(emp);

            // إطلاق الـ Event عند نجاح الحذف
            OnEmployeeDeleted?.Invoke($"Employee Deleted: {emp.FullName} (ID: {id})");
        }

        // 5. تعديل بيانات موظف
        public void UpdateEmployee(int id, string newName, int newAge, decimal newSalary, string newDept)
        {
            var emp = SearchEmployeeById(id);

            emp.FullName = newName;
            emp.Age = newAge;
            emp.Salary = newSalary;
            emp.Department = newDept;
            Console.WriteLine("تم تحديث بيانات الموظف بنجاح.");
        }

        // 6. استخدام Dictionary لحساب عدد الموظفين في كل قسم
        public void DisplayDepartmentCounts()
        {
            Dictionary<string, int> deptCounts = new Dictionary<string, int>();

            foreach (var emp in employees)
            {
                if (deptCounts.ContainsKey(emp.Department))
                {
                    deptCounts[emp.Department]++;
                }
                else
                {
                    deptCounts[emp.Department] = 1;
                }
            }

            Console.WriteLine("\n--- عدد الموظفين حسب القسم ---");
            foreach (var item in deptCounts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        // 7 & 9. عمليات LINQ باستخدام Lambda Expressions

        // أ. أعلى راتب
        public Employee GetHighestSalaryEmployee()
        {
            return employees.OrderByDescending(x => x.Salary).FirstOrDefault();
        }

        // ب. متوسط الرواتب
        public decimal GetAverageSalary()
        {
            if (employees.Count == 0) return 0;
            return employees.Average(x => x.Salary);
        }

        // ج. جميع موظفي قسم معين
        public List<Employee> GetEmployeesByDepartment(string department)
        {
            return employees.Where(x => x.Department.Equals(department, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // د. ترتيب الموظفين حسب الراتب تنازلياً
        public List<Employee> OrderBySalaryDesc()
        {
            return employees.OrderByDescending(x => x.Salary).ToList();
        }
    }
}