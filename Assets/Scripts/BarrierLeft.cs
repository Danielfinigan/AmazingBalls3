using UnityEngine;
using System.Collections;

public class BarrierLeft: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * 1.25f);
	}
}
