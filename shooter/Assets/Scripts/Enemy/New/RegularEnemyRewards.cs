using UnityEngine;
using System.Collections;

public class RegularEnemyRewards : MonoBehaviour {

    private int maxHitpoints;
    public GameObject oneUpPickupItem;
    public GameObject bombUpPickUpItem;
    public GameObject firePowerPickUpItem;
    public GameObject scoreUpPickUpItem;


    public void DropRewards(GameBehavior gameMechanicsInterface, GameObject obj)
    {
        grantPlayerPoints(gameMechanicsInterface);
        grantPowerUpItem(obj);
    }

    public void grantPlayerPoints(GameBehavior gameMechanicsInterface)
    {
        // TODO: Use this flag in the Tro-HorseSystemMechanics file.
        // This will be reverted back to false in the Trojan Horse system.
        int defaultScoreGivenToPlayer = 100;
        int getCurrentGrazeMultiplier = gameMechanicsInterface.grazeMultiplier;
        int totalScoreIncrease = (defaultScoreGivenToPlayer * getCurrentGrazeMultiplier);
        gameMechanicsInterface.scoreCounter += totalScoreIncrease;
    }

    public void grantPowerUpItem(GameObject obj)
    {
        int randonNumberLow = 0;
        int randomNumberHigh = 10;
        int randNumber = Random.Range(randonNumberLow, randomNumberHigh);
        int firePowerLow = 1;
        int bombUpLow = 8;

        if (randNumber == randonNumberLow)
        {
            Instantiate(oneUpPickupItem, obj.transform.position, obj.transform.rotation);
        }
        else if (randNumber >= firePowerLow && randNumber < bombUpLow)
        {
            Instantiate(firePowerPickUpItem, obj.transform.position, obj.transform.rotation);
        }
        else if (randNumber >= bombUpLow && randNumber < randomNumberHigh)
        {
            Instantiate(bombUpPickUpItem, obj.transform.position, obj.transform.rotation);
        }
        else
        {
            Instantiate(scoreUpPickUpItem, obj.transform.position, obj.transform.rotation);
        }
    }
}
