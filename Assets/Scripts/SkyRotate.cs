using UnityEngine;
using System.Collections;

public class SkyRotate : MonoBehaviour {

	private float rotation; 
	private Material skybox;

	void Start () {
		skybox = RenderSettings.skybox;
	}
	void Update () {
		rotation -= Time.deltaTime*2;
		skybox.SetFloat ("_Rotation", rotation);
	}
}
