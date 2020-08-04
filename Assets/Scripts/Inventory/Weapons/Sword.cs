using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Sword : MonoBehaviour
{
   

    void Awake() {
        
    }

    void Start() {       
    }

    void OnCollisionEnter2D(Collision2D target) {
        StartCoroutine(SwordAttack(target));
    }

    private IEnumerator SwordAttack(Collision2D target) {
        

        yield return new WaitForSeconds(0.4f);
    }
}
