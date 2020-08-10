using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour {

    private InputState inputState;
    public LayerMask collisionLayer;
	public bool standing;
	public bool onWall;
    public bool touchingWall;
    public bool pushing;
    public Vector2 bottomPosition = Vector2.zero;
	public Vector2 rightPosition = Vector2.zero;
	public Vector2 leftPosition = Vector2.zero;
    public float collisionRadius = 5.0f;    
	public Color debugCollisionColor = Color.red;
    float rayDistance = 8.0f;
    //public bool hit;
    //public bool hitting;
    //public Vector2 hitboxSize = new Vector2(0, 0);
    //public Ray2D attackRay;
    //public Vector2 attackPosition = Vector2.zero;
    //public Vector2 hitboxPosition = Vector2.zero;

    void Awake () {
		inputState = GetComponent<InputState> ();
       
    }

    private bool Grounded(Vector2 pos) {       
        RaycastHit2D groundHit = Physics2D.Raycast(pos, Vector2.down, rayDistance, collisionLayer.value, 0);
        //If the collider of the object hit is not NUll
        if (groundHit.collider != null) {
            Debug.Log("Hitting: " + groundHit.collider.tag);
        }
        Color rayColor = Color.cyan;
        if (groundHit.collider != null) {
            rayColor = Color.red;//for debug purposes
        } else {
            rayColor = Color.blue;//for debug purposes
        }
        Debug.DrawRay(pos, Vector2.down * rayDistance, rayColor);//for debug purposes    
        return groundHit.collider != null; //If the ray hits ground return true,else false
    }

    private bool OnWall(Vector2 pos) {
        RaycastHit2D wallHit = Physics2D.Raycast(pos, inputState.direction == Directions.Right ? Vector2.right : Vector2.left, rayDistance, collisionLayer.value, 0);
        if (wallHit.collider != null) {
            Debug.Log("Wall Hitting: " + wallHit.collider.tag);
        }
        Color rayColor = Color.cyan;
        if (wallHit.collider != null) {
            rayColor = Color.red;//for debug purposes
        }
        else {
            rayColor = Color.blue;//for debug purposes
        }
        Debug.DrawRay(pos, inputState.direction == Directions.Right ? Vector2.right : Vector2.left * rayDistance, rayColor);//for debug purposes    
        return wallHit.collider != null; //If the ray hits ground return true,else false
    }

	void FixedUpdate(){
		Vector2 pos = bottomPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
        standing = Grounded(pos);
        //standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);// && !pushing ? true : false;
        pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
        onWall = OnWall(pos)==true && !standing ? true : false;
        //onWall = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer) && !standing ? true : false;
        touchingWall = OnWall(pos);
        //touchingWall = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);
        //pushing = touchingWall && !onWall ? true : false;
        pushing = touchingWall && !onWall && standing && gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero;
        //hitting = Physics2D.Raycast(pos, attackRay.direction, 20.0f);
        //hit = Physics2D.OverlapBox(pos, hitboxSize, collisionLayer);


        ////Length of the ray
        //float laserLength = 256f;
        ////int layerMask = LayerMask.GetMask("Solid");
        ////Get the first object hit by the ray
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, laserLength, collisionLayer, 0);
        ////If the collider of the object hit is not NUll
        //if (hit.collider != null) {
        //    //Hit something, print the tag of the object
        //    Debug.Log("Hitting: " + hit.collider.tag);
        //}
        ////Method to draw the ray in scene for debug purpose
        //Debug.DrawRay(transform.position, Vector2.right * laserLength, Color.red);
    }

	//void OnDrawGizmos(){
	//	Gizmos.color = debugCollisionColor;
	//	var circle_positions = new Vector2[] {rightPosition, bottomPosition, leftPosition, };
	//	foreach (var position in circle_positions) {
	//		var pos = position;
	//		pos.x += transform.position.x;
	//		pos.y += transform.position.y;
	//		Gizmos.DrawWireSphere (pos, collisionRadius);
	//	}

        //var posa = hitboxPosition;
        //var posb = attackPosition;
        //posa.x += transform.position.x;
        //posa.y += transform.position.y;
        //posb.x += transform.position.x;
        //posb.y += transform.position.y;

        //Gizmos.DrawWireCube(posa, hitboxSize);
        //Gizmos.DrawRay(posb, attackRay.direction);

        //var box_positions = new Vector2[] { hitboxPosition, attackPosition };
        //for(int i = 0;i< box_positions.Length;i++) {
        //    var pos = box_positions[i];
        //    pos.x += transform.position.x;
        //    pos.y += transform.position.y;
        //    Gizmos.DrawWireCube(pos, collisionSize);
        //}
	//}
}
