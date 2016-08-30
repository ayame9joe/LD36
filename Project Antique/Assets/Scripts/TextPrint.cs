using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour {

	float letterPause = 0f;
	private string word;
	private string printText;
	private int i, j = 0;
	private int r = 0;
	bool once;

	//---Story Line---


	string[][] Texts = new string[22][] { 
		new string[] { // start
			"You are running an antique store. There is an antique exhibition will be held seven days later.",
			"In order to attract as much attention as you can on the exhibition, you released an announcement which saying all you need would be antiques that should never exist.",
			"You have to buy seven antiques before entering the exhibition. Also you will receive a parcel from your overseas student every day, maybe that would help, too."
		},
		new string[] { // true 1
			"My grandfather found this in a mysterious cave, the mural there has shown this thing was used for hunting dinosaurs!",
			"You can have it only for 3000, I really need money for my daughter!",
		}, 
		new string[] { // false 1
			"An ancient Chinese tribe leader once chase the sun and died after a long run. This shows the reason why he can run so fast back then.",
			"2000, and take it."
		},
		new string[] { // student 1
			"We found it in a cult ruins. It make us uncomfortable…",			
			"A parcel has sent to your store, pay 2000 for delivery fee?"
		},
		new string[] { // false 7
			"Adam and Eva would love to see it end like this. Anyway, this instrument makes touching music.",
			"As my Chinese friend’s suggestion, 2000 will be the best price."
		},
		new string[] { // false 4
			"My kid said if you open this antique, many horrible things will come out of it. It must be Pandora ’s Box!",
			"I don’t want that happen, please buy it! Only 1000!"
		},
		new string[] { // student 2
			"One guy of our team has gone mad for no reason. He made this and kept murmuring weird words.",			
			"A parcel has sent to your store, pay 2000 for delivery fee?"
		},
		new string[] { // true 3
			"Could you believe that? It's an ancient fridge more than 2000 years ago. How did it works without electricity?",
			"My Chinese friend ask me to sell it, and the price is 2500!",
		},
		new string[] { // false 6
			"A monkey hide this stick in its ear, my Chinese friends said this will becomes as larger as you want if you know how to use it.",
			"1500，deal?"
		},
		new string[] { // student 3
			"It laid in a cave at Antarctica. Most of the handwriting on it was illegible scribble, like‘Teke-li-li’.",			
			"A parcel has sent to your store, pay 2000 for delivery fee?"
		},
		new string[] { // true 5
			"The truth of one of the most famous unsolved mysteries is holding in my hand now.",
			"Give me 3000, and take it.",
		},
		new string[] { // true 2
			"A fish selleer sold me this few days ago, an archaeologist said this cam from Atlantis!", 
			"What an amazing ancient technology, 2000 will be a fair price.",
		}, 
		new string[] { // student 4
			"Wow, Mr. President is a time traveler? Found in a collector’s house.",			
			"A parcel has sent to your store, pay 2000 for delivery fee?"
		},
		new string[] { // true 6
			"Archaeologists was shocked after seeing what they found in the Mayan tomb, but they will be mad about this.",
			"You are the one which mean to keep it, I only need 3000.",
		},
		new string[] {  // false 2
			"People argued about his existence for a long time until I found this!",
			"I’d like to ask for 1000."
		},
		new string[] { // student 5
			"This marmot can read books! Trust me! Even writing! But its behavior became normal after writing ‘You people are worse than flying polyps’on a bible.",			
			"A parcel has sent to your store, pay 2000 for delivery fee?"
		},
		new string[] { // true 4
			"This thing cannot move anymore, but it was made by a Chinese counsellor 2000 years ago and used to bring materials for army. I could only found wood and steel in it, nothing else.",
			"No one could fix it up so I decide to sell it. You can keep it if you pay 1000.",
		},
		new string[] { // false 3
			"Someone found this inside a stone age cave, under a bunch of ancient tool scraps. And it’s still functional!",
			"I’ll sell it for 500, just like a real smart phone."
		},
		new string[] { // student 6
			"Sam was killed by some creature in a ruin, we only found his right hand which holding this picture.",			
			"A parcel has sent to your store, pay 2000 for delivery fee?"
		},
		new string[] { // false 5
			"Thanks to the ark, we survived the flood. What a priceless treasure!",
			"But I decide to sell it to you only for 2500."
		},
		new string[] { // true 7
			"People know the story of a general that only have one eye and one arm, but they would never know this.",
			"The price will be 1500",
			//"..."
		},
		new string[] { // student 7
			"Cthulhu noster qui es in maribus: sanctificetur nomen tuum; adveniat regnum tuum; fiat voluntas tua, sicut in R'lyeh, et in Y'ha-nthlei.",			
			"A parcel has sent to your store, pay 2000 for delivery fee?"
		}



	};

	public Text txtPrint;

	bool paused;
	// Use this for initialization
	void Start () {

		r = GameController.itemNumber;
		TextChange ();

	}

	// Update is called once per frame
	void Update () {


		txtPrint.text = printText;
		OnTextConfirm ();

		if (GameController.itemNumber != r) {
			//if (!once) {
			TextChange ();
				//once = true;
			//}
			r = GameController.itemNumber;
			//}
		} else {
			
		}

	}

	void TextChange () {
	//	Debug.Log ("!!!");
		word = "";

		word = Texts[GameController.itemNumber + 1][i];
		printText = "";
		StartCoroutine (TypeText ());
	}

	IEnumerator TypeText () {
		foreach (char letter in word.ToCharArray()) {
			printText += letter;
			yield return new WaitForSeconds(letterPause);
		}

		printText += "";
		j++;
	}

	public void OnTextConfirm () {
		if (Input.GetMouseButtonDown(0))
		{                    
			//检测对话显示完没有 i = j 就是还没有显示完
			if (i == j)
			{
				letterPause = 0.0f;     //加快显的速度，让对话速度显示完
			}
			else
			{
				//检测对话语句是否超出了最大限制，超出了就DO STH.
			//	if (i < Texts[GameController.dialogueNumber].Length - 1)
				if (i < Texts[1].Length - 1)//Texts[GameController.itemNumber][1].Length - 1)
				{
					//once = false;
					letterPause = 0.05f;
					i++;
					TextChange ();
				}
				else
				{
					//DO STH.
					i = 0;
					j = 0;

					if (!GameController.dayEnd) {
						GameController.gamePhase = GameController.GamePhase.Evaluation;
					} else {
						GameController.gamePhase = GameController.GamePhase.Talk;
						//TextChange();
					}

				}

			}                                          
		}          
	}




}