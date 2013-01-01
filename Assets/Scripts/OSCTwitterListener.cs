using UnityEngine;
using System.Collections;

public class OSCTwitterListener : OSCMessageListener {
	
	public ParticleEmitter emitter;
	
	bool emit = true;
	
	// Use this for initialization
	protected override void Start () {
		base.Start();
	}

	
	protected override void Destroy() {
		base.Destroy();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Backslash)) {
			emit = !emit;
		}
	}
	
	public override void OSCMessageReceiver(OscMessage message) {
		
		if (emit) {
			emitter.Emit();
		}
		
		Debug.Log("Message...");
	
	}

	
	protected override string commandOfInterest() {
		return "cc15";
	}


}
