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

        public void Write(ProgramEntity program)
        {
            string json = JsonConvert.SerializeObject(program, settings);
            File.WriteAllText(filePath, json);
        }

        public ProgramEntity Read()
        {
            string json = File.ReadAllText(FileName);
            return JsonConvert.DeserializeObject<ProgramEntity>(json, settings);
        }
    }
}
