
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace CSharpDllLibrary
{
    public class FileLibrary
    {
        public static void WriteFile(string filePath, string value)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] valueToFile = Encoding.Default.GetBytes(value);
                fs.Write(valueToFile, 0, valueToFile.Length);
                if (fs.Length == 0) throw new Exception("File isn`t recorded!");
            }
        }
        public static string ReadFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                if (fs.Length == 0) throw new Exception("File is empty!");
                byte[] valueToRead = new byte[(int)fs.Length];
                fs.Read(valueToRead, 0, valueToRead.Length);
                return Encoding.Default.GetString(valueToRead);
            }
        }
        public static string[] SearchByMask(string path, string mask)
        {
            //Regex regex = new Regex(@"^\*\.[a - z] {3, 4}");
            if (!Directory.Exists(path)) throw new FileNotFoundException("Directory isn`t exists!");
            else return Directory.GetFiles(path, mask, SearchOption.AllDirectories);
        }
        public static void DeleteFilesByMask(string path, string mask)
        {
            string[] files = SearchByMask(path, mask);
            foreach (var item in files)
                File.Delete(item);
        }
        public static void DeleteSubDirectories(string rootPath)
        {
            string[] subDirs = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
            foreach (var item in subDirs)
                Directory.Delete(item, true);
        }
        public static string[] ShowAllByPath(string path)
        {
            if (!Directory.Exists(path)) throw new FileNotFoundException("Directory isn`t exists!");
            return Directory.GetFileSystemEntries(path);
        }
        public static void ReplaceWordsInFile(string toReplace, string onReplace, string fileName)
        {
            string fromFile = ReadFile(fileName);
            if (fromFile.Contains(toReplace))
            {
                string buffer = Regex.Replace(fromFile, toReplace, onReplace);
                WriteFile(fileName, buffer);
            }
            else throw new Exception("There isn`t such a words to replace!");
        }
        public static void ModerateText(string fileNameForMod, string fileNameWithWords)
        {
            string buffForMod = ReadFile(fileNameForMod);
            string buffWithWords = ReadFile(fileNameWithWords);
            if (buffForMod.Contains(buffWithWords))
            {
                string newBuffer = Regex.Replace(buffForMod, buffWithWords, "***");
                WriteFile(fileNameForMod, newBuffer);
            }
            else throw new Exception("There isn`t such a words to moderate!");
        }
        public static void TurnOverText(string oldPath, string newPath)
        {
            string fromfile = ReadFile(oldPath);
            char[] toFileCharArr = fromfile.ToCharArray();
            string toFile = String.Empty;
            for (int i = toFileCharArr.Length - 1; i > -1; i--)
                toFile += toFileCharArr[i];
            WriteFile(newPath, toFile);
        }
        public class XMLOperation
        {
            public static void Serialize<T>(T obj, string fileName)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "\t", };
                XmlWriter writer = XmlWriter.Create(fileName, settings);
                serializer.WriteObject(writer, obj);
                writer.Close();
                if (!File.Exists(fileName)) throw new FileNotFoundException(fileName);
            }
            public static T Deserialize<T>(string fileName)
            {
                if (!File.Exists(fileName)) throw new FileNotFoundException(fileName);
                FileStream stream = new FileStream(fileName, FileMode.Open);
                XmlTextReader reader = new XmlTextReader(stream);
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                T obj = (T)serializer.ReadObject(reader, true);
                reader.Close(); stream.Close();
                return obj;
            }
        }
    }
}