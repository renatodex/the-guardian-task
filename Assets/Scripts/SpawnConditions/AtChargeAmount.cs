using UnityEngine;
using System.Collections;


namespace SpawnConditions {
    [AddComponentMenu("TGT-SpawnConditions/AtChargeAmount")]
    public class AtChargeAmount : MonoBehaviour {

        public GameObject _portal;
        public int _chargeThreshold = 0;

        // Use this for initialization
        void Start() {
            this._portal.GetComponent<Spawnable>().OnChargeUsed += OnChargeUsed;
        }

        void OnChargeUsed(int actual_chages) {
            Debug.Log(actual_chages);
            if (actual_chages < this._chargeThreshold) {
                this.GetComponent<Spawnable>().startPortal();
                this._portal.GetComponent<Spawnable>().OnChargeUsed -= OnChargeUsed;
            }
        }
    }
}
