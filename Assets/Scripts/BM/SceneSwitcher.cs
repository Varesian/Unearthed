using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {
    public float intervalSeconds = 60.0f;
    public SceneState sceneState = 0;
    public Transform water;
    public enum SceneState {
		BillieJean = 0,
		FireFloors,
		WaterFloors,
		BlobFloors
    }

    float lastSwitchSeconds = 0;

    void Start() {
		lastSwitchSeconds = Time.timeSinceLevelLoad;
		SetScene(sceneState);
    }

    void Update () {
	if (Time.timeSinceLevelLoad - lastSwitchSeconds > intervalSeconds) {
	    lastSwitchSeconds = Time.timeSinceLevelLoad;
	    sceneState++;
	    if (sceneState > SceneState.BlobFloors) {
		sceneState = SceneState.FireFloors;
	    }
	    SetScene(sceneState);
	}
    }

    void SetScene(SceneState state) {
		if (state == SceneState.BillieJean) {
		    ActivateBillieJean(true);
		    ActivateFireFloors(false);
		    ActivateWaterFloors(false);	 
			ActivateBlobFloors(false);
		} else if (state == SceneState.FireFloors) {
		    ActivateBillieJean(false);
		    ActivateFireFloors(true);
		    ActivateWaterFloors(false);	    
			ActivateBlobFloors(false);
		} else if (state == SceneState.WaterFloors) {
		    ActivateBillieJean(true);
		    ActivateFireFloors(false);
		    ActivateWaterFloors(true);	    
			ActivateBlobFloors(false);
		} else if (state == SceneState.BlobFloors) {
			ActivateBillieJean(false);
			ActivateFireFloors(false);
			ActivateWaterFloors(false);
			ActivateBlobFloors(true);
		}
    }

    void ActivateBillieJean(bool turnOn) {
		foreach (Transform t in transform) {
		    t.renderer.enabled = turnOn;
		}
    }

    void ActivateFireFloors(bool turnOn) {
		foreach (Transform t in transform) {
		    FireProducer fp = t.GetComponent<FireProducer>() as FireProducer;
		    if (turnOn) {
				fp.StartFire();
		    } else {
				fp.StopFire();
		    }
		}
    }

    void ActivateWaterFloors(bool turnOn) {
		water.renderer.enabled = turnOn;
    }
	
	void ActivateBlobFloors(bool turnOn) {
		foreach (Transform t in transform) {
		    BlobProducer bp = t.GetComponent<BlobProducer>() as BlobProducer;
		    if (turnOn) {
				bp.StartBlob();
		    } else {
				bp.StopBlob();
		    }
		}
    }
}
