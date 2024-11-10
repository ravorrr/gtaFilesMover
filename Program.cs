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
            "mods", "openCameraV.asi", "openCameraV.log", "OpenIV.asi", "OpenIV.log",
            "asiloader.log", "dinput8.dll", "reshade-shaders", "grand.ini", "new.ini",
            "ReShade.ini", "ReShadePreset.ini"
        };

        private static readonly string[] reshadeFiles = {
            "reshade-shaders", "grand.ini", "new.ini", "ReShade.ini", "ReShadePreset.ini"
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
                    case "1": MoveFiles(gtaFolder, backupFolder, filesToMove); break;
                    case "2": MoveFilesFromBackupToGTA(); break;
                    case "3": MoveFiles(gtaFolder, reshadeBackupFolder, reshadeFiles); break;
                    case "4": Console.WriteLine("Narzędzie odświeżone."); break;
                    case "5": Console.WriteLine("Do zobaczenia!"); return;
                    default: Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie."); break;
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

            Console.WriteLine("=============================================================\n");
        }

        static string GetFileLocation(string file)
        {
            if (ExistsInPath(gtaFolder, file)) return "GTA V";
            if (ExistsInPath(backupFolder, file)) return "backup";
            if (ExistsInPath(reshadeBackupFolder, file)) return "backup/reshade";
            return "Nie znaleziono";
        }

        static bool ExistsInPath(string path, string file) =>
            File.Exists(Path.Combine(path, file)) || Directory.Exists(Path.Combine(path, file));

        static void MoveFiles(string sourceFolder, string targetFolder, string[] files)
        {
            Console.WriteLine($"Przenoszenie plików z {sourceFolder} do {targetFolder}...");

            foreach (string file in files)
            {
                string sourcePath = Path.Combine(sourceFolder, file);
                MoveFile(sourcePath, targetFolder, file);
            }
        }

        static void MoveFilesFromBackupToGTA()
        {
            Console.WriteLine("Przenoszenie wszystkich plików z backup folder do GTA V...");

            foreach (string file in filesToMove)
            {
                string sourcePath = Array.Exists(reshadeFiles, reshadeFile => reshadeFile == file)
                    ? Path.Combine(reshadeBackupFolder, file)
                    : Path.Combine(backupFolder, file);

                MoveFile(sourcePath, gtaFolder, file);
            }
        }

        static void MoveFile(string sourcePath, string destinationFolder, string file)
        {
            string destinationPath = Path.Combine(destinationFolder, file);

            try
            {
                if (File.Exists(sourcePath))
                {
                    Console.WriteLine($"Przenoszę plik {file} do {destinationPath}...");
                    File.Move(sourcePath, destinationPath);
                }
                else if (Directory.Exists(sourcePath))
                {
                    Console.WriteLine($"Przenoszę folder {file} do {destinationPath}...");
                    Directory.Move(sourcePath, destinationPath);
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
    }
}
