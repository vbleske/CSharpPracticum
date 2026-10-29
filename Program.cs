using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Menu;
namespace CSharpPracticum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new MenuRunner();
            menu.Run();
        }
    }
}