using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour {
    private void Awake() {
        Destroy(gameObject, 5.0f);
    }
}
