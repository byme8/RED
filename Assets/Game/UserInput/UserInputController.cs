using System;
using System.Collections;
using UnityEngine;

namespace UserInput
{
    public class UserInputController : MonoBehaviour
    {
        private Coroutine handeling;

        IEnumerator Handeling()
        {
            var gameController = GameController.FindObjectOfType<GameController>();
            var inputProvider = this.CreateProvider();
            var time = Time.time;

            while (true)
            {
                yield return inputProvider.GetFirstPoint();
                var firstPosition = inputProvider.Position;

                yield return inputProvider.GetSecondPoint();
                var secondPosition = inputProvider.Position;

                var direction = secondPosition - firstPosition;
                var distance = direction.magnitude;

                if (distance > 0.5)
                    yield return gameController.LanuchBullet(firstPosition, direction);
            }
        }

        private IInputProvider CreateProvider()
        {
            if (Input.touchSupported)
                return new TouchInputProvider();

            return new MouseInputProvider();
        }

        public void StartHandeling()
        {
            this.handeling = this.StartCoroutine(this.Handeling());
        }

        public void StopHandeling()
        {
            this.StopCoroutine(this.handeling);
        }
    }
}
