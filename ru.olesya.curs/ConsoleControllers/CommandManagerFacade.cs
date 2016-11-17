using System;
using ru.olesya.curs.Models;

namespace ru.olesya.curs.ConsoleControllers
{
    /**
     * Класс управляющий всем
     * @param menu Для общения в консоли
     * @param parser Для создания Цельной Таблицы
     * @param tablesHashMap Для создания карты хешей
     */
    public class CommandManagerFacade
    {
        private readonly Menu menu;
        private readonly Parser parser;
        private TablesHashMap tablesHashMap;

        public CommandManagerFacade(Menu menu, Parser parser)
        {
            this.menu = menu;
            this.parser = parser;
            tablesHashMap = new TablesHashMap(parser);
        }
        /*
         * Главный цикл прогаммы 
         */
        public void Start()
        {
            var isRun = true;
            while (isRun)
            {
                tablesHashMap.WriteDictionary();
                switch (menu.ViewMenu())
                {
                    case (int) MenuBtn.GENERATION_HASH_TABLE:
                    {
                        menu.GeneratingHashTable();
                        tablesHashMap = new TablesHashMap(parser);
                        Console.WriteLine("Таблица сгенерированна, нажмите любую клавишу чтобы продолжить ...");
                        Console.ReadKey();
                    }
                        break;
                    case (int) MenuBtn.ADD:
                    {
                        parser.AddTable(menu.Add());
                        tablesHashMap = new TablesHashMap(parser);
                    }
                        break;
                    case (int) MenuBtn.FIND:
                    {
                        var tableRow = menu.Find().Split(';');
                        if (tableRow.Length.Equals(3))
                        {
                            var listofTable =
                                tablesHashMap.Find(new Table(long.Parse(tableRow[0]), tableRow[1],
                                    double.Parse(tableRow[2])));
                                if (listofTable !=null)
                            foreach (var table in listofTable)
                                Console.WriteLine(table.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Что то пошло не так, вводите всё по инструкции ...");
                        }
                        Console.ReadKey();
                    }
                        break;
                    case (int) MenuBtn.DELETE:
                    {
                        var tableRow = menu.Delete().Split(';');
                        if (tableRow.Length.Equals(3))
                            if (
                                tablesHashMap.Delete(new Table(long.Parse(tableRow[0]), tableRow[1],
                                    double.Parse(tableRow[2]))))
                            {
                                    parser.DeleteTable(new Table(long.Parse(tableRow[0]), tableRow[1],
                                    double.Parse(tableRow[2])));
                                    Console.WriteLine("Удалено или не существует ");
                                }
                                
                            else
                                Console.WriteLine("Не удалено");
                        else
                            Console.WriteLine("Что то пошло не так, вводите всё по инструкции ...");
                        Console.ReadKey();
                    }
                        break;
                    case (int) MenuBtn.SAVE:
                    {
                        menu.Save();
                        parser.WriteTables();
                    }
                        break;
                    case (int) MenuBtn.EXET:
                    {
                        menu.Exit();
                        isRun = false;
                    }
                        break;
                    case (int)MenuBtn.SORT:
                        {
                            parser.Print(menu.Sort());
                            Console.ReadKey();
                        }
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                Console.Clear();
            }
        }

        public void Stop()
        {
            menu.Save();
            parser.WriteTables();
        }
    }
}