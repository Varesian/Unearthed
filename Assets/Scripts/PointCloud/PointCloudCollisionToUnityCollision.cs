using UnityEngine;
using System.Collections;

public class PointCloudCollisionToUnityCollision : MonoBehaviour {
	
	private OnCollisionColorChange oCCC;
	
	void Start() {
		oCCC = gameObject.GetComponent<OnCollisionColorChange>();
		if (oCCC == null) {
			Debug.LogError("Please give this item an OnCollisionColorChange script", this);
		}
	}
	
	void OnPointCloudCollisionEnter() {
		Debug.Log("I got a collision", this);
		renderer.material.color = Color.red;
		//oCCC.Collide ();
	}
	
	void OnPointCloudCollisionExit() {
		renderer.material.color = Color.blue;
	}
}
