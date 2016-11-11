using System;
using ru.olesya.curs.ConsoleControllers;
using ru.olesya.curs.Models;

namespace ru.olesya.curs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filepath = @"C:\Users\NIKIT\OneDrive\Documents\Visual Studio 2015\Projects\ConsoleApplication5";
            var menu = new Menu();
            var parser = new Parser(filepath);

            var ide = new CommandManagerFacade(menu, parser);

            var programmer = new Client();
            programmer.CreateApplication(ide);

            Console.Read();
        }
    }
}