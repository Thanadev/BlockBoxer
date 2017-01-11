using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	private static InputController instance = null;
	private GameController gameC;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			this.enabled = false;
		}
	}

	void Start () {
		gameC = GameController.GetInstance();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Cell") {
				Vector2 start = gameC.boxer.Coordinates;
				Cell cell = hit.transform.GetComponent<Cell>();

				if (MovementService.isMoveValid(start, cell.Coordinates)) {
					gameC.CurrentPlayer.GainScore(cell.EnterPlayer(ref gameC.boxer));
					gameC.PlayerPlayed();
				}
			}
		}
	}

	public static InputController GetInstance () {
		return instance;
	}

	public void Desactivate () {
		this.enabled = false;
	}
}
