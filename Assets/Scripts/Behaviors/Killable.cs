using UnityEngine;
using System.Collections;

[AddComponentMenu("TGT-Behaviors/Killable")]
public class Killable : MonoBehaviour {

	public delegate void OnDiedEvent(GameObject g);
	public OnDiedEvent OnDied;

	public delegate void OnDamagedEvent(GameObject g, int total_life, int actual_life, int damage_received);
	public OnDamagedEvent OnDamaged;

	public int total_lifes;
	public int actual_lifes;

	public void Start() {
		this.actual_lifes = this.total_lifes;
	}
	
	public void receiveDamage(GameObject damagingEntity) {
		int amount = damagingEntity.GetComponent<Damageable>().power;

		if((this.actual_lifes - amount) <= 0) {
			this.actual_lifes = 0;
			OnDied(this.gameObject);
		} else {
			this.actual_lifes -= amount;
			OnDamaged(this.gameObject, this.total_lifes, this.actual_lifes, amount);
		}
	}
}
