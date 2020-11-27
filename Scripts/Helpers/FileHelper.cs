using System.IO;
using UnityEngine;

namespace JorgeJGnz.Helpers
{
    public static class FileHelper
    {
        public static void WriteJson<T>(string fileName, T item)
        {
            string path = Application.persistentDataPath + "/" + fileName;

            string str = JsonUtility.ToJson(item);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(str);
                }
            }

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif

        }

        public static T ReadJson<T>(string fileName)
        {
            string path = Application.persistentDataPath + "/" + fileName;

            string str = "";

            try
            {
                StreamReader reader = new StreamReader(path);
                str = reader.ReadToEnd();
                reader.Close();

                T item = JsonUtility.FromJson<T>(str);
                return item;
            }
            catch (FileNotFoundException e)
            {
                Debug.LogWarning("File not found! : " + e.Message);
                return default(T);
            }
        }
    }
}
