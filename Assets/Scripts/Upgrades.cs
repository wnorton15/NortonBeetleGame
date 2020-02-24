using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject[] otherLayersOpen;

    int upgradePoints = 0;

    public void AddUpgradePoint()
    {
        upgradePoints++;
    }

    public void OpenUpgradeScreen()
    {
        foreach (GameObject layer in otherLayersOpen)
        {
            layer.SetActive(false);
        }
        upgradeMenu.SetActive(true);
    }

    public void backToGame()
    {
        upgradeMenu.SetActive(false);
        foreach (GameObject layer in otherLayersOpen)
        {
            layer.SetActive(true);
        }
    }

    public void BuyUpgrade(int id)
    {
        Debug.Log(id.ToString());
    }
}
