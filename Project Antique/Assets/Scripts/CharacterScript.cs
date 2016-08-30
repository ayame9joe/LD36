using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour {

	public Texture2D[] images;

	Sprite sprite;
	int random;
	bool once;
	// Use this for initialization
	void Start () {
		


	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (random);
		if (GameController.gamePhase == GameController.GamePhase.Talk) {
			if (!once) {
				random = Random.Range (0, images.Length - 1);
				once = true;
			}
		} else {
			if (once) {
				random = Random.Range (0, images.Length - 1);
				once = false;
			}
		}
		sprite = Sprite.Create (images [GameController.random], new Rect (0, 0, images [GameController.random].width, images [GameController.random].height), Vector2.zero);
		this.GetComponent<Image> ().sprite = sprite;
		this.GetComponent<Image> ().rectTransform.sizeDelta = 100 *
		new Vector2 (sprite.bounds.max.x - sprite.bounds.min.x, sprite.bounds.max.y - sprite.bounds.min.y);
	}
}
