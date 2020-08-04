using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Throw : EntityBehavior {

	public float shootDelay = .5f;
	public List<GameObject> projectiles;
	public Vector2 firePosition = Vector2.zero;
	public Color debugColor = Color.yellow;
	public float debugRadius = 3f;
    public bool throwing;
	private float timeElapsed = 0f;

    void Update() {
        if (projectiles != null) {
            var canFire = inputState.GetButtonValue(inputButtons[0]);

            if (canFire && timeElapsed > shootDelay) {
                OnThrow(true);
            }
            else if (throwing && !canFire) {
                OnThrow(false);
            }
            timeElapsed += Time.deltaTime;
        }
    }

    protected virtual void OnThrow(bool value) {
        throwing = value;
        if (throwing) {
            CreateProjectile(CalculateFirePosition());
            timeElapsed = 0;
        } 
    }

    public void CreateProjectile(Vector2 pos) {

        for (int i = 0; i < projectiles.Count; i++) {
            var clone = Instantiate(projectiles[i], pos, Quaternion.identity) as GameObject;
            clone.transform.localScale = transform.localScale;
        }
    }

    Vector2 CalculateFirePosition() {
        var pos = firePosition;
        pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return pos;
    }

    void OnDrawGizmos() {
        Gizmos.color = debugColor;

        var pos = firePosition;
        if (inputState != null)
            pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, debugRadius);
    }

    
}
