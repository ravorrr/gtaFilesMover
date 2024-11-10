using System;
using System.IO;

namespace gtaFilesMoverConsoleVersion
{
    internal class Program
    {
        private static readonly string gtaFolder = @"G:\Rockstar Games\Games\Grand Theft Auto V";
        private static readonly string backupFolder = @"G:\Other\Gta_backup";
        private static readonly string reshadeBackupFolder = Path.Combine(backupFolder, "reshade");

        private static readonly string[] filesToMove = {
            "mods",
            "openCameraV.asi",
            "openCameraV.log",
            "OpenIV.asi",
            "OpenIV.log",
            "asiloader.log",
            "dinput8.dll",
            "reshade-shaders",
            "grand.ini",
            "new.ini",
            "ReShade.ini",
            "ReShadePreset.ini"
        };

        private static readonly string[] reshadeFiles = {
            "reshade-shaders",
            "grand.ini",
            "new.ini",
            "ReShade.ini",
            "ReShadePreset.ini"
        };

        static void Main(string[] args)
        {
            Console.Title = "Narzędzie do szybkiego przenoszenia plików GTA V";
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayFileLocations();

                Console.WriteLine("Wybierz jedną z opcji:");
                Console.WriteLine("1 - Przenieś wszystkie pliki z GTA V do backup folder");
                Console.WriteLine("2 - Przenieś wszystkie pliki z backup folder do GTA V");
                Console.WriteLine("3 - Przenieś tylko pliki reshade do backup/reshade");
                Console.WriteLine("4 - Odśwież narzędzie");
                Console.WriteLine("5 - Wyjście");
                Console.Write("Wybrana opcja: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        MoveAllFilesToBackup();
                        break;
                    case "2":
                        MoveAllFilesToGTA();
                        break;
                    case "3":
                        MoveOnlyReshadeFilesToBackup();
                        break;
                    case "4":
                        Console.WriteLine("Narzędzie odświeżone.");
                        break;
                    case "5":
                        Console.WriteLine("Do zobaczenia!");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }

                Console.WriteLine("Naciśnij ENTER, aby wrócić do menu.");
                Console.ReadLine();
            }
        }

        static void DisplayFileLocations()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("{0,-12} {1,-20} {2,-15}", "Typ:", "Nazwa:", "Lokalizacja:");
            Console.WriteLine("=============================================================");

            foreach (string file in filesToMove)
            {
                string location = GetFileLocation(file);
                Console.WriteLine("{0,-12} {1,-20} {2,-15}", "Plik/Folder", file, location);
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine();
        }

        static string GetFileLocation(string file)
        {
            string gtaPath = Path.Combine(gtaFolder, file);
            string backupPath = Path.Combine(backupFolder, file);
            string reshadePath = Path.Combine(reshadeBackupFolder, file);

            if (File.Exists(gtaPath) || Directory.Exists(gtaPath))
                return "GTA V";
            else if (File.Exists(backupPath) || Directory.Exists(backupPath))
                return "backup";
            else if (File.Exists(reshadePath) || Directory.Exists(reshadePath))
                return "backup/reshade";
            else
                return "Nie znaleziono";
        }

        static void MoveAllFilesToBackup()
        {
            Console.WriteLine("Przenoszenie wszystkich plików z GTA V do backup folder...");

            foreach (string file in filesToMove)
            {
                string sourcePath = Path.Combine(gtaFolder, file);
                string targetFolder = IsReshadeFile(file) ? reshadeBackupFolder : backupFolder;

                MoveFile(sourcePath, targetFolder, file);
            }
        }

        static void MoveAllFilesToGTA()
        {
            Console.WriteLine("Przenoszenie wszystkich plików z backup folder do GTA V...");

            foreach (string file in filesToMove)
            {
                string sourcePath = IsReshadeFile(file) ? Path.Combine(reshadeBackupFolder, file) : Path.Combine(backupFolder, file);
                MoveFile(sourcePath, gtaFolder, file);
            }
        }

        static void MoveOnlyReshadeFilesToBackup()
        {
            Console.WriteLine("Przenoszenie tylko plików reshade z GTA V do backup/reshade...");

            foreach (string file in reshadeFiles)
            {
                string sourcePath = Path.Combine(gtaFolder, file);
                MoveFile(sourcePath, reshadeBackupFolder, file);
            }
        }

        static void MoveFile(string sourcePath, string destinationFolder, string file)
        {
            string destinationPath = Path.Combine(destinationFolder, file);

            try
            {
                if (File.Exists(sourcePath))
                {
                    Console.WriteLine($"Przenoszę plik {file} z {sourcePath} do {destinationPath}...");
                    File.Move(sourcePath, destinationPath);
                    Console.WriteLine($"Przeniesiono plik {file} do {destinationPath}.");
                }
                else if (Directory.Exists(sourcePath))
                {
                    Console.WriteLine($"Przenoszę folder {file} z {sourcePath} do {destinationPath}...");
                    Directory.Move(sourcePath, destinationPath);
                    Console.WriteLine($"Przeniesiono folder {file} do {destinationPath}.");
                }
                else
                {
                    Console.WriteLine($"Plik lub folder {file} nie istnieje w {sourcePath}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd przy przenoszeniu {file}: {ex.Message}");
            }
        }

        static bool IsReshadeFile(string file)
        {
            return Array.Exists(reshadeFiles, reshadeFile => reshadeFile == file);
        }
    }
}
