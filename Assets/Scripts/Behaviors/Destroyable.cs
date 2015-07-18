using UnityEngine;
using System.Collections;

[AddComponentMenu("TGT-Behaviors/Destroyable")]
public class Destroyable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void autoDestroy() {
        Destroy(this.gameObject);
    }
}
