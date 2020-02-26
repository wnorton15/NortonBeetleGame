using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject[] otherLayersOpen;

    [SerializeField] UpgradeInfo[] upgradeInfo;

    int upgradePoints = 0;

    private void Start()
    {
        
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
        Debug.Log(id.ToString());
    }
}
