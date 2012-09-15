using UnityEngine;
using System.Collections;

public class FireProducer : MonoBehaviour {
    public ParticleEmitter emitter;			
    bool doFire = false;

    void Start() {
	emitter.emit = false;
    }

    void OnPointCloudCollisionEnter() {
	if (doFire) {
	    emitter.emit = true;
	}
    }

    void OnPointCloudCollisionExit() {
	emitter.emit = false;
    }

    public void StopFire() {
	emitter.emit = false;
	doFire = false;
    }

    public void StartFire() {
	doFire = true;
    }
}
