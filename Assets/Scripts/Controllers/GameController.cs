using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[Header("Entities")]
	public PlayerController boxer;
	public EnemyController[] enemies;

	[Header("Blocks")]
	public GameObject dirtBlock;
	public GameObject grassBlock;

	private static GameController instance = null;

	private GuiController guiC;
	private BoardService boardService;
	private Player[] players;
	private Player currentPlayer;

	void Awake () {
		if (instance != null) {
			this.enabled = false;
		} else {
			instance = this;

			// Init players
			players = new Player[2];
			players[0] = new Player("Player1");
			players[1] = new Player("Player2");
			currentPlayer = players[0];
		}
	}

	void Start () {
		boardService = new BoardService(dirtBlock, grassBlock);
		boardService.PopulateBoard(boxer.model, enemies);
		guiC = GuiController.GetInstance();
	}
		
	void Update () {
		
	}

	public static GameController GetInstance () {
		return instance;
	}

	public void RegisterBoxer (PlayerController controller) {
		boxer = controller;
	}

	/**
	 * 	Turn by turn main method
	 */
	public void PlayerPlayed () {
		guiC.RefreshScores();
		
		if (currentPlayer == players[0]) {
			currentPlayer = players[1];
		} else {
			currentPlayer = players[0];
		}
	}

	public Player CurrentPlayer {
		get {
			return this.currentPlayer;
		}
	}

	public Player[] Players {
		get {
			return this.players;
		}
	}
}
