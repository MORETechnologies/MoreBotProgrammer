using System.IO;
using Newtonsoft.Json;

namespace MoreBotProgrammer.Core
{
    class JsonProgramStorage
    {
        const string ProgramDirectory = "programs";
        const string FileName = "program.json";

        string directoryPath;
        string filePath;
        JsonSerializerSettings settings;

        public JsonProgramStorage(string baseDirectory)
        {
            directoryPath = Path.Combine(baseDirectory, ProgramDirectory);
            filePath = Path.Combine(directoryPath, FileName);

            Directory.CreateDirectory(directoryPath);

            settings = new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto
            };
        }

        public void Write(UserProgramEntity program)
        {
            string json = JsonConvert.SerializeObject(program, settings);
            File.WriteAllText(filePath, json);
        }

        public UserProgramEntity Read()
        {
            string json = "";
            if (File.Exists(filePath)) {
                json = File.ReadAllText(filePath);
            }

            try {
                return JsonConvert.DeserializeObject<UserProgramEntity>(json, settings);
            } catch (JsonSerializationException) {
                return null;
            }
        }
    }
}
