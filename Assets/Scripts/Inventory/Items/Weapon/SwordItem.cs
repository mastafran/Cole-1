using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordItem : Collectable
{
    public int itemID = 5;

    override protected void OnCollect(GameObject target) {

        var equipBehavior = target.GetComponent<Equip>();
        if (equipBehavior != null) {
            equipBehavior.currentItem = itemID;
        }

        var attackBehavior = target.GetComponent<Attack>();
        if (attackBehavior != null) {
            
        }
    }
}
