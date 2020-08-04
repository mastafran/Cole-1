using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DaggerItem : Collectable {

    public int itemID = 2;
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
