using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ru.olesya.curs.Models
{
    public class TablesHashMap
    {
        /**
         * Для каждой строки в таблице, создай словарь пар ([ключ]=хешкод,[значение]=списокТаблиц)
         */
        public TablesHashMap(Parser parser)
        {
            Parser.Tables.ForEach(Add);
        }

        public void Add(Table table)
        {
            List<Table> tables = new List<Table>();
            var key = table.GetHashCode();
            //Console.WriteLine(" Code: " + table.Code + " Hash: " + key);
            // Если ключ встречалося, извлеки список содержимого
            if (dictionary.ContainsKey(key))
            {
                dictionary.TryGetValue(key, out tables);
                dictionary.Remove(key);
            }
            tables.Add(table);
            dictionary.Add(key, tables);
        }
        /*
         * Удаление: Ищем по ключу, достаем список значений, удаляем из списка совпадающее с переданным
         */
        public bool Delete(Table table)
        {
            List<Table> tables = new List<Table>();
            var key = table.GetHashCode();
            if (dictionary.ContainsKey(key))
            {
                dictionary.TryGetValue(key, out tables);
                tables.Remove(table);
                dictionary.Remove(key);
                if (tables.Count!=0) dictionary.Add(key, tables);
                return true;
            }
                return false;
            
        }
        // Поиск
        public List<Table> Find(Table table)
        {
            long key = table.GetHashCode();
            List<Table> tables;
            if (!dictionary.TryGetValue(key, out tables))
            {
                Console.WriteLine("Значение не найдено");
                return null;
            }
            return tables;
        }
        // Словарь(Карта) хешей и списков табличных строк
        private Dictionary<long, List<Table>> dictionary = new Dictionary<long, List<Table>>();
    }
}