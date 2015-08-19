using UnityEngine;
using System.Collections;

public class GameViewCameraController : MonoBehaviour {

	public Camera gameViewCamera;
	private Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
		Rect viewport = new Rect (0, 0, Screen.height, Screen.width);
		gameViewCamera.rect = viewport;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			if (this.ObjectClicked()) {
				startPos = Input.mousePosition;
			}
		}
		if (Input.GetMouseButton(0)) {
			if (this.ObjectClicked()) {
				Vector3 mousePos = Input.mousePosition;
				Vector3 offset = gameViewCamera.WorldToViewportPoint(mousePos) - gameViewCamera.WorldToViewportPoint(startPos);
				gameViewCamera.transform.position = gameViewCamera.transform.position - offset;
				startPos = mousePos;
			}
		}
	}

	bool ObjectClicked ()
	{
		Vector3 mousePos = Input.mousePosition;
		RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.down);
		return (hit.collider != null && hit.collider.gameObject == this.gameObject);
	}
}
