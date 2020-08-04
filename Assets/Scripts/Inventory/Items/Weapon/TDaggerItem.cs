using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDaggerItem : Collectable
{
    public int itemID = 3;
    public List<GameObject> projectiles;

    override protected void OnCollect(GameObject target) {        

        var equipBehavior = target.GetComponent<Equip>();
        if (equipBehavior != null) {
            equipBehavior.currentItem = itemID;
        }

        var throwBehavior = target.GetComponent<Throw>();
        if (throwBehavior != null) {
            throwBehavior.projectiles = projectiles;
        }
    }
}
