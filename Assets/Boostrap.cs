using RED.Game.Saving;
using UnityEngine;
using UniRx;

namespace RED
{
    public class Boostrap : MonoBehaviour
    {
        private void Awake()
        {
            GameSaver.Instance.Load();
        }
    }
}
