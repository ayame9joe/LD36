using UnityEngine;
using System.Collections;

public class FlawScript : MonoBehaviour {

	public Texture2D[] images = new Texture2D[GameController.totalItemNumber];
	//public List<Texture2D> images = new List<Texture2D> ();

	Sprite sprite;

	int r;
	// Use this for initialization
	void Start () {
		//this.gameObject.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.itemNumber != r) {
			//if (!once) {
			//this.transform.position = new Vector3(Random.Range(-5,3),Random.Range(-1,3),1);
			//once = true;
			//}
			r = GameController.itemNumber;
			//}
		}
	
		sprite = Sprite.Create (images [GameController.itemNumber], 
			new Rect (0, 0, images [GameController.itemNumber].width, images [GameController.itemNumber].height), Vector2.zero);
		this.GetComponent<SpriteRenderer> ().sprite = sprite;
	}
}
