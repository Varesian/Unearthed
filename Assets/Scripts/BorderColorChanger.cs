using UnityEngine;
using System.Collections;

public class BorderColorChanger : MonoBehaviour {
	
	public float transparencyChangeSpeed = 0.5f;
	private float transparencyDirection = 1.0f;
	private float nextAlpha = 0;
	
	// Update is called once per frame
	void Update () {
		nextAlpha += Time.deltaTime * transparencyChangeSpeed * transparencyDirection;
		if (nextAlpha > 1.0f) {
			nextAlpha = 1.0f;
			transparencyDirection = -1.0f;
		} else if (nextAlpha < 0) {
			nextAlpha = 0;
			transparencyDirection = 1.0f;
		}
		renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, nextAlpha);
	}
}
