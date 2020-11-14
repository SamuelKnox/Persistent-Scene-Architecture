using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace SecondDinner.Data
{
    /// <summary>
    /// Manager which is used to save and load data
    /// </summary>
    public static class DataManager
    {
        private const string Folder = "Data";
        private const string FileSuffix = ".dat";

        /// <summary>
        /// Initializes the data manager
        /// </summary>
        static DataManager()
        {
            CreateDirectory();
        }

        /// <summary>
        /// Loads data from a key
        /// </summary>
        /// <typeparam name="TData">The type of data to be loaded</typeparam>
        /// <param name="key">The key that the data is saved under</param>
        /// <returns>The data that was loaded, or the default if it doesn't exist</returns>
        public static TData Load<TData>(string key)
        {
            lock (typeof(DataManager))
            {
                string path = GetFilepath(key);
                if (File.Exists(path))
                {
                    using (var textReader = File.OpenText(path))
                    {
                        var jsonSerializer = new JsonSerializer();
                        var data = (TData)jsonSerializer.Deserialize(textReader, typeof(TData));
                        return data;
                    }
                }
                else
                {
                    return default;
                }
            }
        }

        /// <summary>
        /// Saves the data to the specified key
        /// </summary>
        /// <typeparam name="TData">The type of data that is being saved</typeparam>
        /// <param name="key">The key to save the data under</param>
        /// <param name="data">The data to save</param>
        public static void Save<TData>(string key, TData data)
        {
            lock (typeof(DataManager))
            {
                string path = GetFilepath(key);
                try
                {
                    using (var streamWriter = File.CreateText(path))
                    {
                        var jsonSerializer = new JsonSerializer();
                        jsonSerializer.Serialize(streamWriter, data);
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    CreateDirectory();
                    Save(key, data);
                }
            }
        }

        /// <summary>
        /// Checks whether or not data exists under the key
        /// </summary>
        /// <param name="key">The key to check for data under</param>
        /// <returns>Whether or not the data exists</returns>
        public static bool Exists(string key)
        {
            lock (typeof(DataManager))
            {
                string path = GetFilepath(key);
                return File.Exists(path);
            }
        }

        /// <summary>
        /// Clears all saved data
        /// </summary>
        public static void Clear()
        {
            lock (typeof(DataManager))
            {
                var directoryInfo = new DirectoryInfo(Application.persistentDataPath);
                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    fileInfo.Delete();
                }
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    directory.Delete(true);
                }
            }
        }

        private static void CreateDirectory()
        {
            Directory.CreateDirectory(GetFolder());
        }

        private static string GetFolder()
        {
            return Application.persistentDataPath + Path.DirectorySeparatorChar + Folder;
        }

        private static string GetFilepath(string key)
        {
            return GetFolder() + Path.DirectorySeparatorChar + key + FileSuffix;
        }
    }
}