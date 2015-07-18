using UnityEngine;
using System.Collections;

namespace SpawnConditions {
    [AddComponentMenu("TGT-SpawnConditions/Automatic")]
    public class Automatic : MonoBehaviour {
        public void Start() {
            if (this.GetComponent<Spawnable>() != null) {
                this.GetComponent<Spawnable>().startPortal();
            }
        }
    }
}

