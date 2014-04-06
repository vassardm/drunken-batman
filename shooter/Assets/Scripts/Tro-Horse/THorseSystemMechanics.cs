using UnityEngine;
using System;
using System.Collections.Generic;

public class THorseSystemMechanics : MonoBehaviour {

	// Depends on the superclass "GameMechanics"
	public GameBehavior gameScript;
	public PlayerInteraction deathFlag;

	// TODO: Relies on the superclass "Enemy"

	// Construct values only access by this class.
	private int fragmentCounter;
	private int fragmentMin = -350;
	private int fragmentMax = 350;
	private WarningLevel currentWarningLevel;
	private Dictionary<string, WarningLevel> securitySystem;

	// Use this for initialization
	void Start () {
		launchSystemDefaultsOnRuntime ();
	}
	
	// Update is called once per frame
	void Update () {
		updateFragmentCounterFunctionality ();
		updateSecurityLevelSystemChange ();
		print (currentWarningLevel.getColor() + "   " + fragmentCounter);
	}

	// Return the values provided from the GameBehavior
	public GameBehavior getGlobals(){
		return gameScript;
	}

	// Load the defaults for the game.
	public void launchSystemDefaultsOnRuntime() {
		// Create the default counter which is 0.
		// Set the default value to "Green"
		fragmentCounter = 0;
		Dictionary<string, WarningLevel> loadWarningLevels = launchWarningLevelDictionary ();
		currentWarningLevel = loadWarningLevels ["green"]; // Default level is green.
		securitySystem = loadWarningLevels; // Load the security system.
	}

	// Create and load the warning levels.
	// TODO: Add the effect modifiers once the enemy class gets constructed.
	public Dictionary<string, WarningLevel> launchWarningLevelDictionary() {
		Dictionary<string, WarningLevel> securityLevels = new Dictionary<string, WarningLevel> ();
		WarningLevel red = new WarningLevel("red", 0, 4.0f);
		WarningLevel orange = new WarningLevel ("orange", 0, 3.0f);
		WarningLevel yellow = new WarningLevel ("yellow", 0, 2.0f);
		WarningLevel green = new WarningLevel ("green", 0, 1.0f);
		WarningLevel blue = new WarningLevel ("blue", 0, 0.5f);
		WarningLevel purple = new WarningLevel ("purple", 0, 0.25f);
		WarningLevel white = new WarningLevel ("white", 0, 0.001f);
		securityLevels.Add ("red", red);
		securityLevels.Add ("orange", orange);
		securityLevels.Add ("yellow", yellow);
		securityLevels.Add ("green", green);
		securityLevels.Add ("blue", blue);
		securityLevels.Add ("purple", purple);
		securityLevels.Add ("white", white);
		return securityLevels;
	}

	// Now let's update the score counter appriopriately.
	public void updateFragmentCounterFunctionality() {
		// If the player dies, you will lose 85 points.
		if (deathFlag.deathTrigger) {
			handlePointLossReduction ();
		}
		else {
			increasePointScore();
		}
	}

	// Handle the mechanics if a player dies against the system.
	public void handlePointLossReduction() {
		int deathPenality = 85;
		fragmentCounter -= deathPenality;

		// In case that the player sucks too much and falls below the floor.
		if (fragmentCounter < fragmentMin) {
			fragmentCounter = fragmentMin;
		}
	}

	// Handle the mechanics if a player does well against the system.
	public void increasePointScore() {
		// This counter increases in two ways.
		// 1) You will earn 3 points if you defeat an enemy
		// TODO: Implement this mechanic when the Enemy Class gets refactored so it can capture the point increase

		// 2) You will earn 1 point for each graze you perform.
		int defaultGrazeCounter = 0;
		if (gameScript.grazeCounter != defaultGrazeCounter) {
			fragmentCounter++;
		}

		// In case that the player is doing too well....
		if (fragmentCounter > fragmentMax) {
			fragmentCounter = fragmentMax;
		}

	}

	// Handle the system changing based on the counter
	public void updateSecurityLevelSystemChange () {
		int redLevelBenchmark = 325;
		int orangeLevelBenchmark = 255;
		int yellowLevelBenchmark = 125;
		int greenLevelBenchmark = 0;
		int blueLevelBenchmark = -125;
		int purpleLevelBenchmark = -255;
		int whiteLevelBenchmark = -325;

		if (fragmentCounter >= redLevelBenchmark){
			currentWarningLevel = securitySystem["red"];
		}
		else if (fragmentCounter >= orangeLevelBenchmark){
			currentWarningLevel = securitySystem["orange"];
		}
		else if (fragmentCounter >= yellowLevelBenchmark){
			currentWarningLevel = securitySystem["yellow"];
		}
		else if (fragmentCounter >= greenLevelBenchmark){
			currentWarningLevel = securitySystem["green"];
		}
		else if (fragmentCounter >= blueLevelBenchmark){
			currentWarningLevel = securitySystem["blue"];
		}
		else if (fragmentCounter >= purpleLevelBenchmark){
			currentWarningLevel = securitySystem["purple"];
		}
		else if (fragmentCounter >= whiteLevelBenchmark){
			currentWarningLevel = securitySystem["white"];
		}
		else {
			currentWarningLevel = securitySystem["white"];
		}
		
	}
}
