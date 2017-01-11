using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementService {

	public MovementService () {
	}


	/**
	 * 	Expected pattern : only on vertical and horizontal axis, no range limit, no interruptions
	 */
	public static bool isMoveValid (Vector2 start, Vector2 end) {
		bool isValid = false;

		if (start.x == end.x || start.y == end.y) {
			isValid = true;
		}

		return isValid;
	}
}
