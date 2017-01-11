using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo {
	protected int nbMoves;
	protected int enemyValue;

	public Combo (int enemyValue)
	{
		this.enemyValue = enemyValue;
		this.nbMoves = 1;
	}

	public int addOneMove () {
		int bonus = 0;
		nbMoves++;

		if (nbMoves == 5) {
			nbMoves = 0;
			bonus = enemyValue * 2;
		}

		return bonus;
	}

	public int EnemyValue {
		get {
			return this.enemyValue;
		}
	}
}
