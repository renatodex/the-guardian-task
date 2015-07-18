using UnityEngine;
using System.Collections;

[AddComponentMenu("TGT-Behaviors/Damageable")]
public class Damageable : MonoBehaviour {
	public int power;

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject g = collision.gameObject;
        if (g.GetComponent<Killable>()) {
            g.GetComponent<Killable>().receiveDamage(this.gameObject);
        }
    }
}
