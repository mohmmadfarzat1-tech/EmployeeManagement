using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    internal class person
    {
        //الخصائص المشتركة لأي شخص 
        public string FullName { get; set; }
        public int Age {  get; set; }

        //مشيد فارغ
        public person() { }

        //مشيد يستقبل الإسم والعمر
        public person(string fullName, int age) 
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
