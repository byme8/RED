using System;
using System.Collections;
using UnityEngine;

namespace UserInput
{
    public class UserInputController : MonoBehaviour
    {
        public IEnumerator Start()
        {
            var gameController = GameController.FindObjectOfType<GameController>();
            var inputProvider = this.CreateProvider();
            var time = Time.time;

            while (true)
            {
                Debug.LogError("Start");
                yield return inputProvider.GetFirstPoint();
                var firstPosition = inputProvider.Position;

                yield return inputProvider.GetSecondPoint();
                var secondPosition = inputProvider.Position;
                Debug.LogError("Finish");

                var direction = secondPosition - firstPosition;
                var distance = direction.magnitude;

                if (distance > 0.5)
                {
                    Debug.LogError("Launch bullet");
                    yield return gameController.LanuchBullet(firstPosition, direction);
                    continue;
                }
                else
                {
                    Debug.Log("Toggle UI");
                    //this.ToggleUI();
                }
            }
        }

        private IInputProvider CreateProvider()
        {
            if (Input.touchSupported)
            {
                Debug.LogError("Touch");
                return new TouchInputProvider();
            }

            Debug.LogError("Mouse");
            return new MouseInputProvider();
        }
    }
}
