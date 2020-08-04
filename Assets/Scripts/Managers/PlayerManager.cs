using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehavior;
	private Animator animator;
	private CollisionState collisionState;
	private Duck duckBehavior;
    private Throw throwBehaviour;
    private Attack attackBehaviour;

    void Awake(){
		inputState = GetComponent<InputState> ();
		walkBehavior = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
		collisionState = GetComponent<CollisionState> ();
		duckBehavior = GetComponent<Duck> ();
        throwBehaviour = GetComponent<Throw>();
        attackBehaviour = GetComponent<Attack>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collisionState.standing) {
            walkBehavior.attacking = false;
            ChangeAnimationState(0);
		}
        
        if (inputState.absVelX > 0) {
            walkBehavior.attacking = false;
            ChangeAnimationState(1);
		}

		if (inputState.absVelY > 0) {
            walkBehavior.attacking = false;
            ChangeAnimationState(2); // jump
		}

        if (!collisionState.standing && gameObject.GetComponent<Rigidbody2D>().velocity.y < -0.1f) {
            walkBehavior.attacking = false;
            ChangeAnimationState(8); // fall
        }

        animator.speed = walkBehavior.running ? walkBehavior.runMultiplier : 1;
        

        if (duckBehavior.ducking) {
            walkBehavior.attacking = false;
            ChangeAnimationState(3); // duck
		}

		if (!collisionState.standing && collisionState.onWall) {
            walkBehavior.attacking = false;
            ChangeAnimationState(4); // slide
		}

        if (throwBehaviour.throwing && !walkBehavior.running) {
            walkBehavior.attacking = false;
            ChangeAnimationState(5); // throw
        }

        if (attackBehaviour.attacking && !throwBehaviour.throwing) {
            walkBehavior.attacking = true;
            ChangeAnimationState(6); // attack
            
        }

        if (walkBehavior.running && !(inputState.absVelY > 0) && !duckBehavior.ducking ) {
            walkBehavior.attacking = false;
            ChangeAnimationState(7); // run
        }
    }

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}
