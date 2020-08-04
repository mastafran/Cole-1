using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireSpellItem : Collectable {

	public int itemID = 1;
    public List<GameObject> projectiles;

    override protected void OnCollect(GameObject target){

        var equipBehavior = target.GetComponent<Equip> ();
		if(equipBehavior != null){
			equipBehavior.currentItem = itemID;
		}

		var fireBehavior = target.GetComponent<Throw> ();
		if (fireBehavior != null) {
			fireBehavior.projectiles = projectiles;
		}
	}
}
