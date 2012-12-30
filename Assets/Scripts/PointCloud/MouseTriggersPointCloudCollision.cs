using UnityEngine;
using System.Collections;

public class MouseTriggersPointCloudCollision : MonoBehaviour {

    public GameObject collisionObj;
    public Camera trackingCam;

    void Update()
    {
        Vector3 mouseWorldpt = trackingCam.ScreenToWorldPoint(Input.mousePosition);
        collisionObj.transform.position = mouseWorldpt;

        collisionObj.transform.position = new Vector3(((collisionObj.transform.position.x)), 1f, collisionObj.transform.position.z);
        //print(collisionObj.transform.position);
    }
	/*void OnMouseEnter() {
        print("mouseEnter");
		gameObject.SendMessage("OnPointCloudCollisionEnter");
	}
	
	void OnMouseExit() {
		gameObject.SendMessage("OnPointCloudCollisionExit");
	}*/
}
