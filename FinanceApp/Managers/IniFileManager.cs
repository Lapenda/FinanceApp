using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Manager
{
    internal class IniFileManager
    {
        private readonly string _path;
        private static readonly object fileLock = new object();

        public IniFileManager(string fileName) 
        {
            _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Config/" + fileName);
            if (!File.Exists(_path))
            {
                File.Create(_path);
            }
        }

        public void Write(string section, string key, string value)
        {
            lock (fileLock)
            {
                try
                {
                    var lines = File.Exists(_path) ? File.ReadAllLines(_path).ToList() : new List<string>();
                    var sectionHeader = $"[{section}]";
                    var keyValue = $"{key}={value}";
                    bool sectionFound = false;
                    bool keyFound = false;

                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (lines[i].Trim() == sectionHeader)
                        {
                            sectionFound = true;
                            for (int j = i + 1; j < lines.Count(); j++)
                            {
                                if (lines[j].StartsWith(key + "="))
                                {
                                    lines[j] = keyValue;
                                    keyFound = true;
                                    break;
                                }
                            }

                            if (!keyFound)
                            {
                                lines.Insert(i + 1, keyValue);
                            }
                            break;
                        }
                    }

                    if (!sectionFound)
                    {
                        lines.Add(sectionHeader);
                        lines.Add(keyValue);
                    }

                    File.WriteAllLines(_path, lines);
                    Console.WriteLine($"Success writing {key}={value} to ini: " + _path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to INI file: {ex.Message}");
                }
            }
        }

        public string Read(string section, string key, string defaultValue = null)
        {
            lock (fileLock)
            {
                try
                {
                    if (!File.Exists(_path))
                    {
                        return defaultValue;
                    }

                    var lines = File.ReadAllLines(_path);
                    var sectionHeader = $"[{section}]";
                    bool sectionFound = false;

                    foreach (var line in lines)
                    {
                        if (line.Trim() == sectionHeader)
                        {
                            sectionFound = true;
                            continue;
                        }

                        if (sectionFound && line.StartsWith(key + "="))
                        {
                            Console.WriteLine($"Success reading {key} from ini:" + _path);

                            return line.Substring(key.Length + 1).Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from INI file: {ex.Message}");
                }

                return defaultValue;
            }
        }
    }
}
