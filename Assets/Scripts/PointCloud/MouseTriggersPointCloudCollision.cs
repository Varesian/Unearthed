using UnityEngine;
using System.Collections;

public class MouseTriggersPointCloudCollision : MonoBehaviour {
	void OnMouseEnter() {
		gameObject.SendMessage("OnPointCloudCollisionEnter");
	}
	
	void OnMouseExit() {
		gameObject.SendMessage("OnPointCloudCollisionExit");
	}
}
