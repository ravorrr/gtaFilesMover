using System;
using System.IO;

namespace gtaFilesMoverConsoleVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj! [Patryk Mars] - All rights reserved!");

            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayFileLocations();

                Console.WriteLine("Wybierz jedną z opcji:");
                Console.WriteLine("1 - Przenieś pliki z GTA V do backup folder");
                Console.WriteLine("2 - Przenieś pliki z backup folder do GTA V");
                Console.WriteLine("3 - Przenieś pliki reshade do backup folder");
                Console.WriteLine("4 - Odśwież narzędzie");
                Console.WriteLine("5 - Wyjście");
                Console.Write("Wybrana opcja: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        MoveFilesToBackup();
                        break;
                    case "2":
                        MoveFilesToGTA();
                        break;
                    case "3":
                        MoveReshadeFiles();
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

            string gtaFolder = @"G:\Rockstar Games\Games\Grand Theft Auto V";
            string backupFolder = @"G:\Other\Gta_backup";
            string reshadeBackupFolder = @"G:\Other\Gta_backup\reshade";

            string[] filesToCheck = {
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

            foreach (string file in filesToCheck)
            {
                string gtaPath = Path.Combine(gtaFolder, file);
                string backupPath = Path.Combine(backupFolder, file);
                string reshadePath = Path.Combine(reshadeBackupFolder, file);

                string location;

                if (File.Exists(gtaPath) || Directory.Exists(gtaPath))
                {
                    location = "GTA V";
                }
                else if (File.Exists(backupPath) || Directory.Exists(backupPath))
                {
                    location = "backup";
                }
                else if (File.Exists(reshadePath) || Directory.Exists(reshadePath))
                {
                    location = "backup/reshade";
                }
                else
                {
                    location = "Nie znaleziono";
                }

                Console.WriteLine("{0,-12} {1,-20} {2,-15}", "Plik/Folder", file, location);
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine();
        }

        static void MoveFilesToBackup()
        {
            Console.WriteLine("Przenoszenie plików z GTA V do backup folder...");

            string gtaFolder = @"G:\Rockstar Games\Games\Grand Theft Auto V";
            string backupFolder = @"G:\Other\Gta_backup";
            string reshadeBackupFolder = @"G:\Other\Gta_backup\reshade";

            string[] filesToMove = {
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

            foreach (string file in filesToMove)
            {
                string sourcePath = Path.Combine(gtaFolder, file);
                string destinationPath;

                if (file.StartsWith("reshade") || file.EndsWith(".ini"))
                {
                    destinationPath = Path.Combine(reshadeBackupFolder, file);
                }
                else
                {
                    destinationPath = Path.Combine(backupFolder, file);
                }

                try
                {
                    if (File.Exists(sourcePath))
                    {
                        File.Move(sourcePath, destinationPath);
                        Console.WriteLine($"Przeniesiono plik {file} do {destinationPath}.");
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        Directory.Move(sourcePath, destinationPath);
                        Console.WriteLine($"Przeniesiono folder {file} do {destinationPath}.");
                    }
                    else
                    {
                        Console.WriteLine($"Plik lub folder {file} nie istnieje w {gtaFolder}.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd przy przenoszeniu {file}: {ex.Message}");
                }
            }
        }

        static void MoveFilesToGTA()
        {
            string gtaFolder = @"G:\Rockstar Games\Games\Grand Theft Auto V";
            string backupFolder = @"G:\Other\Gta_backup";
            string reshadeBackupFolder = @"G:\Other\Gta_backup\reshade";

            string[] filesToMove = {
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

            foreach (string file in filesToMove)
            {
                string destinationPath = Path.Combine(gtaFolder, file);
                string sourcePath;

                if (file.StartsWith("reshade") || file.EndsWith(".ini"))
                {
                    sourcePath = Path.Combine(reshadeBackupFolder, file);
                }
                else
                {
                    sourcePath = Path.Combine(backupFolder, file);
                }

                try
                {
                    if (File.Exists(sourcePath))
                    {
                        File.Move(sourcePath, destinationPath);
                        Console.WriteLine($"Przeniesiono plik {file} do {destinationPath}.");
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        Directory.Move(sourcePath, destinationPath);
                        Console.WriteLine($"Przeniesiono folder {file} do {destinationPath}.");
                    }
                    else
                    {
                        Console.WriteLine($"Plik lub folder {file} nie istnieje w backup.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd przy przenoszeniu {file}: {ex.Message}");
                }
            }
        }

        static void MoveReshadeFiles()
        {
            string gtaFolder = @"G:\Rockstar Games\Games\Grand Theft Auto V";
            string reshadeBackupFolder = @"G:\Other\Gta_backup\reshade";

            string[] reshadeFiles = {
                "reshade-shaders",
                "grand.ini",
                "new.ini",
                "ReShade.ini",
                "ReShadePreset.ini"
            };

            MoveFiles(gtaFolder, reshadeBackupFolder, reshadeFiles);
        }

        static void MoveFiles(string sourceFolder, string destinationFolder, string[] files)
        {
            foreach (string file in files)
            {
                string sourcePath = Path.Combine(sourceFolder, file);
                string destinationPath = Path.Combine(destinationFolder, file);

                try
                {
                    if (File.Exists(sourcePath))
                    {
                        File.Move(sourcePath, destinationPath);
                        Console.WriteLine($"Przeniesiono plik {file} do {destinationPath}.");
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        Directory.Move(sourcePath, destinationPath);
                        Console.WriteLine($"Przeniesiono folder {file} do {destinationPath}.");
                    }
                    else
                    {
                        Console.WriteLine($"Plik lub folder {file} nie istnieje w {sourceFolder}.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd przy przenoszeniu {file}: {ex.Message}");
                }
            }
        }
    }
}
