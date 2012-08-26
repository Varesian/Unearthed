using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {
    public GameObject camera1;
    public GameObject camera2;    

    void Start () {
	
    }
	
    void Update () {
	if (Input.GetKeyDown(KeyCode.Alpha1)) {
	    camera1.camera.enabled = true;
	    camera2.camera.enabled = false;
	} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
	    camera1.camera.enabled = false;
	    camera2.camera.enabled = true;
	}
    }
}
