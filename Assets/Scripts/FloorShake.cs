using UnityEngine;
using System.Collections;

public class FloorShake : MonoBehaviour {

	public float Xrotation = 0;
	public float Zrotation = 0;

	public float Xmovement = 0;
	public float Zmovement = 0;

	public float ShakeSpeed = 1;

//	private GameObject Floor;
	private float XrotationMin = 0;
	private float ZrotationMin = 0;
	
	private float XmovementMin = 0;
	private float ZmovementMin = 0;

	private float XrotationMax = 0;
	private float ZrotationMax = 0;
	
	private float XmovementMax = 0;
	private float ZmovementMax = 0;

	private float Yrotation;
	private float Ymovement;

	// Use this for initialization
	void Start () {
//		Floor = GameObject.Find ("Floor");
		XrotationMin = transform.rotation.x - Xrotation;
		XrotationMax = transform.rotation.x + Xrotation;

		ZrotationMin = transform.rotation.z - Zrotation;
		ZrotationMax = transform.rotation.z + Zrotation;

		XmovementMin = transform.rotation.x - Xmovement;
		XmovementMax = transform.rotation.x + Xmovement;

		ZmovementMin = transform.rotation.z - Zmovement;
		ZmovementMax = transform.rotation.z + Zmovement;

		Yrotation = transform.rotation.y;
		Ymovement = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		float t = Mathf.PingPong (Time.time, (1/ShakeSpeed)) / (1/ShakeSpeed);


		transform.position = Vector3.Lerp(new Vector3(XmovementMin, Ymovement, ZmovementMin),
		                                  new Vector3(XmovementMax, Ymovement, ZmovementMax),
		                                  t);

		transform.rotation = Quaternion.Lerp(Quaternion.Euler(XrotationMin, Yrotation, ZrotationMin),
		                                     Quaternion.Euler(XrotationMax, Yrotation, ZrotationMax),
		                                  t);
	
	}
}
