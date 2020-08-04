using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;

    private void Awake() {
        offset = transform.position - target.transform.position;
    }

    void LateUpdate() {
        transform.position = target.transform.position + offset;
    }
}
