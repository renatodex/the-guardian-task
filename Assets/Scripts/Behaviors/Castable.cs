using UnityEngine;
using System.Collections;

[AddComponentMenu("TGT-Behaviors/Castable")]
public class Castable : MonoBehaviour {

    public GameObject spell;
    public float castCooldown;
    public float fixedY;
    public AudioClip cooldownSound;
    public float spellCooldown;
    public float cooldownDecay;

    public void Start() {
        StartCoroutine("CooldownControl");
    }

    public IEnumerator CooldownControl() {
        while (true) {
            if (this.castCooldown-this.cooldownDecay > 0) { 
                this.castCooldown -= this.cooldownDecay;
            } else {
                this.castCooldown = 0f;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void playCooldownSound() {
        AudioSource.PlayClipAtPoint(this.cooldownSound, this.transform.position);
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            if (this.castCooldown == 0) {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 castingPosition = new Vector3(mousePosition.x, this.fixedY, 0f);

                Instantiate(this.spell, castingPosition, this.spell.transform.rotation);

                this.castCooldown = this.spellCooldown;
            } else {
                this.playCooldownSound();
            }
        }   
	}

    public void OnGUI() {
        if(GUILayout.Button("Look at the lonely")) {
            StartCoroutine("lookToLonely");
        }
    }

    IEnumerator lookToLonely() {
        Vector3 lonelyPosition = GameObject.Find("lonely").transform.position;
        Vector3 cameraPosition = Camera.main.transform.localPosition;

        Vector3 destination = new Vector3(
            lonelyPosition.x,
            lonelyPosition.y,
            Camera.main.transform.position.z
         );
        while (true) {
            Camera.main.transform.localPosition = Vector3.MoveTowards(Camera.main.transform.position, destination, 1);
            Debug.Log("AAHHH");

            lonelyPosition = GameObject.Find("lonely").transform.position;
            cameraPosition = Camera.main.transform.localPosition;

            if (lonelyPosition.x == cameraPosition.x && lonelyPosition.y == cameraPosition.y) {
                yield break;
            }

            yield return null;
        }
    }
}
