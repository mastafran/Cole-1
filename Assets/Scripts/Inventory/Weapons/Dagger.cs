using UnityEngine;
using System.Collections;

public class Dagger : MonoBehaviour {

    private Vector2 initialVelocity = new Vector2(256, -128);
    private Rigidbody2D body2d;

    void Awake() {
        body2d = GetComponent<Rigidbody2D>();
    }

    void Start() {
        var startVelX = initialVelocity.x * transform.localScale.x;
        body2d.velocity = new Vector2(startVelX, initialVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D target) {

        StartCoroutine(FlingDagger(target));
        Destroy(gameObject, 0.5f);
    }

    private IEnumerator FlingDagger(Collision2D target) {
        RigidbodyConstraints2D constraints;
        constraints = RigidbodyConstraints2D.None;
        body2d.constraints = constraints;
        body2d.velocity = new Vector2(128, -128);
        body2d.angularVelocity = 40.0f;
        body2d.MoveRotation(45);
        constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(0.4f);

    }
}
