using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    public class Person
    {
        private int _age;

        //الخصائص المشتركة لأي شخص 
        public string FullName { get; set; }
        public int Age { 
            get { return _age; }
            set 
            {
                // منع إدخال عمر غير منطقي
                if (value < 18 || value > 100)
                    throw new ArgumentException("العمر يجب أن يكون بين 18 و 100 سنة.");
                _age = value;
            }
        }

        //مشيد فارغ
        public Person() { }

        //مشيد يستقبل الإسم والعمر
        public Person(string fullName, int age) 
        {
            FullName = fullName;
            Age = age;
        }
        //دالة قابلة لإعادة التعريف
        public virtual void DisplayInfo()
        {
           Console.WriteLine($"Name: {FullName}| Age: {Age}");
        }
    }
}
