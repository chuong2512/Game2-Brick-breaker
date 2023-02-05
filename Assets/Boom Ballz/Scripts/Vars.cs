using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour {

	public static int level = 1;
	public static int numberOfBalls = 1;
	public static int newBalls = 1;
	public static int ballHitBottom = 0;
	public static bool lastBallHitBottom = false;
	public static bool startMovingTowardsMainBall = false;
	public static int ballsReachedDistance = 0;
	public static bool firstBallHitBottomCollider = false;
	public static float firstBallHitXPos = 0;
	public static bool canContinue = true;
	public static bool newWaveOfBricks = false;
	public static float speedUpTimer = 0;

	public static void RestartAllVariables() {
		Vars.level = 1;
		Vars.numberOfBalls = 1;
		Vars.newBalls = 1;
		Vars.ballHitBottom = 0;
		Vars.lastBallHitBottom = false;
		Vars.startMovingTowardsMainBall = false;
		Vars.ballsReachedDistance = 0;
		Vars.firstBallHitBottomCollider = false;
		Vars.firstBallHitXPos = 0;
		Vars.canContinue =  true;
		Vars.newWaveOfBricks = false;
		Vars.speedUpTimer = 0;
	}
}
