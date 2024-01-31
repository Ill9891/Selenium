using Serilog;
using System;
using System.IO;

namespace Core
{
    public class BaseLogger
    {
        private string _directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private string _fileName;
        private string _filePath;

        public void Initialize()
        {
            CreateLogDirectory();
            CreateFile();
            StartUpLogging();
        }

        private void StartUpLogging()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(_filePath).CreateLogger();
        }

        private void CreateLogDirectory()
        {
            Directory.CreateDirectory(_directoryPath);
        }

        private void CreateFile()
        {
            var random = new Random().Next(0, 99);
            _fileName = $"Test_{random}-{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.txt";
            _filePath = Path.Combine(_directoryPath, _fileName);
            File.Create(_filePath).Close();
        }

        public void Info(string message)
        {
            Log.Information(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }
    }
}
