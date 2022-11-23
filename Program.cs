using Microsoft.Win32;
using System.Runtime.Versioning;

namespace RegDB
{
    internal class Program
    {
        [SupportedOSPlatform("Windows")]
        static void Main(string[] args)
        {
            try
            {
                var cmdArgs = CommandLineParameters.Parse(args);
                switch (cmdArgs.Operation)
                {
                    case "set":
                        Set(cmdArgs.Key, cmdArgs.Value);
                        Environment.Exit(0);
                        break;
                    case "get":
                        var val = Get(cmdArgs.Key);
                        Console.WriteLine(val);
                        Environment.Exit(0);
                        break;
                    case "unset":
                        UnSet(cmdArgs.Key);
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(1);
                        break;
                }
            }
            catch (Exception)
            {
                Environment.Exit(1);
            }
        }

        [SupportedOSPlatform("Windows")]
        private static string Get(string key)
        {
            using RegistryKey regKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\regdb");
            var value = regKey.GetValue(key).ToString();
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            else
            {
                Console.WriteLine($"Key '{key}' not found.");
                Environment.Exit(1);
                return null;
            }
        }

        [SupportedOSPlatform("Windows")]
        private static void Set(string key, string value)
        {
            using RegistryKey regKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\regdb");
            regKey.SetValue(key, value);
        }

        [SupportedOSPlatform("Windows")]
        private static void UnSet(string key)
        {
            using RegistryKey regKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\regdb");
            regKey.SetValue(key, string.Empty);
        }
    }
}