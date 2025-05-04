using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrilozhDlaRabotaSDiscami
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Диск Менеджер");
                Console.WriteLine("1. Посмотреть доступные диски");
                Console.WriteLine("2. Получить информацию о диске");
                Console.WriteLine("3. Посмотреть содержимое диска");
                Console.WriteLine("4. Создать новый каталог");
                Console.WriteLine("5. Создать новый файл");
                Console.WriteLine("6. Удалить файл или каталог");
                Console.WriteLine("Выход");
                Console.Write("Выберите опцию: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAvailableDrives();
                        break;
                    case "2":
                        GetDriveInfo();
                        break;
                    case "3":
                        ShowDriveContents();
                        break;
                    case "4":
                        CreateDirectory();
                        break;
                    case "5":
                        CreateFile();
                        break;
                    case "6":
                        DeleteFileOrDirectory();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }

                Console.WriteLine("Нажмите на любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
        static void ShowAvailableDrives()
        {
            Console.WriteLine("Доступные диски: ");
            foreach (var drive in DriveInfo.GetDrives())
            {
                if(drive.IsReady)
                {
                    Console.WriteLine($"{drive.Name} - {drive.DriveType}, Файловая система: {drive.DriveFormat}, Общий объем: {drive.TotalSize / (1024 * 1024 * 1024)} ГБ, Доступно: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ");
                }
            }
        }
        static void GetDriveInfo()
        {
            Console.Write("Введите букву диска (Например, C): ");
            string driveLetter = Console.ReadLine() + ":\"
            DriveInfo drive = new DriveInfo(driveLetter);
            if(drive.IsReady)
            {
                Console.WriteLine($"Диск: {drive.Name}");
                Console.WriteLine($"Объем: {drive.TotalSize / (1024 * 1024 * 1024)} ГБ");
                Console.WriteLine($"Доступное пространство: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ");
                Console.WriteLine($"Файловая система: {drive.DriveFormat}");
            }
            else
            {
                Console.WriteLine("Диск не готов или не существует.");
            }
        }

        static void ShowDriveContents()
        {
            Console.Write("Введите букву для просмотра содержимого (например, C): ");
            string driveLetter = Console.ReadLine() + ":\";
            if (Directory.Exists(driveLetter))
            {
                string[] diretories = Directory.GetDirectories(driveLetter);
                string[] files = Directory.GetFiles(driveLetter);

                Console.WriteLine($"Содержимое {driveLetter}:");
                foreach (var dir in diretories)
                {
                    Console.WriteLine($"[Директория] {Path.GetFileName(dir)}");
                }
                foreach (var file in files)
                {
                    Console.WriteLine($"[Файл] {Path.GetFileName(file)}");
                }
            }
            else
            {
                Console.WriteLine("Диск не существует.");
            }
        }
        static void CreateDirectory()
        {
            Console.Write("Введите путь для создания нового каталога (например, C:/NewFolder)");
            string path = Console.ReadLine();
            try
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Каталог успешно создан");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибки при создании каталога: {ex.Message}");
            }
        }
        static void CreateFile()
        {
            Console.Write("Введите путь для создания нового файла (например, C:/NewFile.txt)");
            string path = Console.ReadLine();
            try
            {
                File.WriteAllText(path, content);
                Console.WriteLine("Файл успешно создан");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибки при создании файла: {ex.Message}");
            }
        }
        static void DeleteFileOrDirectory()
        {
            Console.Write("Введите путь к файлу или каталогу для удаления: ");
            string path = Console.ReadLine();
           if (Directory.Exists(path))
            {
                Console.WriteLine("Вы уверены, что хотите удалить каталог? (yes/no): ");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    Directory.Delete(path, true);
                    Console.WriteLine("\nКаталог успешно удален");
                }
           }
           else if (File.Exists(path))
           {
                Console.Write("Вы уверены, что хотите удалить файл? (yes/no): ");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    File.Delete(path);
                    Console.WriteLine("\nФайл успешно удален");
                }
           }
           else
           {
                Console.WriteLine("\nФайл или каталог не существует");
           }
        }
    }
}
