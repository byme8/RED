using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using RED.Entities;
using UnityEngine;
using UserInput;

namespace RED.Levels
{
    public class LevelController : MonoBehaviour
    {
        public UserInputController UserInputController;

        private Entity[] entities;

        public IEnumerator Show()
        {
            this.entities = GameObject.FindObjectsOfType<Entity>();
            yield return this.entities.Select(o => o.Show()).ParallelCoroutines();
            this.UserInputController.StartHandeling();
        }

        public  IEnumerator Hide()
        {
            yield return this.entities.Select(o => o.Hide()).ParallelCoroutines();
        }
    }
}
