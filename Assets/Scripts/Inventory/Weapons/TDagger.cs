using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TDagger : MonoBehaviour
{
    private Vector2 initialVelocity = new Vector2(128, -64);
    private readonly int bounces = 1;

    public GameObject top;
    public GameObject bottom;

    private Rigidbody2D top_body;
    private Rigidbody2D center_body;
    private Rigidbody2D bottom_body;
    private List<Rigidbody2D> t_daggers;

    void Awake() {
        t_daggers = new List<Rigidbody2D>();
        center_body = GetComponent<Rigidbody2D>();

        top_body = top.GetComponent<Rigidbody2D>();
        bottom_body = bottom.GetComponent<Rigidbody2D>();

        t_daggers.Add(top_body);
        t_daggers.Add(center_body);
        t_daggers.Add(bottom_body);
    }

    void Start() {

        var startVelX = initialVelocity.x * transform.localScale.x;

        top_body.velocity = new Vector2(startVelX, initialVelocity.y);
        center_body.velocity = new Vector2(startVelX, initialVelocity.y);
        bottom_body.velocity = new Vector2(startVelX, initialVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D target) {
        StartCoroutine(FlingDagger(target));
        Destroy(gameObject, 0.5f);
    }

    private IEnumerator FlingDagger(Collision2D target) {
        //RigidbodyConstraints2D constraints;
        //constraints = RigidbodyConstraints2D.None;
        //for (int i=0; i<daggers.Count; i++){
        //    daggers[i].constraints = constraints;
        //    daggers[i].velocity = new Vector2(128, -128);
        //    daggers[i].angularVelocity = 40.0f;
        //    daggers[i].MoveRotation(45);
        //    constraints = RigidbodyConstraints2D.FreezeAll;
        //}       
        yield return new WaitForSeconds(0.4f);

    }
}
