using UnityEngine;
using System.Collections;

public class EmitOnCollision : MonoBehaviour {
    public ParticleEmitter emitter;			

    void Start() {
		emitter.emit = false;
    }

    void OnPointCloudCollisionEnter() {
	    emitter.emit = true;
    }

    void OnPointCloudCollisionExit() {
		emitter.emit = false;
    }
}
