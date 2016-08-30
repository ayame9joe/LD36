using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemScript : MonoBehaviour {

	public Texture2D[] images = new Texture2D[GameController.totalItemNumber];
	//public List<Texture2D> images = new List<Texture2D> ();

	Sprite sprite;

	//public Text TextDescription;

	public int number;

	int itemNumber;

	//int money;


	public bool createdByProgram;
	// Use this for initialization
	void Start () {


		//this.GetComponent<Image> ().rectTransform.sizeDelta = 100 *
		//	new Vector2 (sprite.bounds.max.x - sprite.bounds.min.x, sprite.bounds.max.y - sprite.bounds.min.y);
	}

	// Update is called once per frame
	void Update () {
		
		
		if (!createdByProgram) {
			sprite = Sprite.Create (images [GameController.itemNumber], 
				new Rect (0, 0, images [GameController.itemNumber].width, images [GameController.itemNumber].height), Vector2.zero);
			this.GetComponent<SpriteRenderer> ().sprite = sprite;
		}
	}

	void OnMouseOver() {
		//TextDescription.text = itemDescription [number];
		
	}
}