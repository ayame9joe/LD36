using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageScript : MonoBehaviour {

	public Texture2D[] images;


	Sprite sprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		sprite = Sprite.Create(images[GameController.itemNumber], new Rect(0, 0, images[GameController.itemNumber].width, images[GameController.itemNumber].height), Vector2.zero);
		this.GetComponent<Image> ().sprite = sprite;

		this.GetComponent<Image> ().rectTransform.sizeDelta = 20 *
			new Vector2 (sprite.bounds.max.x - sprite.bounds.min.x, sprite.bounds.max.y - sprite.bounds.min.y);
	
	}
}
