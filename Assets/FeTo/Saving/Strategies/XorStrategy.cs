using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace FeTo.Saving
{
    [CreateAssetMenu(menuName = "FeTo Saving Strategies/Xor", fileName = "XorStrategy")]
    public class XorStrategy : KeySavingStrategy
    {
        [SerializeField] string key = "TwelveTwinsTwirledTwelveTwigs";

        public override string GetExtension() => ".xor";

        public string EncryptDecrypt(string szPlainText, string szEncryptionKey) {
            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++) {
                int stringIndex = iCount % szEncryptionKey.Length;
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ szEncryptionKey[stringIndex]);
                szOutStringBuild.Append(Textch);
            }

            return szOutStringBuild.ToString();
        }

        public override void SaveToFile(string saveFile, JObject state) {
            var path = GetPathFromSaveFile(saveFile);
            Debug.Log($"Saving to {path} ");
            using (var textWriter = File.CreateText(path)) {
                var json = state.ToString();
                var encoded = EncryptDecrypt(json, key);
                textWriter.Write(encoded);
            }
        }

        public override JObject LoadFromFile(string saveFile) {
            var path = GetPathFromSaveFile(saveFile);
            if (!File.Exists(path)) return new JObject();

            using (var textReader = File.OpenText(path)) {
                var encoded = textReader.ReadToEnd();
                var json = EncryptDecrypt(encoded, key);
                return (JObject)JToken.Parse(json);
            }
        }


    }
}