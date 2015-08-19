using UnityEngine;
using System.Collections;

public class GameViewCameraController : MonoBehaviour {

	public Camera gameViewCamera;
	private Vector3 startPos;
	private bool isMoving;

	// Use this for initialization
	void Start ()
	{
		BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D> ();
		RectTransform rectTransform = this.gameObject.GetComponent<RectTransform> ();
		collider.size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			if (this.ObjectClicked()) {
				startPos = Input.mousePosition;
				isMoving = true;
			}
		}
		if (Input.GetMouseButton(0)) {
			if (this.ObjectClicked() && isMoving) {
				Vector3 mousePos = Input.mousePosition;
				Vector3 offset = gameViewCamera.WorldToViewportPoint(mousePos) - gameViewCamera.WorldToViewportPoint(startPos);
				gameViewCamera.transform.position = gameViewCamera.transform.position - offset;
				startPos = mousePos;
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			isMoving = false;
		}
	}

	bool ObjectClicked ()
	{
		Vector3 mousePos = Input.mousePosition;
		RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.down);
		return (hit.collider != null && hit.collider.gameObject == this.gameObject);
	}
}
