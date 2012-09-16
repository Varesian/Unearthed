using UnityEngine;
using System.Collections;

public class ParticleAnimatorColors : MonoBehaviour {

	public Color[] animationColors = new Color[5];
	//if a reference is provided, the starting colors are taken from the reference
	public ParticleAnimator particleAnimatorWithStartColors;

	
	public Color[,] lerpers = new Color[3,5];
	
	void Start() {
		if (particleAnimatorWithStartColors != null) {
			animationColors = particleAnimatorWithStartColors.colorAnimation;
		}
	}
	
	public Color[] GetAnimationColors() {
		return animationColors;
	}
}
