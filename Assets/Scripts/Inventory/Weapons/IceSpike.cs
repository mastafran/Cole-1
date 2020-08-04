using UnityEngine;
using System.Collections;

public class IceSpike : MonoBehaviour
{
    public Vector2 initialVelocity = new Vector2(256, -100);
    public GameObject iceImpactFX;
    private Rigidbody2D body2d;

    void Awake() {
        body2d = GetComponent<Rigidbody2D>();
    }

    void Start() {
        var startVelX = initialVelocity.x * transform.localScale.x;
        body2d.velocity = new Vector2(startVelX, initialVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D target) {
        var clone = Instantiate(iceImpactFX);
        clone.transform.position = transform.position;
        clone.transform.localScale = transform.localScale;
        Destroy(gameObject);      
    }
}
