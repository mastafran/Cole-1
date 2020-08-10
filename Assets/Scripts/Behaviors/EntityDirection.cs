using UnityEngine;
using System.Collections;

public class EntityDirection : EntityBehavior {
	
	void Update () {
		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);

		if (right) {
			inputState.direction = Directions.Right;
		} else if (left) {
			inputState.direction = Directions.Left;
		}
		transform.localScale = new Vector3 ((float)inputState.direction, 1, 1);
	}
}
