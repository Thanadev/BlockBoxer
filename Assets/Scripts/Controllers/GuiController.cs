using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {

	public Text score1;
	public Text score2;
	public GameObject victory;

	private static GuiController instance = null;

	private GameController gameC;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			victory.SetActive(false);
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

	public void DisplayVictory () {
		victory.GetComponentInChildren<Text>().text = "Player " + gameC.CurrentPlayer.Name + " has won !";
		victory.SetActive(true);
	}

	public void RefreshScores () {
		score1.text = gameC.Players[0].Score + " points";
		score2.text = gameC.Players[1].Score + " points";
	}
}
