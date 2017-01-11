using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	private GameController gameC;

	// Use this for initialization
	void Start () {
		gameC = GameController.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Cell") {
				Vector2 start = gameC.boxer.Coordinates;
				Cell cell = hit.transform.GetComponent<Cell>();

				if (MovementService.isMoveValid(start, cell.Coordinates)) {
					cell.EnterPlayer(ref gameC.boxer);
				}
			}
		}
	}
}
