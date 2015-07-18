using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    public GameObject[] _portalObjects;
    public float[] _portalTimes;
    public bool _onePortalAtTime;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < this._portalObjects.Length; i++) {
            Invoke("spawn", this._portalTimes[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void spawn() {
        Debug.Log("Spawnado!");
    }
}
