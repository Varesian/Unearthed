using UnityEngine;
using System.Collections;

public class DebugPointCloudCollider : MonoBehaviour {
	// NOTE: Don't even try to run this until you've trimmed the point cloud down considerably (<2000 points)

	static int skip = 500;	
		
	public PointCloud pointCloud;
		
	void Start () {
		if (pointCloud == null) {
			Debug.Log("Point cloud is not assigned to collider.", this);
		}
	}
	
	void Update() {
	
		Vector3[] points = pointCloud.Points;
		int numPoints = pointCloud.NumPoints;
				
		for (int i = 0; i < numPoints; i += skip) {	
			if (collider.bounds.Contains(points[i])) {
				gameObject.SendMessage("OnPointCloudCollisionEnter");
				break;
			}
		}
	}
		
	//gameObject.SendMessage("OnPointCloudCollisionExit");
}
