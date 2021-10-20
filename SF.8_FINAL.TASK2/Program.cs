﻿using System;
using System.IO;

namespace SF._8_FINAL.TASK2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полное имя папки, размер которой требуется посчитать: ");
            string path = Console.ReadLine();
            if (!path.Contains(@":\"))
            {
                Console.WriteLine("Указан некорректный путь к папке: " + path);
            }
            else
            {
                var di = new DirectoryInfo(path);
                try
                {
                    if (di.Exists)
                    {
                        //Запуск рекурсивного метода подсчета объема папки с файлами
                        Console.WriteLine("Общий объем папки {0} со всеми вложенными файлами и каталогами составляет {1} байт", path, DirSize(di));
                    }
                    else
                    {
                        Console.WriteLine("Каталога {0} не существует", path);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
            Console.ReadKey();

        }

        /// <summary>
        /// Рекурсивный метод подсчета объема папки с файлами
        /// </summary>
        /// <param name="d"></param>
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fil = d.GetFiles();

            foreach (FileInfo file in fil)
            {
                size += file.Length;
                Console.WriteLine("Файл: {0}, объем {1} байт", file.Name, file.Length);
            }

            DirectoryInfo[] direct = d.GetDirectories();

            foreach (DirectoryInfo dir in direct)
            {
                Console.WriteLine("Каталог: {0}", dir.FullName);
                size += DirSize(dir);
                
            }
            
            return size;
        }

    }
}
