using UnityEngine;
using System.Collections;

public class ObjectCollisionToPointCloud : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        gameObject.SendMessage("OnPointCloudCollisionEnter");
    }
    void OnTriggerExit(Collider other)
    {
        gameObject.SendMessage("OnPointCloudCollisionExit");
    }
}
