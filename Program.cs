using System;
using System.IO;

namespace gtaFilesMoverConsoleVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj! Zaloguj się [Patryk Mars] - All rights reserved!");

            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
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

        static void MoveFilesToBackup()
        {
            Console.WriteLine("Przenoszenie plików z GTA V do backup folder...");

            string gtaFolder = @"G:\Rockstar Games\Games\Grand Theft Auto V";
            string backupFolder = @"G:\Other\Gta_backup";

            string[] filesToMove =
            {
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

            MoveFiles(gtaFolder, backupFolder, filesToMove);
        }

        static void MoveFilesToGTA()
        {
            string gtaFolder = @"G:\Rockstar Games\Games\Grand Theft Auto V";
            string backupFolder = @"G:\Other\Gta_backup";

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

            MoveFiles(backupFolder, gtaFolder, filesToMove);
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
                        Console.WriteLine($"Przeniesiono plik {file} do {destinationFolder}.");
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        Directory.Move(sourcePath, destinationPath);
                        Console.WriteLine($"Przeniesiono folder {file} do {destinationFolder}.");
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
