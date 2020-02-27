using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu = null;
    [SerializeField] GameObject[] otherLayersOpen = null;
    [SerializeField] Infection infection = null;
    [SerializeField] UpgradeInfo[] upgradeInfo = null;


    //upgrade points counter, used to track upgrade points 
    [SerializeField] UnityEngine.UI.Text upgradePointsCounter;

    int upgradePoints = 5;

    private void Start()
    {
        
    }

    private void Update()
    {
        //update upgrade points counter 
        UpdateUpgradePointsCounter();
    }

    private void UpdateUpgradePointsCounter()
    {
        upgradePointsCounter.text = upgradePoints.ToString();
    }

    //increases upgrade point balance by 1 
    public void AddUpgradePoint()
    {
        upgradePoints++;
    }

    //opens the upgrade screen, same scene but just enables the buttons 
    public void OpenUpgradeScreen()
    {
        foreach (GameObject layer in otherLayersOpen)
        {
            layer.SetActive(false);
        }
        upgradeMenu.SetActive(true);
    }

    //closes upgrade screen 
    public void backToGame()
    {
        upgradeMenu.SetActive(false);
        foreach (GameObject layer in otherLayersOpen)
        {
            layer.SetActive(true);
        }
    }

    //will take id, get the upgrade, decrease point balance, disable button
    public void BuyUpgrade(int id)
    {
        for (int i = 0; i < upgradeInfo.Length; i++)
        {
            //player has enough money, hasn't already purchased upgrade, and has enough points
            if (id == upgradeInfo[i].GetUpgradeId() && !upgradeInfo[i].GetUpgradePurchased() && upgradePoints >= upgradeInfo[i].GetUpgradeCost())
            {
                upgradePoints -= upgradeInfo[i].GetUpgradeCost();
                upgradeInfo[i].Purchase();
                switch (upgradeInfo[i].GetEffect())
                {
                    case UpgradeEffects.spread: //increase spread
                        infection.IncreaseSpreadSpeed(upgradeInfo[i].GetPower());
                        break;
                    case UpgradeEffects.infection: //increase infection
                        infection.IncreaseInfectionSpeed(upgradeInfo[i].GetPower());
                        break;
                    case UpgradeEffects.resistance:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
