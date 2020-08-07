using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour {

    private InputState inputState;
    public LayerMask collisionLayer;
	public bool standing;
	public bool onWall;
    public bool touchingWall;
    public bool pushing;
    //public bool hit;
    //public bool hitting; 
    public Vector2 bottomPosition = Vector2.zero;
	public Vector2 rightPosition = Vector2.zero;
	public Vector2 leftPosition = Vector2.zero;
    public float collisionRadius = 5.0f;
    
	public Color debugCollisionColor = Color.red;
    public Vector2 hitboxSize = new Vector2(0, 0);
    public Ray2D attackRay;
    public Vector2 attackPosition = Vector2.zero;
    public Vector2 hitboxPosition = Vector2.zero;

    void Awake () {
		inputState = GetComponent<InputState> ();
	}
	
	void Update () {
	}

	void FixedUpdate(){
		var pos = bottomPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
        standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);// && !pushing ? true : false;
		pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
        onWall = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer) && !standing ? true : false;
        touchingWall = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);
        pushing = touchingWall && !onWall ? true : false;
        //hitting = Physics2D.Raycast(pos, attackRay.direction, 20.0f);
        //hit = Physics2D.OverlapBox(pos, hitboxSize, collisionLayer);
    }

	void OnDrawGizmos(){
		Gizmos.color = debugCollisionColor;
		var circle_positions = new Vector2[] {rightPosition, bottomPosition, leftPosition, };
		foreach (var position in circle_positions) {
			var pos = position;
			pos.x += transform.position.x;
			pos.y += transform.position.y;
			Gizmos.DrawWireSphere (pos, collisionRadius);
		}

        var posa = hitboxPosition;
        var posb = attackPosition;
        posa.x += transform.position.x;
        posa.y += transform.position.y;
        posb.x += transform.position.x;
        posb.y += transform.position.y;

        Gizmos.DrawWireCube(posa, hitboxSize);
        Gizmos.DrawRay(posb, attackRay.direction);

        //var box_positions = new Vector2[] { hitboxPosition, attackPosition };
        //for(int i = 0;i< box_positions.Length;i++) {
        //    var pos = box_positions[i];
        //    pos.x += transform.position.x;
        //    pos.y += transform.position.y;
        //    Gizmos.DrawWireCube(pos, collisionSize);
        //}
	}
}
