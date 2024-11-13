using System;
using System.IO;
using System.Threading;

namespace gtaFilesMoverLib
{
    public static class FileMover
    {
        public static string gtaFolder { get; set; } = @"G:\Rockstar Games\Games\Grand Theft Auto V";
        public static string backupFolder { get; set; } = @"G:\Other\Gta_backup";
        private static readonly string reshadeBackupFolder = Path.Combine(backupFolder, "reshade");

        public static readonly string[] filesToMove = {
            "mods", "openCameraV.asi", "openCameraV.log", "OpenIV.asi", "OpenIV.log",
            "asiloader.log", "dinput8.dll", "reshade-shaders", "grand.ini", "new.ini",
            "ReShade.ini", "ReShadePreset.ini"
        };

        public static readonly string[] reshadeFiles = {
            "reshade-shaders", "grand.ini", "new.ini", "ReShade.ini", "ReShadePreset.ini"
        };

        public delegate void FileMovedHandler(int filesMoved, int totalFiles);
        public static event FileMovedHandler? FileMoved;

        public static void MoveFiles(string[] files, string sourceFolder, string targetFolder, bool isReshade = false)
        {
            int totalFiles = files.Length;
            int filesMoved = 0;

            foreach (var file in files)
            {
                string sourcePath = Path.Combine(sourceFolder, file);
                string destinationPath = isReshade && IsReshadeFile(file)
                    ? Path.Combine(reshadeBackupFolder, file)
                    : Path.Combine(targetFolder, file);

                MoveFile(sourcePath, destinationPath);
                filesMoved++;
                OnFileMoved(filesMoved, totalFiles);
            }
        }

        private static void MoveFile(string sourcePath, string destinationPath)
        {
            try
            {
                Thread.Sleep(200);

                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);
                if (File.Exists(sourcePath))
                {
                    File.Move(sourcePath, destinationPath, true);
                    Console.WriteLine($"Przeniesiono plik {Path.GetFileName(sourcePath)}.");
                }
                else if (Directory.Exists(sourcePath))
                {
                    Directory.Move(sourcePath, destinationPath);
                    Console.WriteLine($"Przeniesiono folder {Path.GetFileName(sourcePath)}.");
                }
                else
                {
                    Console.WriteLine($"Plik lub folder {Path.GetFileName(sourcePath)} nie istnieje w {sourcePath}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przenoszenia pliku/folderu: {ex.Message}");
            }
        }

        private static void OnFileMoved(int filesMoved, int totalFiles)
        {
            FileMoved?.Invoke(filesMoved, totalFiles);
        }

        private static bool IsReshadeFile(string file)
        {
            return Array.Exists(reshadeFiles, reshadeFile => reshadeFile == file);
        }

        public static void MoveAllFilesToBackup() => MoveFiles(filesToMove, gtaFolder, backupFolder);
        public static void MoveAllFilesToGTA() => MoveFiles(filesToMove, backupFolder, gtaFolder);
        public static void MoveOnlyReshadeFilesToBackup() => MoveFiles(reshadeFiles, gtaFolder, reshadeBackupFolder, true);
    }
}
