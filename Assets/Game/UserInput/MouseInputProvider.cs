using System;
using System.Collections;
using UnityEngine;

namespace UserInput
{
	public class MouseInputProvider : IInputProvider
	{
		private Camera Camera;

		public MouseInputProvider(Camera camera)
		{
			this.Camera = camera;
		}

		public Vector3 Position
		{
			get;
			set;
		}

		public IEnumerator GetFirstPoint()
		{
			yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
			var position = this.Camera.ScreenToWorldPoint(Input.mousePosition);
			this.Position = new Vector3(position.x, position.y, 0);
		}

		public IEnumerator GetSecondPoint()
		{
			yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
			var position = this.Camera.ScreenToWorldPoint(Input.mousePosition);
			this.Position = new Vector3(position.x, position.y, 0);
		}
	}
}