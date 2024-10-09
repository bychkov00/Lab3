using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;

namespace Lab3
{
    internal class Program
    {
        static void Help()
        {
            Console.WriteLine("Для добавления новой записи введите 'a' и новую запись через пробел");
            Console.WriteLine("Для удаления записи введите 'd' и номер записи через пробел");
            Console.WriteLine("Для отображения всех записей введите 'l'");
            Console.WriteLine("Для отображения подсказки введите 'h'");
            Console.WriteLine("Для завершения работы введите 'q'");
            Console.WriteLine("Для трехкнопочного интерфейса введите 'x'");
            Console.WriteLine(new string('_', Console.WindowWidth));
        }

        static void Help2()
        {
            Console.WriteLine("Для добавления новой записи введите 'a' и новую запись через пробел");
            Console.WriteLine("Для удаления записи введите 'd' и номер записи через пробел");
            Console.WriteLine("Для завершения работы введите 'q'");
            Console.WriteLine("Для переключения в обычный интерфейс введите 'x'");
            Console.WriteLine(new string('_', Console.WindowWidth));
        }

        static void AddNote(string comand, List<string> notes)
        {
            var str = comand.Substring(1).Trim();
            if (str.Length > 0 && str != null)
            {
                notes.Add(str);
                Console.WriteLine("Запись добавлена");
            }
            else
                Console.WriteLine("Строка не распознана");
        }

        static void DeleteNote(string comand, List<string> notes)
        {
            var str = comand.Substring(1).Trim();
            var number = 0;
            try
            {
                number = int.Parse(str);
            }
            catch
            {
                Console.WriteLine("Номер записи не распознан");
                return;
            }
            if (number <= notes.Count && number >= 1)
            {
                notes.RemoveAt(number - 1);
                Console.WriteLine("Запись удалена");
            }
            else
                Console.WriteLine("Номер записи не найден");
        }

        static void ShowNotes(List<string> notes)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine(i + 1 + " " + notes[i]);
            }
        }
        static void Main()
        {
            List<string> notes = new List<string>() { "Пойти на работу", "Пойти на пару" };
            bool quit = false;
            bool xinterface = false;
            Help();

            while (!quit)
            {
                Console.WriteLine("");
                Console.WriteLine("Введите команду:");
                Console.WriteLine("");
                var comand = Console.ReadLine();
                if (comand.Length == 0 || comand == null)
                    continue;
                switch (comand[0])
                {
                    case 'a':
                        AddNote(comand, notes);
                        break;
                    case 'd':
                        DeleteNote(comand, notes);
                        break;
                    case 'h':
                        {
                            if (!xinterface)
                                Help();
                            break;
                        }
                    case 'l':
                        {
                            if (!xinterface)
                                ShowNotes(notes);
                            break;
                        }
                    case 'x':
                        {
                            if (xinterface)
                            {
                                xinterface = false;
                                Console.Clear();
                                Help();
                            }
                            else
                                xinterface = true;
                            break;
                        }
                    case 'q':
                        {
                            quit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Команда не распознана");
                            break;
                        }
                }
                if (xinterface)
                {
                    Console.Clear();
                    Help2();
                    Console.WriteLine();
                    ShowNotes(notes);
                }
            }
        }
    }
}
