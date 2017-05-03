using System.Collections;
using UnityEngine;

namespace UserInput
{
	public interface IInputProvider
	{
		Vector3 Position
		{
			get;
			set;
		}

		IEnumerator GetFirstPoint();

		IEnumerator GetSecondPoint();
	}
}