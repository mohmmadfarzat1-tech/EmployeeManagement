using System.Xml.Linq;

namespace EmployeeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();


            bool running = true; // متغير للتحكم في بقاء البرنامج قيد التشغيل

            while (running)
            {
                
                Console.WriteLine("--- Main Menu ---");
                Console.WriteLine("1- Add Employee");
                Console.WriteLine("2- View Employees");
                Console.WriteLine("3- Search Employee");
                Console.WriteLine("4- Update Employee");
                Console.WriteLine("5- Delete Employee");
                Console.WriteLine("6- Department Statistics");
                Console.WriteLine("7- Salary Statistics");
                Console.WriteLine("8- Exit");
                Console.Write("Choose an option (1-8): ");

                // قراءة اختيار المستخدم من الشاشة السوداء
                string choice = Console.ReadLine();

                // توجيه البرنامج حسب الرقم المختار
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Full Name: ");
                        string fullName = Console.ReadLine();

                        int age = 0;
                        try
                        {
                            Console.Write("Enter Age: ");
                            age = int.Parse(Console.ReadLine());
                        }
                        catch 
                        {
                            Console.WriteLine("خطأفي إدخال العمر");
                        }
                        decimal salary = 0;
                        try
                        {
                            Console.Write("Enter Salary: ");
                            salary = decimal.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("خطأ في إدخال الراتب! يجب إدخال أرقام فقط.");
                            break; // يوقف الإضافة ويعود للقائمة الرئيسية
                        }

                        // 4. قراءة القسم
                        Console.Write("Enter Department: ");
                        string dept = Console.ReadLine();

                        // 5. إنشاء الموظف وإضافته للقائمة
                        Employee newEmp = new Employee(id, fullName, age, salary, dept);
                        manager.AddEmployee(newEmp);
                        break;
                        



                    case "2":
                        manager.ViewEmployees();
                        break;



                    case "3":
                    
                        try
                        {
                            // 1. نطلب من المستخدم إدخال رقم الموظف للبحث عنه
                            Console.Write("Enter Employee ID to search: ");
                            int searchId = int.Parse(Console.ReadLine());

                            // 2. نستدعي دالة البحث من مدير الموظفين
                            Employee foundEmp = manager.SearchEmployeeById(searchId);

                            // 3. إذا وجده، نطبع بياناته على الشاشة
                            Console.WriteLine("\n--- Employee Found ---");
                            foundEmp.DisplayInfo();
                        }
                        catch (KeyNotFoundException ex)
                        {
                            // إذا كان الموظف غير موجود، يمسك الخطأ الذي رمته دالة البحث ويطبع الرسالة
                            Console.WriteLine($"[خطأ في البحث]: {ex.Message}");
                        }
                        catch (FormatException)
                        {
                            // إذا أدخل المستخدم حروفاً بدلاً من رقم تعريفي صحيح
                            Console.WriteLine("[خطأ في الإدخال]: يرجى إدخال رقم صحيح!");
                        }
                        break;
                        
                    case "4":
                    
                        try
                        {
                            // 1. قراءة رقم الموظف المراد تعديله
                            Console.Write("Enter Employee ID to update: ");
                            int updateId = int.Parse(Console.ReadLine());

                            // 2. التأكد أولاً أن الموظف موجود في القائمة (إذا لم يوجد سيرمي خطأ وينتقل للـ catch)
                            manager.SearchEmployeeById(updateId);

                            // 3. قراءة الاسم الجديد
                            Console.Write("Enter New Full Name: ");
                            string newName = Console.ReadLine();

                            // 4. قراءة العمر الجديد باستخدام try-catch
                            int newAge = 0;
                            try
                            {
                                Console.Write("Enter New Age: ");
                                newAge = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("خطأ في إدخال العمر! يجب إدخال أرقام فقط.");
                                break;
                            }

                            // 5. قراءة الراتب الجديد باستخدام try-catch
                            decimal newSalary = 0;
                            try
                            {
                                Console.Write("Enter New Salary: ");
                                newSalary = decimal.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("خطأ في إدخال الراتب! يجب إدخال أرقام فقط.");
                                break;
                            }

                            // 6. قراءة القسم الجديد
                            Console.Write("Enter New Department: ");
                            string newDept = Console.ReadLine();

                            // 7. إرسال البيانات الجديدة لدالة التعديل
                            manager.UpdateEmployee(updateId, newName, newAge, newSalary, newDept);
                        }
                        catch (KeyNotFoundException ex)
                        {
                            // إذا كان رقم الموظف غير موجود أصلاً
                            Console.WriteLine($"[خطأ في التعديل]: {ex.Message}");
                        }
                        catch (FormatException)
                        {
                            // إذا أدخل حروفاً في خانة رقم الموظف ID
                            Console.WriteLine("[خطأ في الإدخال]: يرجى إدخال رقم تعريفي صحيح!");
                        }
                        break;



                        
                    case "5":
                    
                        try
                        {
                            Console.Write("أدخل رقم الموظف (ID) المراد حذفه: ");
                            int deleteId = int.Parse(Console.ReadLine());

                            manager.DeleteEmployee(deleteId);
                            Console.WriteLine("تم حذف الموظف بنجاح.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("خطأ: يرجى إدخال رقم صحيح.");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine($"خطأ: {ex.Message}");
                        }
                        break;
                        



                    case "6":
                    
                        Console.WriteLine("-> You selected: Department Statistics");
                        manager.ShowDepartmentStatistics();
                        break;
                        
                    
                    case "7":
                        Console.WriteLine("-> You selected: Salary Statistics");
                        manager.ShowSalaryStatistics();
                        
                        break;
                    case "8":
                        running = false; // إيقاف الحلقة وإغلاق البرنامج
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid number! Please choose from 1 to 8.");
                        break;
                }
            }
        }
    }
}