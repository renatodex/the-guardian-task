using UnityEngine;
using System.Collections;

namespace SpawnConditions {


    [AddComponentMenu("TGT-SpawnConditions/After Portal End")]
    public class AfterPortalEnd : MonoBehaviour {

        public GameObject _portal;

        // Use this for initialization
        void Start() {
            this._portal.GetComponent<Spawnable>().OnEnd += OnEnd;
        }

        private void OnEnd() {
            Debug.Log("Aha, agora acabou. Minha vez!");
            if (this.GetComponent<Spawnable>() != null) {
                this.GetComponent<Spawnable>().startPortal();
            }
        }

        // Update is called once per frame
        void Update() {

        }
    }

}
