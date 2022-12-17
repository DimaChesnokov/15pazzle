using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTagsGame
{
    /// <summary>
    /// Класс пятнашек. 
    /// </summary>
    class Game
    {
        /// <summary>
        /// Размер полей
        /// </summary>
        int size; 

        /// <summary>
        /// Поле игры.
        /// </summary>
        int[,] field;

        /// <summary>
        /// пустоле поле по X
        /// </summary>
        int blank_x;

        /// <summary>
        /// Пустое поле по Y
        /// </summary>
        int blank_y; 

        static Random rand = new Random();

        /// <summary>
        /// Размер поля.
        /// </summary>
        public Game(int size)
        {
            if (size < 3)
                size = 2;
            if (size > 6)
                size = 6;
            this.size = size;  // ссылаемся на size
            field = new int[size,size];
        }


        /// <summary>
        /// Заполнение матрицы
        /// </summary>
        public void Filling() 
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    field[x, y] = CoordinatesPosition(x, y) + 1; // +1 обязательно, т.к. позиции кнопок идут с нуля
            blank_x = size - 1;
            blank_y = size - 1;
            field[blank_x, blank_y] = 0; //Если кнопка 16, то присваеваем 0, нуль это пробел
        }
        /// <summary>
        /// Передача номера позиции кнопки
        /// </summary>
        /// <param name="position">Позиция</param>
        /// <returns>Значение массива в позиции(Значение кнопки)</returns>
        public int get_number_position (int position) //Передаём сюда номер позиции, а возвращаем  что на этой кнопке должно быть написано
        {
            int x, y;            
            CordinatesPositionReverse(position, out x, out y); // Передаём номер кнопки 
            //Проверка на переполнение
            if (x < 0 || x >= size) 
                return 0; 
            if (y < 0 || y >= size) 
                return 0;
            return field[x, y];
        }

        /// <summary>
        /// Функция для перемещения кнопок по координатам
        /// </summary>
        /// <param name="position">Позиция</param>
        public void change(int position)
        {
            int x, y;
            CordinatesPositionReverse(position,out x,out y);
            //пустое поле должно перемещаться на место кнопки, которая находится около пустого поля.
            if (Math.Abs(blank_x - x) + Math.Abs(blank_y - y) != 1)
            {
                return;
            }
            field[blank_x, blank_y] = field[x, y]; // в пустое поле записываем значение кнопки,которое мы нажали
            field[x, y] = 0; //Меняем кнопку на пустое поле.
            //новые координаты пустого поля
            blank_x = x;
            blank_y = y;
        }




        /// <summary>
        /// Случайное число
        /// </summary>
        public int mix;
        
        /// <summary>
        /// Перемешка кнопок
        /// </summary>
        public void Mixing()
        {
            
            mix = rand.Next(0, 4);


            int i = blank_x;
            int j = blank_y;
            switch(mix)
            {
                //перемещине кнопки
                case 0: //  влево
                    i--;
                    break;
                case 1: //вправо
                    i++; 
                    break;
                case 2: // вверх
                    j--;
                    break;
                case 3: // вниз
                    j++;
                    break;
            }

            change(CoordinatesPosition(i,j));
        }

        /// <summary>
        /// Перевод координат в позицию (из массива в номера кнопок в форме) 
        /// </summary>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        /// <returns>Позиция кнопки в форме</returns>
        private int CoordinatesPosition(int x,int y)
        {
            //Условия, чтобы убрать ошибки выхода за гарницы массива
            if (x < 0)
                x = 0;
            if (x > size - 1)
                x = size - 1;
            if (y < 0)
                y = 0;
            if (y > size - 1)
                y = size - 1;
            int pos;
            pos = y * size + x;
            return pos;
        }

        /// <summary>
        /// Перевод позиции в координаты
        /// </summary>
        /// <param name="position">Поизиция</param>
        /// <param name="x">Координата x</param>
        /// <param name="y">Координата y</param>
        private void CordinatesPositionReverse(int position, out int x, out int y)
        {
            if (position < 0)
                position = 0;
            if (position > size * size - 1) 
                position = size * size - 1;

            x = position % size;
            y = position / size;
        }




        /// <summary>
        /// Условие для победы
        /// </summary>
        /// <returns>Истина/Ложь</returns>
        public bool ConditionWin()
        {
            //Если пустое поле не находится на последнем месте поля, то победы не будет
            if (!(blank_x == size - 1 && blank_y == size - 1)) 
                return false;

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1)) //если не последнее поле
                        if (field[x, y] != CoordinatesPosition(x, y) + 1)
                            return false;
            return true;
        }

        /// <summary>
        /// Перевод времени в миллисекунды
        /// </summary>
        /// <param name="time">Время</param>
        /// <returns>Время в миллисекундах</returns>
        public static int Score(string time)
        {
            //Деление на три элемента
            string[] components = time.Split(':'); 
            //Минуты умножаем на 60000, секунды на 1000, миллисекунды на 100
            return int.Parse(components[0])*60000+ int.Parse(components[1])*1000 + int.Parse(components[2])*100;
        }




    }
}
