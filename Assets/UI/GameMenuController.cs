using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using RED.UI.Core;
using UnityEngine;

namespace RED.UI
{
    public class GameMenuController : MonoBehaviour
    {
        public GameController GameController;

        public void ToMainMenu()
        {
            this.ToMainMenuCoroutine().StartCoroutine();
        }

        private IEnumerator ToMainMenuCoroutine()
        {
            yield return this.GameController.Unload();
            yield return Navigator.Instance.CategoriesPage.Navigate();
        }

        public void Restart()
        {
            this.GameController.Restart().StartCoroutine();
        }
    }
}
