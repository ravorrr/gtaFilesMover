using System;
using System.IO;

namespace gtaFilesMoverLib
{
    public class FileMover
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

        public static void MoveFilesFromBackupToGTA()
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

        private static void MoveFile(string sourcePath, string destinationFolder, string file)
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
