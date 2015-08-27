using UnityEngine;
using System.Collections;

public class UIAutoLayout : MonoBehaviour {

	const int kIconSize = 100;
	const int kOffset = 2;

	public GameObject gameFieldView;
	public GameObject sidePanel;
	public GameObject bottomPanel;

	// Use this for initialization
	void Start ()
	{
		RectTransform gfSize = gameFieldView.GetComponent<RectTransform> ();
		RectTransform spSize = sidePanel.GetComponent<RectTransform> ();

		float gfHeight = Screen.height;
		float spHeight = Screen.height;

		float gfWidth = gfHeight;	// game field is likely to be square
		float spMinWidth = 2 * kIconSize + 3 * kOffset;
		float spMaxWidth = Screen.width * 0.4375f;

		float spWidth = Screen.width - gfWidth;
		if (spWidth > spMaxWidth) {
			spWidth = spMaxWidth;
			gfWidth = Screen.width - spWidth;
		}
		else if (spWidth < spMinWidth) {
			spWidth = spMinWidth;
			gfWidth = Screen.width - spWidth;
		}
		gfSize.position = new Vector2(gfSize.position.x - (gfSize.rect.width - gfWidth)/2, gfSize.position.y);
		spSize.position = new Vector2(spSize.position.x + (spSize.rect.width - spWidth)/2, spSize.position.y);

		gfSize.sizeDelta = new Vector2 (gfWidth, gfHeight);
		spSize.sizeDelta = new Vector2 (spWidth, spHeight);

		// change box collider size
		BoxCollider2D gfBox = gameFieldView.GetComponent<BoxCollider2D> ();
		gfBox.size = new Vector2 (gfWidth, gfHeight);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
