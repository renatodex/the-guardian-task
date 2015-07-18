using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public AudioClip _dyingSound;

	// Use this for initialization
	void Start () {
        if (this.GetComponent<Killable>() != null) {
            this.GetComponent<Killable>().OnDied += OnDied;
        }

        if (this.GetComponent<Killable>() != null) {
            this.GetComponent <Killable>().OnDamaged += OnDamaged;
        }

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
	}

    void OnDied(GameObject obj) {
        AudioSource.PlayClipAtPoint(this._dyingSound, this.transform.position);
        this.GetComponent<Animator>().SetTrigger("die");
    }


    void OnDamaged(GameObject g, int total_life, int actual_life, int received_damage) {
        Debug.Log("Hitted!");
    }

	
	// Update is called once per frame
	void Update () {
	
	}


}
