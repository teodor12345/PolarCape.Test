using Services;
using System;

namespace Test.APP
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new StudentService();
            userService.Register();
            Console.ReadLine();
        }
    }
}
