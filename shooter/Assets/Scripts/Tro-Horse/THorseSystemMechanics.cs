using UnityEngine;
using System;
using System.Collections.Generic;

public class THorseSystemMechanics : MonoBehaviour {

	// Depends on the superclass "GameMechanics"
	public GameBehavior gameScript;
	public PlayerInteraction deathFlag;

	// TODO: Relies on the superclass "Enemy"

	// Construct values only access by this class.
	public int fragmentCounter;
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
        // List elements: {speed, startShootTime, timeBetweenShots, bulletVelocity}
        List<float> redModifier = new List<float>() { 1.5f, -0.75f, -0.75f, 1.5f };
        List<float> orangeModifier = new List<float>() { 1, -0.5f, -0.5f, 1 };
        List<float> yellowModifier = new List<float>() { 0.5f, -0.25f, -0.25f, 0.5f };
        List<float> greenModifier = new List<float>() { 0, 0, 0, 0 };
        List<float> blueModifier = new List<float>() { -0.5f, 0, 0, -1 };
        List<float> purpleModifier = new List<float>() { -1, 0.5f, -0.5f, -1.5f };
        List<float> whiteModifier = new List<float>() { -1.5f, 0.75f, -0.75f, -1.75f };

		Dictionary<string, WarningLevel> securityLevels = new Dictionary<string, WarningLevel> ();
		WarningLevel red = new WarningLevel("red", redModifier, 4.0f);
		WarningLevel orange = new WarningLevel ("orange", orangeModifier, 3.0f);
		WarningLevel yellow = new WarningLevel ("yellow", yellowModifier, 2.0f);
		WarningLevel green = new WarningLevel ("green", greenModifier, 1.0f);
		WarningLevel blue = new WarningLevel ("blue", blueModifier, 0.5f);
		WarningLevel purple = new WarningLevel ("purple", purpleModifier, 0.25f);
		WarningLevel white = new WarningLevel ("white", whiteModifier, 0.001f);
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
			deathFlag.deathTrigger = false;
		}
		else {
			increasePointScore(5);
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
	public void increasePointScore(int points) {
		if (gameScript.grazeTriggered) {
			fragmentCounter += points;
			gameScript.grazeTriggered = false;
		}

        if (gameScript.enemyDeathTriggered)
        {
            fragmentCounter += points;
            gameScript.enemyDeathTriggered = false;
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

		// Red: Increase bullet speed of enemies + (all below above Green)
		// Orange: Increase bullet density against player
		// Yellow: Increases bullet fire rate of enemies
		// Green: NORMAL BEHAVIOR
		// Blue: Decreases bullet fire rate of enemies
		// Purple Decreases Bullet Speed of enemies
		// White: Increases chances of life and bomb upgrades by 50%

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

    internal float GetModifier(int index)
    {
        return currentWarningLevel.getValueEffects()[index];
    }
}
