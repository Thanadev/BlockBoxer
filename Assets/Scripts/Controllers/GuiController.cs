using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {

	public Text score1;
	public Text score2;

	public GameObject victory;
	public Text victoryText;
	public Text newHighscoreText;

	public Text highscoreText;

	private static GuiController instance = null;

	private GameController gameC;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			victory.SetActive(false);
			newHighscoreText.gameObject.SetActive(false);
		} else {
			this.enabled = false;
		}
	}

	void Start () {
		gameC = GameController.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static GuiController GetInstance () {
		return instance;
	}

	public void DisplayHighscore (int highscore) {
		highscoreText.text = highscore + " déplacements";
	}

	public void DisplayVictory () {
		victory.GetComponentInChildren<Text>().text = "Le joueur " + gameC.CurrentPlayer.Name + " a gagné !";
		victory.SetActive(true);
	}

	public void DisplayNewHighscore (int newHighscore) {
		newHighscoreText.text = "L'ancien meilleur score a été battu !\nNouveau Highscore : " + newHighscore + " déplacement(s)";
		newHighscoreText.gameObject.SetActive(true);
	}

	public void RefreshScores () {
		score1.text = gameC.Players[0].Score + " points";
		score2.text = gameC.Players[1].Score + " points";
	}
}
