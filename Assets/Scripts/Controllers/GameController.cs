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
	private BoardService boardService;
	private Player[] players;

	void Awake () {
		if (instance != null) {
			this.enabled = false;
		} else {
			instance = this;
		}
	}

	void Start () {
		boardService = new BoardService(dirtBlock, grassBlock);
		boardService.PopulateBoard(boxer.model, enemies);
	}
		
	void Update () {
		
	}

	public static GameController GetInstance () {
		return instance;
	}

	public void RegisterBoxer (PlayerController controller) {
		boxer = controller;
	}
}
