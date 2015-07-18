using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("TGT-Behaviors/Spawnable")]
public class Spawnable : MonoBehaviour {

    public float _frequency;
    public int _charges;
    public GameObject[] _travellers;
    public AudioClip _startSound;
    public AudioClip _endSound;

    public delegate void OnEndEvent();
    public OnEndEvent OnEnd;

    public delegate void OnChargeUsedEvent(int actual_charges);
    public OnChargeUsedEvent OnChargeUsed;

    public void playStartSound() {
        AudioSource.PlayClipAtPoint(this._startSound, this.transform.position);
    }

    public void playEndSound() {
        Debug.Log("playing");
        AudioSource.PlayClipAtPoint(this._endSound, this.transform.position);
    }

    public void startPortal() {
        this.updateChargesLabel();
        this.GetComponent<Animator>().SetTrigger("spawn");
        Invoke("spawn", this._frequency);
        this.playStartSound();
    }

    public void spawn() {
        Vector3 spawnPosition = this.transform.position;
        spawnPosition.z -= 10f;

        int idx = Random.Range(0, this._travellers.Length);
        GameObject entity = (this._travellers[idx]);

        entity.GetComponent<SimplerChaseable>().SetPrey(GameObject.Find("Orb"));
        Instantiate(entity, spawnPosition, entity.transform.rotation);

        /*foreach (GameObject entity in this._travellers) {
            entity.GetComponent<SimplerChaseable>().SetPrey(GameObject.Find("Crystal"));
            Instantiate(entity, spawnPosition, entity.transform.rotation);
        }*/

        float randomTime = Random.Range(0f, this._frequency);
        Invoke("spawn", randomTime);

        this.updateChargesLabel();

        this._charges--;

        if (OnChargeUsed != null) {
            OnChargeUsed(this._charges);
        }


        if (this._charges <= 0) {

            if (OnEnd != null) {
                OnEnd();
            }
            this.GetComponent<Animator>().SetTrigger("die");
        }
    }

    public void updateChargesLabel() {
        if(this.GetComponentInChildren<Text>() != null)
            this.GetComponentInChildren<Text>().text = this._charges.ToString();
    }

    public void clearChargesLabel() {
        if (this.GetComponentInChildren<Text>() != null)
            this.GetComponentInChildren<Text>().text = "";
    }

    public int getCharges() {
        return this._charges;
    }
}
