using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static int days = 1;
	int character;

	float money = 10000;
	int item;
	int trueItem;


	public Image ImageCharacter;
	public Text TextDialogue;
	public GameObject ImageItem;
	public Button ButtonEvaluation;
	public GameObject PanelBuyOrNot;
	public Text TextDay;
	public Text TextMoney;
	public Text TextItem;
	public Button ButtonGoToEvent;
	public Text TextDescription;
	public GameObject SpriteBackgroundEvening;
	public GameObject SpriteBackgroundDay;
	public GameObject SpriteBackgroundNight;
	public GameObject PanelConfirm;
	public Text TextConfirm;
	public GameObject PanelEvent;
	public Text TextEvent;
	public Button ButtonRetry;

	public enum GamePhase {
		Talk,
		GetPresent,
		Evaluation,
		Check,
		Event,
		Begin,
		Ending

	}

	public static GamePhase gamePhase;
	public static int dialogueNumber;
	public static int maxDialogueNumber = 28;
	public static bool dayEnd;
	public static int itemNumber;
	public static int totalItemNumber = 21;
	public static int random;


	bool[] hasGot = new bool[totalItemNumber];

	bool[] itemTrue = {
		true,
		false,
		true,
		false,
		false,
		false,
		true,
		false,
		false,
		true,
		true,
		true,
		true,
		false,
		false,
		true,
		false,
		false,
		false,
		true,
		true
	};

	string[] itemDescription = {
		"111111",
	};

	int[] itemPrice = {
		3000,
		2000,
		2500,
		1000,
		3000,
		3000,
		1500,
		2000,
		1000,
		500,
		1000,
		2500,
		1500,
		2000,
		2000,
		2000,
		2000,
		2000,
		2000,
		2000,
		2000
	};
		
	//int once = 0;

	bool checkItemNumber;
	bool checkDays;


	int eventNumber; //= -1;
	int tempItemNumber;

	int studentItemNumber;
	List<int> storedItemNumber = new List<int> ();
	// Use this for initialization
	void Start () {
		gamePhase = GamePhase.Talk;
		ButtonRetry.gameObject.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (eventNumber);
		//Debug.Log (checkItemNumber);

		if (money < 0) {
			gamePhase = GamePhase.Ending;
		}

		TextDay.text = "Days:" + days.ToString ();
		TextMoney.text = "Money:" + money.ToString ();
		TextItem.text = "Item:" + trueItem.ToString ();

		switch (gamePhase) {
		case GamePhase.Talk:
			checkDays = false;
			dayEnd = false;

			/*if (once == 0) {
				//itemNumber++;

				if (days > 1) {
					//itemNumber++;

				}
				once = 1;
			}*/

			if (eventNumber == 5) {
				random = 6;
				SpriteBackgroundEvening.SetActive (true);
				SpriteBackgroundDay.SetActive (false);
				SpriteBackgroundNight.SetActive (false);
			} else {
				SpriteBackgroundEvening.SetActive (false);
				SpriteBackgroundDay.SetActive (true);
				SpriteBackgroundNight.SetActive (false);
			}

			if (!checkItemNumber) {
				random = Random.Range (0, 6);
				//itemNumber = Random.Range (0, ImageItem.GetComponent<ItemScript>().images.Capacity - 1);
				//tempItemNumber = itemNumber;


				//storedItemNumber.Add (tempItemNumber);



				if (eventNumber > 0) {
					/*for (int i = 0; i < storedItemNumber.Capacity; i++) {
						if (itemNumber == storedItemNumber [i]) {
							itemNumber = Random.Range (0, ImageItem.GetComponent<ItemScript>().images.Capacity - 1);
						}	
					}*/
					itemNumber++;
					dialogueNumber++;
				}
				if (eventNumber == 1) {
					eventNumber = 1;
				} else {
					eventNumber++;
				}checkItemNumber = true;
			}

			ImageCharacter.gameObject.SetActive (true);
			TextDialogue.gameObject.SetActive (true);
			ImageItem.gameObject.SetActive (false);
			ButtonEvaluation.gameObject.SetActive (false);
			ButtonGoToEvent.gameObject.SetActive (false);
			PanelEvent.gameObject.SetActive (false);

			this.GetComponent<TextPrint> ().enabled = true;
			this.GetComponent<MagnifyGlass> ().enabled = false;
			//this.GetComponent<MagnifyGlass> ().
			if (GameObject.Find ("New Game Object")) {
				GameObject.Find ("New Game Object").gameObject.SetActive (false);
			}

			break;
		case GamePhase.GetPresent:

			if (!checkItemNumber) {
				//if (days > 1) {
				//itemNumber++;
				checkItemNumber = true;
				eventNumber++;
				//}
			}

			ImageCharacter.GetComponent<Image> ().sprite =
				Sprite.Create(ImageCharacter.GetComponent<CharacterScript> ().images [10],
					new Rect(0, 0, ImageCharacter.GetComponent<CharacterScript> ().images [10].width,
						ImageCharacter.GetComponent<CharacterScript> ().images [10].height), Vector2.zero);

			ImageCharacter.gameObject.SetActive (true);
			TextDialogue.gameObject.SetActive (true);
			ImageItem.gameObject.SetActive (false);
			ButtonEvaluation.gameObject.SetActive (false);
			ButtonGoToEvent.gameObject.SetActive (false);

			this.GetComponent<TextPrint> ().enabled = true;
			this.GetComponent<MagnifyGlass> ().enabled = false;

			break;

		case GamePhase.Evaluation:

			if (checkItemNumber) {
				eventNumber++;
				//ImageItem.GetComponent<ItemScript>().images.RemoveAt(tempItemNumber - 1);
				checkItemNumber = false;
			}
			ImageCharacter.gameObject.SetActive (false);
			TextDialogue.gameObject.SetActive (false);
			ImageItem.gameObject.SetActive (true);
			ButtonEvaluation.gameObject.SetActive (true);
			ButtonGoToEvent.gameObject.SetActive (false);
			PanelEvent.gameObject.SetActive (false);

			this.GetComponent<TextPrint> ().enabled = false;
			this.GetComponent<MagnifyGlass> ().enabled = true;
			if (GameObject.Find ("New Game Object")) {
				GameObject.Find ("New Game Object").gameObject.SetActive (true);
			}

			break;
		case GamePhase.Check:

			SpriteBackgroundEvening.SetActive (false);
			SpriteBackgroundDay.SetActive (false);
			SpriteBackgroundNight.SetActive (true);

			ImageCharacter.gameObject.SetActive (false);
			TextDialogue.gameObject.SetActive (false);
			ImageItem.gameObject.SetActive (false);
			ButtonEvaluation.gameObject.SetActive (false);
			ButtonGoToEvent.gameObject.SetActive (true);
			PanelEvent.gameObject.SetActive (false);

			this.GetComponent<TextPrint> ().enabled = false;
			this.GetComponent<MagnifyGlass> ().enabled = false;
			if (GameObject.Find ("New Game Object")) {
				GameObject.Find ("New Game Object").gameObject.SetActive (false);
			}

			//break;
			//TextEvent.text

			break;
		case GamePhase.Ending:
			ButtonRetry.gameObject.SetActive (true);
			SpriteBackgroundEvening.SetActive (false);
			SpriteBackgroundDay.SetActive (false);
			SpriteBackgroundNight.SetActive (true);

			ImageCharacter.gameObject.SetActive (true);
			TextDialogue.gameObject.SetActive (false);
			ImageItem.gameObject.SetActive (false);
			ButtonEvaluation.gameObject.SetActive (false);
			ButtonGoToEvent.gameObject.SetActive (false);
			PanelEvent.gameObject.SetActive (true);

			this.GetComponent<TextPrint> ().enabled = false;
			this.GetComponent<MagnifyGlass> ().enabled = false;
			if (GameObject.Find ("New Game Object")) {
				GameObject.Find ("New Game Object").gameObject.SetActive (false);
			}



			if (trueItem < 7) {
				TextEvent.text = "You don’t want to enter the exhibition with those lame antiques. You stay in the store and wait for the next chance.";
			} else if (trueItem == 7 || trueItem > 7){
				TextEvent.text = "People were surprised by your unimaginable collections on the exhibition. Many of them asked how your get those stuff, but even you didn’t know how to explain. It may be decreed by fate. Who knows?";
			}
			if (money < 0) {
				TextEvent.text = "Price cannot measure the value of antiques, but money could maintain your store. You couldn’t even afford the ticket of Exhibition. Shame.";
			}
			if (studentItemNumber == 6) {
				TextEvent.text = "People send you to a asylum after exhibition because of your babbling and deviant behavior. Nobody would trust what you said since they don’t know the unspeakable truth of the world.";
			}
			if (hasGot [1]) { // Chinese
				TextEvent.text = "You chose not to enter the exhibition. Few days later, a Chinese came to your store and want to buy those Chinese antiques with huge price. However, you became rich after all. ";
			}

			break;
		case GamePhase.Event:
			dayEnd = true;

			SpriteBackgroundEvening.SetActive (false);
			SpriteBackgroundDay.SetActive (false);
			SpriteBackgroundNight.SetActive (true);

			if (!checkDays) {
				days++;
				dialogueNumber++;
				checkDays = true;
			}

			ImageCharacter.gameObject.SetActive (true);
			TextDialogue.gameObject.SetActive (false);
			ImageItem.gameObject.SetActive (false);
			ButtonEvaluation.gameObject.SetActive (false);
			ButtonGoToEvent.gameObject.SetActive (false);
			PanelEvent.gameObject.SetActive (true);

			this.GetComponent<TextPrint> ().enabled = false;
			this.GetComponent<MagnifyGlass> ().enabled = false;
			if (GameObject.Find ("New Game Object")) {
				GameObject.Find ("New Game Object").gameObject.SetActive (false);
			}


			if (hasGot [3]) {
				studentItemNumber = 1;
			}
			if (hasGot [7] && hasGot [3]) {
				studentItemNumber = 2;
			}
			if (hasGot [11] && hasGot [7] && hasGot [3]) {
				studentItemNumber = 3;
			}
			if (hasGot [14] && hasGot [11] && hasGot [7] && hasGot [3]) {
				studentItemNumber = 4;
			}
			if (hasGot [14] && hasGot [11] && hasGot [7] && hasGot [3] && hasGot [17]) {
				studentItemNumber = 5;
			}
			if (hasGot [14] && hasGot [11] && hasGot [7] && hasGot [3] && hasGot [17] && hasGot [20]) {
				studentItemNumber = 6;
			}
			/*for (int i = 0; i < 20; i + 3){
				if (hasGot[i]){
					
				}
			}*/

			switch (studentItemNumber) {
			default:
				TextEvent.text = "Another peaceful night has passed. It’s time to find some new stuff!";
				break;
			case 2:
				TextEvent.text = "You found yourself lost in a immense city with creepy mutter in the dream. What a nightmare!";
				break;
			case 4:
				TextEvent.text = "YA strange man visited your store in the midnight, you decide not to open the door. He stood outside the window until dawn.";
				break;
			case 6:
				TextEvent.text = "You can’t fell asleep, a horrible voice was repeating in your head. Ia! Ia! Cthulhu Fhtagn!";
				break;
			}

			break;
		}
	
	}

	public void OnEvaluation() {
		PanelBuyOrNot.SetActive (true);
		this.GetComponent<MagnifyGlass> ().enabled = false;
		if (GameObject.Find ("New Game Object")) {
			GameObject.Find ("New Game Object").gameObject.SetActive (false);
		}

	}

	public void OnBuy() {
		PanelBuyOrNot.SetActive (false);
		PanelConfirm.SetActive (true);
		hasGot [itemNumber] = true;
		item++;
		if (itemTrue[itemNumber]){
			trueItem++;
		}
		money = money - itemPrice [itemNumber];

		//itemNumber++;
		switch(itemNumber){
		case 0:
			TextConfirm.text = "Thank you. I’m still wandering who used this million years ago?"; // true 1
			break;
		case 1:
			TextConfirm.text = "Now you can even run faster than a western journalist."; // false 1
			break;
		case 2:
			TextConfirm.text = "";
			break;
		case 3:
			TextConfirm.text = "You should learn to play it!"; // // false 7
			break;
		case 4:
			TextConfirm.text = "Thank you soooooo much!"; // false 4
			break;
		case 5:
			TextConfirm.text = "";
			break;
		case 6:
			TextConfirm.text = "Yeah, time to go back home and grab some beer… in a modern fridge!"; // true 3
			break;
		case 7:
			TextConfirm.text = "Call me if you make it larger."; // false 6
			break;
		case 8:
			TextConfirm.text = "";
			break;
		case 9:
			TextConfirm.text = "Brilliant choice."; // true 5
			break;
		case 10:
			TextConfirm.text = "Aha! You can clean it and see if it’s still functional!"; // true 2
			break;
		case 11:
			TextConfirm.text = "";
			break;
		case 12:
			TextConfirm.text = "I’ll see your face on the newspaper."; // true 6
			break;
		case 13:
			TextConfirm.text = "I’ll become a millionaire if I find the film."; // false 2
			break;
		case 14:
			TextConfirm.text = "";
			break;
		case 15:
			TextConfirm.text = "Deal. You could try fixing and make it move again!"; // true 4
			break;
		case 16:
			TextConfirm.text = "Ancients also like this stuff?"; // false 3
			break;
		case 17:
			TextConfirm.text = "";
			break;
		case 18:
			TextConfirm.text = "Maybe you could save us all when next flood comes."; // false 5
			break;
		case 19:
			TextConfirm.text = "Seems like inhabitants of South America gave him this, even better than a real arm."; // true 7
			break;
		case 20:
			TextConfirm.text = "";
			break;

		}




	}

	public void OnNotBuy() {
		PanelBuyOrNot.SetActive (false);
		PanelConfirm.SetActive (true);

		hasGot [itemNumber] = false;
		switch(itemNumber){
		case 0:
			TextConfirm.text = "Please, my daughter is dying…"; // true 1
			break;
		case 1:
			TextConfirm.text = "You are so naïve!"; // false 1
			break;
		case 2:
			TextConfirm.text = "";
			break;
		case 3:
			TextConfirm.text = "Oh no, time to listen Erquan Yingyue"; // false 7
			break;
		case 4:
			TextConfirm.text = "Please, save the world! "; // false 4
			break;
		case 5:
			TextConfirm.text = "";
			break;
		case 6:
			TextConfirm.text = "Come on, it’s too heavy to bring it home."; // true 3
			break;
		case 7:
			TextConfirm.text = "Meh, you’ve missed a good one."; // false 6
			break;
		case 8:
			TextConfirm.text = "";
			break;
		case 9:
			TextConfirm.text = "Fine, someone else would love it."; // true 5
			break;
		case 10:
			TextConfirm.text = "Okay, maybe that fish seller lied to me."; // true 2
			break;
		case 11:
			TextConfirm.text = "";
			break;
		case 12:
			TextConfirm.text = "It’s your loss, not mine."; // true 6
			break;
		case 13:
			TextConfirm.text = "You are clever, man."; // false 2
			break;
		case 14:
			TextConfirm.text = "";
			break;
		case 15:
			TextConfirm.text = "Well then, a garbage will become its new home."; // true 4
			break;
		case 16:
			TextConfirm.text = "Are you out of your mind? It’s so cheap!"; // false 3
			break;
		case 17:
			TextConfirm.text = "";
			break;
		case 18:
			TextConfirm.text = "I’ll not let you on board when next flood comes!"; // false 5
			break;
		case 19:
			TextConfirm.text = "Heh, find me again if you lose your arm someday."; // true 7
			break;
		case 20:
			TextConfirm.text = "";
			break;
		}
	}

	public void OnGoToEvent() {
		gamePhase = GamePhase.Event;
		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("OwnedItem").Length; i++) {
			Destroy (GameObject.FindGameObjectsWithTag ("OwnedItem") [i]);
		}
	}

	public void OnConfirm() {
		//
		//ImageItem.GetComponent<ItemScript>().images.RemoveAt(tempItemNumber - 1);
		PanelConfirm.SetActive (false);
		if (eventNumber == 2 || eventNumber == 4) {
			gamePhase = GamePhase.Talk;
		} else if (eventNumber == 6) {
			eventNumber = 1;
			gamePhase = GamePhase.Check;
			for (int i = 0; i < totalItemNumber; i++){
				if (hasGot[i] == true){
					GameObject go = GameObject.Instantiate (ImageItem.gameObject, new Vector3 (-6 + 1.5f * i, -0.5f, 0), Quaternion.identity) as GameObject;
					go.transform.localScale = new Vector3(0.3f, 0.3f, 1);
					Sprite sprite = Sprite.Create (go.GetComponent<ItemScript>().images[i], 
						new Rect (0, 0, go.GetComponent<ItemScript>().images[i].width, go.GetComponent<ItemScript>().images[i].height), Vector2.zero);
					go.GetComponent<SpriteRenderer> ().sprite = sprite;
					go.tag = "OwnedItem";
					//go.GetComponent<ItemScript> ().number = i;
					//				TextDescription.text = itemDescription [i];
					go.GetComponent<ItemScript> ().createdByProgram = true;

				}
			}
		}
		
	}

	public void OnEvent(){
		gamePhase = GamePhase.Talk;

		if (gamePhase == GamePhase.Ending) {
			gamePhase = GamePhase.Talk;
			//PanelEvent.gameObject.SetActive ();
		} else {
			if (days > 7) {
				//days = 7;
				gamePhase = GamePhase.Ending;
			}
		}
	}

	public void OnRetry(){
		Application.Quit ();
	}
}
