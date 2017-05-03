using System.Collections;
using UnityEngine;

namespace UserInput
{
	public class UserInputController : MonoBehaviour
	{
		public IEnumerator Start()
		{
            var gameController = GameController.FindObjectOfType<GameController>();
            var camera = GameController.FindObjectOfType<Camera>();
			var inputProvider = new MouseInputProvider(camera);
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
				{
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
	}
}
