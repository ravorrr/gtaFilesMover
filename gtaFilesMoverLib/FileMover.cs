using System;
using System.IO;

namespace gtaFilesMoverLib
{
    public static class FileMover
    {
        public static string gtaFolder { get; set; } = @"G:\Rockstar Games\Games\Grand Theft Auto V";
        public static string backupFolder { get; set; } = @"G:\Other\Gta_backup";
        private static readonly string reshadeBackupFolder = Path.Combine(backupFolder, "reshade");
        public static readonly string backupRootFolder = @"G:\Other\Gta_backup\PreviousBackup";

        public static readonly string[] filesToMove = {
            "mods", "openCameraV.asi", "openCameraV.log", "OpenIV.asi", "OpenIV.log",
            "asiloader.log", "dinput8.dll", "reshade-shaders", "grand.ini", "new.ini",
            "ReShade.ini", "ReShadePreset.ini"
        };

        private static readonly string[] reshadeFiles = {
            "reshade-shaders", "grand.ini", "new.ini", "ReShade.ini", "ReShadePreset.ini"
        };

        public static void CreateBackup()
        {
            Console.WriteLine("Tworzenie kopii zapasowej przed przeniesieniem...");

            string backupFolder = Path.Combine(backupRootFolder, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            Directory.CreateDirectory(backupFolder);

            foreach (var file in filesToMove)
            {
                string sourcePath = Path.Combine(gtaFolder, file);
                string destinationPath = Path.Combine(backupFolder, file);

                CopyFileOrDirectory(sourcePath, destinationPath);
            }

            Console.WriteLine("Kopia zapasowa utworzona.");
        }

        private static void CopyFileOrDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                if (File.Exists(sourcePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath) ?? string.Empty);
                    File.Copy(sourcePath, destinationPath, true);
                    Console.WriteLine($"Skopiowano plik {Path.GetFileName(sourcePath)} do kopii zapasowej.");
                }
                else if (Directory.Exists(sourcePath))
                {
                    CopyDirectory(sourcePath, destinationPath);
                    Console.WriteLine($"Skopiowano folder {Path.GetFileName(sourcePath)} do kopii zapasowej.");
                }
                else
                {
                    Console.WriteLine($"Plik lub folder {Path.GetFileName(sourcePath)} nie istnieje w {sourcePath}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas tworzenia kopii zapasowej: {ex.Message}");
            }
        }

        private static void CopyDirectory(string sourceDir, string destinationDir)
        {
            Directory.CreateDirectory(destinationDir);

            foreach (var filePath in Directory.GetFiles(sourceDir))
            {
                string destFilePath = Path.Combine(destinationDir, Path.GetFileName(filePath));
                File.Copy(filePath, destFilePath, true);
            }

            foreach (var dirPath in Directory.GetDirectories(sourceDir))
            {
                string destDirPath = Path.Combine(destinationDir, Path.GetFileName(dirPath));
                CopyDirectory(dirPath, destDirPath);
            }
        }

        public static void RestoreFileOrDirectory(string sourcePath, string destinationPath)
        {
            CopyFileOrDirectory(sourcePath, destinationPath);
        }

        public static void MoveAllFilesToBackup()
        {
            Console.WriteLine("Przenoszenie wszystkich plików z GTA V do backup folder...");
            foreach (var file in filesToMove)
            {
                string sourcePath = Path.Combine(gtaFolder, file);
                string targetPath = IsReshadeFile(file) ? Path.Combine(reshadeBackupFolder, file) : Path.Combine(backupFolder, file);

                MoveFile(sourcePath, targetPath);
            }
        }

        public static void MoveAllFilesToGTA()
        {
            Console.WriteLine("Przenoszenie wszystkich plików z backup folder do GTA V...");
            foreach (var file in filesToMove)
            {
                string sourcePath = IsReshadeFile(file) ? Path.Combine(reshadeBackupFolder, file) : Path.Combine(backupFolder, file);
                string targetPath = Path.Combine(gtaFolder, file);

                MoveFile(sourcePath, targetPath);
            }
        }

        public static void MoveOnlyReshadeFilesToBackup()
        {
            Console.WriteLine("Przenoszenie tylko plików reshade z GTA V do backup/reshade...");
            foreach (var file in reshadeFiles)
            {
                string sourcePath = Path.Combine(gtaFolder, file);
                string targetPath = Path.Combine(reshadeBackupFolder, file);

                MoveFile(sourcePath, targetPath);
            }
        }

        private static void MoveFile(string sourcePath, string destinationPath)
        {
            try
            {
                if (File.Exists(sourcePath))
                {
                    File.Move(sourcePath, destinationPath);
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

        private static bool IsReshadeFile(string file)
        {
            return Array.Exists(reshadeFiles, reshadeFile => reshadeFile == file);
        }
    }
}
