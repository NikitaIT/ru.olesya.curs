using System;
using System.Text;

namespace ru.olesya.curs.Models
{
    public struct Table
    {
        private readonly long code;
        private readonly string type;
        private readonly double price;
        public long Code { get { return code; }
            set { }
        }
//        public override int GetHashCode()
//        {
//            int result;
//            long temp;
//            temp = (code);
//            result = (int)(temp ^ 
//                (temp >> 32));
//            result = (int)(temp ^
//                (temp >> 32));
//            //            temp = (price);
//            //            result = 31 * result + (int)(temp ^ (temp >> 32));
//            return result;
//        }
        public override int GetHashCode()
        {
            //code<<5 сдвинет 0b1010101 на 5 влево,code>>5 вправо, ^ сделает XOR
            return ShiftAndWrap((code<<5).GetHashCode(), 2) ^ (code>>5).GetHashCode();
        }

        private int ShiftAndWrap(int value, int positions)
        {
            //удалит знак
            positions = positions & 0x1F;
 
            // Сохранить существующий битовый шаблон, но интерпретировать это как целое число без знака.
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            // Сохранить биты, которые будут отброшены.
            uint wrapped = number >> (32 - positions);
            // Сдвиг и обертывание отброшенных битов
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }
        public override string ToString()
        {
            return code + ";" + type + ";" + price;
        }

        public Table(long code, string type, double price)
        {
            this.code = code;
            this.type = type;
            this.price = price;
        }
    }
}