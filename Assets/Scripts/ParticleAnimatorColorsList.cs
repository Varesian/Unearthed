using UnityEngine;
using System.Collections;

public class ParticleAnimatorColorsList : MonoBehaviour {
	
	public ParticleAnimatorColors[] particleAnimatorColorCycle;
	public string startLerpKey = "L";
	public float lerpSpeed = 0.05f;

	public Color[] currentColors = new Color[5]; //DEBUG public
	private int numPACS;
	private int currentPACIndex = 0;
	private bool update = false;
	private float lerpAmount = 0;
	
	// Use this for initialization
	void Start () {
		numPACS = particleAnimatorColorCycle.GetLength(0);
		currentColors = particleAnimatorColorCycle[0].GetAnimationColors();
	}
	
	// Update is called once per frame
	void Update () {
		if (update) {
			bool lerpExceeded = false;
			float newLerpAmount = lerpAmount + lerpSpeed * Time.deltaTime;
			if (newLerpAmount > 1.0f) {
				update = false;
				newLerpAmount = 1.0f;
				lerpExceeded = true;
			}
			
			lerpAmount = newLerpAmount;
			Debug.Log ("Lerp amount: " + lerpAmount, this);
			Color[] aColsFrom = particleAnimatorColorCycle[currentPACIndex].GetAnimationColors ();
			Color[] aColsTo = particleAnimatorColorCycle[currentPACIndex + 1].GetAnimationColors ();
			
			for (int i=0; i < 5; i++) {
				Color c1 = aColsFrom[i];
				Color c2 = aColsTo[i];
				//Color c1 = particleAnimatorColorCycle[currentPACIndex].GetAnimationColors();
				//Color c2 = particleAnimatorColorCycle[currentPACIndex + 1].GetAnimationColors()[i];
				currentColors[i] = Color.Lerp(c1, c2, lerpAmount);
				//currentColors[0] = Color.red; //DEBUG
			}
			
			if (lerpExceeded) {
				lerpAmount = 0;
				currentPACIndex++;
			}
		}	
	}
	
	void OnGUI() {
		if (Event.current.Equals(Event.KeyboardEvent(startLerpKey))) {
			if (currentPACIndex > numPACS - 2) {
				Debug.LogWarning("No more ParticleAnimatorColors to lerp to", this);
			} else {
				update = !update;
			}
		}
	}
	
	public Color[] GetAnimationColors() {
		return currentColors;
	}
}
