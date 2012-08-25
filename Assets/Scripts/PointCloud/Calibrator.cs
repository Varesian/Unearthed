using UnityEngine;
using System.Collections;

public class Calibrator : MonoBehaviour {

	public float transformScalar = 0.1f;
	public float rotationScalar = 1.0f;
	public float scaleScalar = 0.1f;
	//controls (one row of kydb per transform property): 
	//position: q (x+), w (x-), e(y+), ...
	//rotation: a (x+), s (x-), ...
	//scale: z (x+), x (x-), ...
			
	// Update is called once per frame
	void Update () {
		AlterTransform();
		AlterRotation();
		AlterScale();
	}

	void AlterTransform() {
		if (Input.GetKeyDown(KeyCode.Q)) {
			transform.position = new Vector3(transform.position.x + transformScalar,
				transform.position.y, transform.position.z);
		}
		if (Input.GetKeyDown(KeyCode.W)) {
			transform.position = new Vector3(transform.position.x - transformScalar,
				transform.position.y, transform.position.z);
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			transform.position = new Vector3(transform.position.x,
				transform.position.y + transformScalar, transform.position.z);
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			transform.position = new Vector3(transform.position.x,
				transform.position.y - transformScalar, transform.position.z);
		}
		if (Input.GetKeyDown(KeyCode.T)) {
			transform.position = new Vector3(transform.position.x,
				transform.position.y, transform.position.z + transformScalar);
		}
		if (Input.GetKeyDown(KeyCode.Y)) {
			transform.position = new Vector3(transform.position.x,
				transform.position.y, transform.position.z - transformScalar);
		}		
	}
	
	void AlterRotation() {
		if (Input.GetKeyDown(KeyCode.A)) {
			transform.Rotate (Vector3.right * rotationScalar);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			transform.Rotate (Vector3.right * rotationScalar * -1.0f);
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			transform.Rotate (Vector3.up * rotationScalar);
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			transform.Rotate (Vector3.up * rotationScalar * -1.0f);
		}
		if (Input.GetKeyDown(KeyCode.G)) {
			transform.Rotate (Vector3.forward * rotationScalar);
		}
		if (Input.GetKeyDown(KeyCode.H)) {
			transform.Rotate (Vector3.forward * rotationScalar * -1.0f);
		}
	}
	
	void AlterScale() {
		if (Input.GetKeyDown(KeyCode.Z)) {
			transform.localScale = new Vector3(transform.localScale.x + transformScalar,
				transform.localScale.y, transform.localScale.z);
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			transform.localScale = new Vector3(transform.localScale.x - transformScalar,
				transform.localScale.y, transform.localScale.z);
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			transform.localScale = new Vector3(transform.localScale.x,
				transform.localScale.y + transformScalar, transform.localScale.z);
		}
		if (Input.GetKeyDown(KeyCode.V)) {
			transform.localScale = new Vector3(transform.localScale.x,
				transform.localScale.y - transformScalar, transform.localScale.z);
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			transform.localScale = new Vector3(transform.localScale.x,
				transform.localScale.y, transform.localScale.z + transformScalar);
		}
		if (Input.GetKeyDown(KeyCode.N)) {
			transform.localScale = new Vector3(transform.localScale.x,
				transform.localScale.y, transform.localScale.z - transformScalar);
		}		
	}
}
