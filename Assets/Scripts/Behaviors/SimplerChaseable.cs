using UnityEngine;
using System.Collections;

[AddComponentMenu("TGT-Behaviors/SimplerChaseable")]
public class SimplerChaseable : MonoBehaviour {

    public GameObject _prey;
    public float _speed;
    private int _directionInt;

	// Use this for initialization
	void Start () {
	
	}
	
    void Update() {
        this.GetComponent<Animator>().SetFloat("move", this._speed);

        if (this.transform.position.x > this._prey.transform.position.x) {
            this._directionInt = -1;
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        } else {
            this._directionInt = 1;
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this._speed * this._directionInt, this.GetComponent<Rigidbody2D>().velocity.y);
    }

    public void SetPrey(GameObject prey) {
        this._prey = prey;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Crystal") {
            Destroy(this.gameObject);
        }
    }
}
