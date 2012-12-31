using UnityEngine;
using System.Collections;

public class BlobProducer : MonoBehaviour {
    public ParticleEmitter emitter;			
    bool doBlob = false;

    void Start() {
	emitter.emit = false;
    }

    void OnPointCloudCollisionEnter() {
	if (doBlob) {
	    emitter.emit = true;
	}
    }

    void OnPointCloudCollisionExit() {
	emitter.emit = false;
    }

    public void StopBlob() {
	emitter.emit = false;
	doBlob = false;
    }

    public void StartBlob() {
	doBlob = true;
    }
}
