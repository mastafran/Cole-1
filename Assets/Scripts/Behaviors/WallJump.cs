using UnityEngine;
using System.Collections;

public class WallJump : EntityBehavior {

	public Vector2 jumpVelocity = new Vector2(100, 100);
	public bool jumpingOffWall;
	public float resetDelay = 0.5f;

	private float timeElapsed = 0;
	
	void Update () {
	
		if (collisionState.onWall && !collisionState.onGround) {

			var canJump = inputState.GetButtonValue(inputButtons[0]);

			if(canJump && !jumpingOffWall){

				inputState.direction = inputState.direction == Directions.Right ? Directions.Left : Directions.Right;
				body2d.velocity = new Vector2(jumpVelocity.x * (float)inputState.direction, jumpVelocity.y);

				ToggleScripts(false);
				jumpingOffWall = true;
			}

		}

		if (jumpingOffWall) {
			timeElapsed += Time.deltaTime;

			if(timeElapsed > resetDelay){
				ToggleScripts(true);
				jumpingOffWall = false;
				timeElapsed = 0;
			}
		}

	}
}
