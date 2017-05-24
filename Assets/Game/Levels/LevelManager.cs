using System.Linq;
using UnityEngine;

namespace RED.Levels
{
    public class LevelManager : MonoBehaviour
    {
        public Level[] Levels;

        public void Awake()
        {
            this.Levels = GameObject.FindObjectsOfType<Level>().Reverse().ToArray();
            for (int i = 0; i < this.Levels.Length; i++)
                this.Levels[i].Index = i;
        }
    }
}
