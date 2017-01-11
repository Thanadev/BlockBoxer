using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardService {

	private Cell[,] cells;
	private GameObject board;
	private GameObject grassBlock;
	private GameObject dirtBlock;

	public BoardService (GameObject dirtBlock, GameObject grassBlock) {
		this.dirtBlock = dirtBlock;
		this.grassBlock = grassBlock;
		cells = new Cell[7, 7];

		GenerateBoard();

		board = GameObject.FindGameObjectWithTag("Board");
	}

	public void GenerateBoard () {
		int xAxis = 0;
		int zAxis = 0;
		int x = 0;
		int y = 0;
		Vector3 position;
		GameObject instance;

		for (zAxis = -7; zAxis <= 5; zAxis++) {
			y = 0;
			for (xAxis = -6; xAxis <= 6; xAxis++) {
				position = new Vector3(xAxis, 0, zAxis);

				if (zAxis % 2 != 0 && xAxis % 2 == 0) {
					instance = GameObject.Instantiate(grassBlock, position, Quaternion.identity) as GameObject;
					cells[x, y] = instance.GetComponent<Cell>();
					cells[x, y].Coordinates = new Vector2(x, y);

					y++;
				} else {
					GameObject.Instantiate(dirtBlock, position, Quaternion.identity);
				}
			}

			if (zAxis % 2 != 0) {
				x++;
			}
		}
	}

	public void PopulateBoard (Boxer player, EnemyController[] enemies) {
		Placeable toSpawn;

		for (int x = 1; x <= 7; x++) {
			for (int y = 1; y <= 7; y++) {
				if (x == 4 && y == 4) {
					toSpawn = player;
				} else {
					toSpawn = enemies[Random.Range(0, enemies.Length)].model;
				}

				if (!cells[x-1, y-1].SpawnPlaceable(toSpawn)) {
					Debug.LogError("PopulateTab : A cell can only have one spawned objet at the time. SpawnPLaceable Cell's method returned false.");
				} else if (x == 4 && y == 4) {
					
					cells[x-1, y-1].OccupantAvatar.GetComponent<PlayerController>().Coordinates = new Vector2(x, y);
				}
			}
		}
	}
}
