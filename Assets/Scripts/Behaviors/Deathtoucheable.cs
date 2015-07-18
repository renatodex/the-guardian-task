using UnityEngine;
using System.Collections;

[AddComponentMenu("TGT-Behaviors/Deathoucheable")]
public class Deathtoucheable : MonoBehaviour {

    public delegate void OnDeathEvent();
    public OnDeathEvent OnDeath;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Enemy") {
            OnDeath();
        }
    }
}
