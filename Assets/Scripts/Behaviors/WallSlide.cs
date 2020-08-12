using UnityEngine;
using System.Collections;

public class WallSlide : StickToWall {

	public float slideVelocity = -5f;
	public float slideMultiplier = 5f;
	public GameObject sparksPrefab;
	public float sparksDelay = .5f;
	private float timeElapsed = 0f;

	override protected void Update () {
		base.Update ();
		if (onWallDetected && !collisionState.onGround) {
			float velY = slideVelocity;
			if(inputState.GetButtonValue(inputButtons[0]))
				velY *= slideMultiplier;

			body2d.velocity = new Vector2(body2d.velocity.x, velY);

			if(timeElapsed > sparksDelay) {

				GameObject dust = Instantiate(sparksPrefab);
				Vector3 pos = transform.position;
				dust.transform.position = pos;
				dust.transform.localScale = transform.localScale;
				timeElapsed = 0;
			}
			timeElapsed += Time.deltaTime;
		}
	}

	override protected void OnStick(){
		body2d.velocity = Vector2.zero;
	}

	override protected void OffWall(){
		timeElapsed = 0;
	}
}
