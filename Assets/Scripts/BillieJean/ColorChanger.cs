using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
	public Color onColor1 = Color.yellow;
	public Color offColor = Color.black;
	public Color onColor2 = Color.green;
	public float lerpColorSpeed = 0.5f;
	
	private Color currentOnColor;
	private float lerpColorAmount = 0;
	private float lerpDirection = 1.0f;
	
	public PointCloudFadingCollider pointCloudFadingCollider;
	
	void Start () {
		renderer.material.color = offColor;
		currentOnColor = onColor1;
	}
	
	void Update() {
		
		if (pointCloudFadingCollider.Activation < 0.05f) {
		lerpColorAmount += lerpColorSpeed * Time.deltaTime * lerpDirection;
		if (lerpColorAmount > 1.0f) {
			lerpColorAmount = 1.0f;
			lerpDirection = -1.0f;
		} else if (lerpColorAmount < 0) {
			lerpColorAmount = 0;
			lerpDirection = 1.0f;
		}
		currentOnColor = Color.Lerp(onColor1, onColor2, lerpColorAmount);
		}
		
		if (pointCloudFadingCollider.Activation >= 0.75f) {
			Color newColor; 
			newColor = currentOnColor;
			newColor.a = 1.0f;
			renderer.material.color = newColor;
		} else {
			Color newColor = Color.Lerp(offColor, currentOnColor, pointCloudFadingCollider.Activation);
			newColor.a = pointCloudFadingCollider.Activation + 0.1f;
			renderer.material.color = newColor;
		}
	}
	
}
