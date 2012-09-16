using UnityEngine;
using System.Collections;

public class SetToExternalParticleAnimationColors : MonoBehaviour {
	
	public ParticleAnimatorColors particleAnimatorColors;
	public ParticleAnimator particleAnimatorToChange;
	public float minMillisecsBetweenUpdates = 0;
	private float msUntilUpdate;
	
	// Use this for initialization
	void Start () {
		msUntilUpdate = minMillisecsBetweenUpdates;
	}
	
	// Update is called once per frame
	void Update () {
		msUntilUpdate -= Time.deltaTime;
		if (msUntilUpdate < 0) {
			particleAnimatorToChange.colorAnimation = particleAnimatorColors.GetAnimationColors();
			msUntilUpdate = minMillisecsBetweenUpdates;
		}
	}
}
