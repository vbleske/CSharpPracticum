using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TaskInfoAttribute : Attribute
    {
        public int Number { get; }
    public TaskInfoAttribute(int number)
        {
            Number = number;
        }
    }
}