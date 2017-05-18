using System.Linq;
using UnityEngine;

namespace RED.Levels
{
    public class LevelsManager : MonoBehaviour
    {
        public Level[] Levels;

        public void Awake()
        {
            this.Levels = GameObject.FindObjectsOfType<Level>().Reverse().ToArray();
        }
    }
}
