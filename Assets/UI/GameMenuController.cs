using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using UnityEngine;

namespace RED.UI
{
    public class GameMenuController : MonoBehaviour
    {
        public GameController GameController;

        public void ToMainMenu()
        {
            Debug.Log("Test");
        }

        public void Restart()
        {
            this.GameController.Restart().StartCoroutine();
        }
    }
}
