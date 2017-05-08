using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace RED.Levels
{
    public class LevelsManager : MonoBehaviour
    {
        const string LevelsStorageFileName = "Assets/Game/Levels/Scenes.json";

        public TextAsset Scenes;

        void Start()
        {
            this.Levels = JsonConvert.DeserializeObject<string[]>(this.Scenes.text, Settings).Select(o => new Level(o));
        }

        static JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        };

#if UNITY_EDITOR
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
#endif

        public IEnumerable<Level> Levels
        {
            get;
            private set;
        }
    }
}
