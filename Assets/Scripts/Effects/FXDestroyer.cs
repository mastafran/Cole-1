using UnityEngine;
using System.Collections;

public class FXDestroyer : MonoBehaviour {

	void OnDestroy(){
		Destroy (gameObject);
	}
}
