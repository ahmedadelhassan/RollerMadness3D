using UnityEngine;
using System.Collections;

public class PulsingColor : MonoBehaviour {
	// Interpolate light color between two colors back and forth
	float duration = 0.5f;
	public Color color0;
	public Color color1;
	public GameObject Target;


	// Update is called once per frame
	void Update () {
		// set light color
		float t = Mathf.PingPong (Time.time, duration) / duration;
		Target.GetComponent<Renderer>().material.color = Color.Lerp (color0, color1, t);
	}
}
