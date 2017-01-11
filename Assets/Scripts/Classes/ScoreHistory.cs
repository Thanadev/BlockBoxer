using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHistory {
	private List<PlayerMove> moves;

	public ScoreHistory ()
	{
		moves = new List<PlayerMove>();
	}
		
	public void addMove (int score) {
		moves.Add(new PlayerMove(score));
	}

	public List<PlayerMove> Moves {
		get {
			return this.moves;
		}
	}
}
