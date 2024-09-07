using System;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


while (true)
{
    string path = "";
    Console.WriteLine("Введите номер команды:\n1.Создать файл и записать данные\n2.Прочитать данные из файла\n3.Записать данные параллельно через потоки\n4.Удалить файл\n5.Выход");
    int result = int.Parse(Console.ReadLine());
    switch (result)
    {
        case 1:
            Console.Write("Введите название нового файла:");
            path = Console.ReadLine();
            Console.WriteLine("Начинается запись файла");
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        sw.WriteLine(DateTime.Now);
                        System.Threading.Thread.Sleep(100);
                    }
                    sw.Dispose();
                    sw.Close();
                }
            }
            catch (Exception у)
            {
                Console.WriteLine(у);
                throw;
            }
            Console.WriteLine("Запись закончена");
            break;
        case 2:
            Console.Write("Введите название файла:");
            path = Console.ReadLine();
            Console.WriteLine("Начинается чтение файла");
            try
            {
                using (StreamReader sw = new StreamReader(path, true))
                {
                    Console.WriteLine(sw.ReadToEnd());
                }
            }
            catch (Exception y)
            {
                Console.WriteLine(y);
                throw;
            }
            Console.WriteLine("Чтение файла закончено");
            break;

        case 3:
            Console.Write("Введите название файла:");
            path = Console.ReadLine();
            Console.WriteLine("Начинается запись файла");
            try
            {
                int score = 0;
                bool a = true;
                Num(path);
                await Num2(path);
                void Num(string path)
                {

                    if (a == true)
                    {
                        using (StreamWriter sw = new StreamWriter(path, true))
                        {
                            sw.WriteLine($"Поток 1 {DateTime.Now}");
                            sw.Close();
                            sw.Dispose();
                            a = false;
                        }
                    }
                }
                async Task Num2(string path)
                {
                    await Task.Run(() =>
                    {
                        while (true)
                        {
                            if (a == false)
                            {
                                using (StreamWriter sr = new StreamWriter(path, true))
                                {
                                    sr.WriteLine($"Поток 2 {DateTime.Now}");
                                    sr.Close();
                                    sr.Dispose();
                                    a = true;
                                }
                                score++;
                                if (score == 5)
                                {
                                    Environment.Exit(0);
                                }
                                Num(path);
                            }
                        }
                    });
                }
            }
            catch (Exception y)
            {
                Console.WriteLine(y);
                throw;
            }
            break;
        case 4:
            Console.Write("Введите название файла:");
            path = Console.ReadLine();
            Console.WriteLine("Удаление файла");
            File.Delete(path);
            break;
        case 5:
            Environment.Exit(0);
            break;
    }
}












