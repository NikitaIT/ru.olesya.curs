using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.IO;

namespace ru.olesya.curs.Models
{
    public class Parser
    {
        //Получает путь к файлу и читает его
        public Parser(string fpath)
        {
            filepath = fpath;
            ReadTable(filepath);
        }
        // Читает по пути из файла в таблицу
        public void ReadTable(string fpath)
        {
            Tables.Clear();
            Console.Clear();
            Console.WriteLine("Чтение файла "+ "Table.txt из " + fpath);
            int counter=0, errorcounter = 0;
            string line;
            var file = new StreamReader(fpath + @"\Table.txt");
            while ((line = file.ReadLine()) != null)
            {
                counter++;
                //Добавление строк в таблицу, по одной
                if (!AddTable(line))
                {
                    Console.WriteLine("Структура файла с базой данных повреждена в строке {0}", counter);
                    errorcounter++;
                }
                Console.WriteLine(line);
            }
            file.Close();
            Console.WriteLine("Считано {0} из {1} строк.", counter - errorcounter, counter);
            Console.ReadLine();
        }
        //Добавление одной строки в таблицу
        public bool AddTable(string line)
        {
            var tableRow = line.Split(';');
            if (tableRow.Length.Equals(3))
            {
                Tables.Add(new Table(long.Parse(tableRow[0]), tableRow[1], double.Parse(tableRow[2])));
                return true;
            }
                return false;
        }
        public bool DeleteTable(Table table)
        {
            return Tables.Remove(table);
        }
        //Запись в файл(сохранение)
        public void WriteTables()
        {
            // Если вдруг понадобится в документы сохранять
            //var mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (var outputFile = new StreamWriter(filepath + @"\Table.txt", false))
            {
                foreach (var table in Tables)
                {

                    outputFile.WriteLine(table.ToString());
                }
            }
        }

        public void Print(int op)
        {
            switch (op)
            {
                
                case 1:
                    Tables.Sort(delegate(Table x, Table y)
                    {
                       return x.code.CompareTo(y.code);
                    });
                break;
                case 2:
                    Tables.Sort(delegate (Table x, Table y)
                    {
                        return x.type.CompareTo(y.type);
                    });
                    break;
                case 3:
                    Tables.Sort(delegate (Table x, Table y)
                    {
                        return x.price.CompareTo(y.price);
                    });
                    break;
                case 4:
                    Tables.Reverse();
                    break;

            }
            foreach (var table in Tables)
            {
                Console.WriteLine(table.ToString());
            }

        }
        private string filepath = "";//Путь к файлу(присваевается в конструкторе класса)
        public static List<Table> Tables = new List<Table>(); //Таблица
        public static List<Table> ATables { get { return Tables; } set {} }//функции считки и записи поля Tables
    }
}