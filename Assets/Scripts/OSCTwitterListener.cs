using UnityEngine;
using System.Collections;

public class OSCTwitterListener : OSCMessageListener {
	
	public GameObject targetObject;
	int currColor = 0;
	
	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
		// Update is called once per frame
	void Update () {
		

	}
	
	protected override void Destroy() {
		base.Destroy();
	}
	
	
	public override void OSCMessageReceiver(OscMessage message) {
		
		
		switch (currColor) {
		case 0:
			targetObject.renderer.material.color = Color.blue;
			break;
		case 1:
			targetObject.renderer.material.color = Color.red;
			break;
		case 2:
			targetObject.renderer.material.color = Color.green;
			break;
		default:
			targetObject.renderer.material.color = Color.blue;
			break;
		}
		 
		if (currColor == 2) {
			currColor = 0;
		} else {
			currColor++;
		}
		
		Debug.Log("Message...");
	
	}

	
	protected override string commandOfInterest() {
		return "cc15";
	}


}
