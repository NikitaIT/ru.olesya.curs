using System;

namespace ru.olesya.curs.ConsoleControllers
{
    /**
     * Класс пишет меню в консоль, и его методы возвращают пользовательский ввод
     */
    public class Menu
    {
        public int ViewMenu()
        {
            Console.WriteLine("Что бы вы хотели выбрать?\n" +
                                "1. Генерирование хеш-таблицы\n" +
                                "2. Добавление элемента\n" +
                                "3. Поиск элемента\n" +
                                "4. Удаление элемента\n" +
                                "5. Сохранение кода\n" +
                                "6. Выход из программы\n" +
                                "7. Сортировки\n");
            string a = null;
            int result;
            while (!int.TryParse(a, out result)) a = Console.ReadLine();
            return result;
        }
        public void GeneratingHashTable()
        {
            Console.WriteLine("Генерирование хеш-таблицы");
        }
        public string Add()
        {
            Console.WriteLine("Добавление элемента\n" + "Введите в формате 10;qw dw q;12,3");
            return Console.ReadLine();
        }
        public string Find()
        {
            Console.WriteLine("Поиск элемента \n"+"Введите в формате 10;qw dw q;12,3");
            return Console.ReadLine();
        }
        public string Delete()
        {
            Console.WriteLine("Удаление элемента\n"+"Введите в формате 10; qw dw q; 12,3");
            return Console.ReadLine();
        }
        public void Save()
        {
            Console.WriteLine("Сохранение кода\n" +"Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
        }
        public void Exit()
        {
            for (double i = 0; i < 5000; i++)
            {
                Console.Clear();
                Console.WriteLine("Процесс выхода" + i/ 5000 * 100 + "%");
            }
        }
        public int Sort()
        {
            Console.WriteLine("1 - По первому; 2 - по второму; 3 - по третьему; 4 - обратная:\n");
            string a = null;
            int result;
            while (!int.TryParse(a, out result)) a = Console.ReadLine();
            return result;
        }

    }
}