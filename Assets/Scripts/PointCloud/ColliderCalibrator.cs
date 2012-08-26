using UnityEngine;
using System.Collections;

public class ColliderCalibrator : MonoBehaviour {

    public float transformScalar = 0.1f;

    void Start () {
    }
	
    void Update () {
	if (Input.GetKeyDown(KeyCode.Alpha8)) {
	    transform.position = new Vector3(transform.position.x,
					     transform.position.y - transformScalar, transform.position.z);
	} else if (Input.GetKeyDown(KeyCode.Alpha9)) {
	    transform.position = new Vector3(transform.position.x,
					     transform.position.y + transformScalar, transform.position.z);
	} else if (Input.GetKeyDown(KeyCode.Alpha0)) {
	    transform.position = new Vector3(transform.position.x,
					     0 - renderer.bounds.extents.y * 0.5f, transform.position.z);
	}
    }
}
