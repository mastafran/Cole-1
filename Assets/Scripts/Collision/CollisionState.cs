using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour
{

    private InputState inputState;
    public LayerMask collisionLayer;
    public bool onGround;
    public bool moving;
    public bool onWall;
    public bool touchingWall;
    public bool pushing;
    public Vector2 groundPos = Vector2.zero;
    public Vector2 rightGripPos = Vector2.zero;
    public Vector2 leftGripPos = Vector2.zero;
    public Vector3 wallGripSize = Vector3.zero;
    public Vector3 groundCollisionSize = Vector3.zero;

    public Color debugCollisionColor = Color.red;
    float rayDistance = 1.0f;

    void Awake() {
        inputState = GetComponent<InputState>();
    }

    private bool Grounded(Vector2 pos) {
        RaycastHit2D groundHit = Physics2D.Raycast(pos, Vector2.down, rayDistance, collisionLayer.value, 0);
        if (groundHit.collider != null) { /*If object collider is 'hit' = not NUll*/
            Debug.Log("On Ground: " + groundHit.collider.tag);
        }
        return groundHit.collider != null; /*If the ray hits ground return true,else false*/
    }

    private bool OnWall(Vector2 pos) {
        RaycastHit2D wallHit = Physics2D.Raycast(pos, inputState.direction == Directions.Right ? Vector2.right : Vector2.left, rayDistance, collisionLayer.value, 0);
        if (wallHit.collider != null) {
            Debug.Log("On Wall: " + wallHit.collider.tag);
        }
        return wallHit.collider != null;
    }

    private bool TouchingWall(Vector2 pos) {
        RaycastHit2D wallHit = Physics2D.Raycast(pos, inputState.direction == Directions.Right ? Vector2.right : Vector2.left, rayDistance, collisionLayer.value, 0);
        if (wallHit.collider != null) {
            Debug.Log("Touching Wall: " + wallHit.collider.tag);
        }
        return wallHit.collider != null;
    }

    void FixedUpdate() {
        Vector2 pos = groundPos;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        moving = gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 && !onWall;
        onGround = Grounded(pos);
        pos = inputState.direction == Directions.Right ? rightGripPos : leftGripPos;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        onWall = OnWall(pos) && !onGround;
        touchingWall = TouchingWall(pos);
        pushing = touchingWall && !onWall && onGround && moving;
    }

    void OnDrawGizmos() {
        Gizmos.color = debugCollisionColor;
        Vector2 groundBox = groundPos;
        groundBox.x += transform.position.x;
        groundBox.y += transform.position.y;
        Gizmos.DrawWireCube(groundBox, groundCollisionSize);

        Vector2[] box_positions = new Vector2[] { rightGripPos, leftGripPos, };
        //for(int i = 0; i<box_positions.Length;i++) {
        //    Vector2 pos = box_positions[i];
        //    pos.x += transform.position.x;
        //    pos.y += transform.position.y;
        //    Gizmos.DrawWireCube(pos, wallGripSize);
        //}

        foreach (var position in box_positions)
        {
            var pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;
            Gizmos.DrawWireCube(pos, wallGripSize);
        }

    }
}
