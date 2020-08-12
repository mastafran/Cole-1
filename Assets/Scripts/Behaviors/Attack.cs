using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack : EntityBehavior
{

    public Transform target;// enemy nearbye. loaded as potential target only
    public float attackRange;
    public float attackDelay = 0.5f;
    public bool attacking=false;
    private float timeElapsed = 0f;
    public Vector2 attackPosition = Vector2.zero;
    //public Collider2D dmgCollider;
    public Color debugColor = Color.yellow;
    public float debugRadius = 4f;
    
    void Update() {
        var canAttack = inputState.GetButtonValue(inputButtons[0]);

        if (canAttack && timeElapsed > attackDelay) {
            ToggleScripts(false);
            OnAttack(true);
        }
        else if (attacking && !canAttack) {
            ToggleScripts(true);
            OnAttack(false);
        }
        timeElapsed += Time.deltaTime;
    }

    Vector2 CalculateAttackPosition() {
        var pos = attackPosition;
        pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        return pos;
    }

    protected virtual void OnAttack(bool value) {
        attacking = value;
        if (attacking) {
            //dmgCollider.enabled = true;
            //dmgCollider = Physics2D.OverlapCircle(attackPosition, attackRange);
            timeElapsed = 0;
        } else {
            //dmgCollider.enabled = false;
        }
    }

    private void Start() {
        //dmgCollider.enabled = false;
    }

    //void OnDrawGizmos() {
    //    Gizmos.color = debugColor;
    //    var pos = attackPosition;
    //    if (inputState != null)
    //        pos.x *= (float)inputState.direction;
    //    pos.x += transform.position.x;
    //    pos.y += transform.position.y;
    //    Gizmos.DrawWireSphere(pos, debugRadius);
    //}

}
