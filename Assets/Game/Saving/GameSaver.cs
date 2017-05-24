using System.IO;
using Newtonsoft.Json;
using RED.Utils;
using UnityEngine;

namespace RED.Game.Saving
{
    public class GameSaver : Singletone<GameSaver>
    {
        string path = Application.persistentDataPath + "/user.settings.json";

        public void Save()
        {
           
            File.WriteAllText(this.path, JsonConvert.SerializeObject(GameSettings.Instance.GetState()));
        }

        public void Load()
        {
            if (!File.Exists(this.path))
            {
                Debug.Log("Settings missing");
                return;
            }
            GameSettings.Instance.SetState(JsonConvert.DeserializeObject<GameState>(File.ReadAllText(this.path)));
        }
    }
}
