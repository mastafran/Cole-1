using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IceSpellItem : Collectable
{
    public int itemID = 4;
    public List<GameObject> projectiles;

    override protected void OnCollect(GameObject target) {

        var equipBehavior = target.GetComponent<Equip>();
        if (equipBehavior != null) {
            equipBehavior.currentItem = itemID;
        }

        var iceBehavior = target.GetComponent<Throw>();
        if (iceBehavior != null) {
            iceBehavior.projectiles = projectiles;
        }
    }
}
