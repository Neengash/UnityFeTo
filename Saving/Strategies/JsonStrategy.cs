using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace FeTo.Saving
{
    [CreateAssetMenu(menuName = "Saving Strategies/Json", fileName = "JsonStrategy")]
    public class JsonStrategy : SavingStrategy
    {
        public override string GetExtension() => ".json";

        public override void SaveToFile(string saveFile, JObject state) {
            var path = GetPathFromSaveFile(saveFile);
            using (var textWriter = File.CreateText(path)) {
                using (var writer = new JsonTextWriter(textWriter)) {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, state);
                }
            }
        }

        public override JObject LoadFromFile(string saveFile) {
            string path = GetPathFromSaveFile(saveFile);
            if (!File.Exists(path)) return new JObject();

            using (var textReader = File.OpenText(path)) {
                using (var reader = new JsonTextReader(textReader)) {
                    reader.FloatParseHandling = FloatParseHandling.Double;
                    return JObject.Load(reader);
                }
            }
        }
    }
}