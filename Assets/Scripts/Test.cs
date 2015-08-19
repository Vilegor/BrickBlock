using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rect viewport = new Rect (0, 0, Screen.height, Screen.width);
		Camera cam = this.gameObject.GetComponent<Camera>();
		cam.rect = viewport;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
