using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace RED.Levels
{
    public class LevelsManager
    {
        const string LevelsStorageFileName = "Assets/Game/Levels/Scenes.json";

        static LevelsManager()
        {
            if (!File.Exists(LevelsStorageFileName))
                return;

            using (var input = new StreamReader(LevelsStorageFileName))
            {
                Levels = JsonConvert.DeserializeObject<string[]>(input.ReadToEnd(), Settings);
            }
        }

        static JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        };

        [UnityEditor.MenuItem("Assets/Update Scene Names")]
        private static void UpdateNames(UnityEditor.MenuCommand command)
        {
            var scenesWithLevels = UnityEditor.EditorBuildSettings.scenes.Where(o => o.path.Contains("Levels")).Select(o => o.path).ToArray();
            var json = JsonConvert.SerializeObject(scenesWithLevels, Settings);
            using (var output = new StreamWriter(LevelsStorageFileName, false))
            {
                output.WriteLine(json);
            }
        }

        public static IEnumerable<string> Levels
        {
            get;
            private set;
        }
    }
}
