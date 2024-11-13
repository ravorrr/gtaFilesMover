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

        public static void MoveAllFilesToBackup()
        {
            int totalFiles = filesToMove.Length;
            int filesMoved = 0;

            foreach (var file in filesToMove)
            {
                string sourcePath = Path.Combine(gtaFolder, file);
                string targetPath = IsReshadeFile(file) ? Path.Combine(reshadeBackupFolder, file) : Path.Combine(backupFolder, file);

                MoveFile(sourcePath, targetPath);
                filesMoved++;
                OnFileMoved(filesMoved, totalFiles);
            }
        }

        public static void MoveAllFilesToGTA()
        {
            int totalFiles = filesToMove.Length;
            int filesMoved = 0;

            foreach (var file in filesToMove)
            {
                string sourcePath = IsReshadeFile(file) ? Path.Combine(reshadeBackupFolder, file) : Path.Combine(backupFolder, file);
                string targetPath = Path.Combine(gtaFolder, file);

                MoveFile(sourcePath, targetPath);
                filesMoved++;
                OnFileMoved(filesMoved, totalFiles);
            }
        }

        public static void MoveOnlyReshadeFilesToBackup()
        {
            int totalFiles = reshadeFiles.Length;
            int filesMoved = 0;

            foreach (var file in reshadeFiles)
            {
                string sourcePath = Path.Combine(gtaFolder, file);
                string targetPath = Path.Combine(reshadeBackupFolder, file);

                MoveFile(sourcePath, targetPath);
                filesMoved++;
                OnFileMoved(filesMoved, totalFiles);
            }
        }

        private static void MoveFile(string sourcePath, string destinationPath)
        {
            try
            {
                Thread.Sleep(200);

                if (File.Exists(sourcePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);
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
    }
}
