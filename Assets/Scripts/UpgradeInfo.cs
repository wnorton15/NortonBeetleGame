using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInfo : MonoBehaviour
{
    //variables used by Upgrades.cs
    [SerializeField] int upgradeId;
    [SerializeField] bool upgradePurchased = false;
    [SerializeField] int upgradeCost;
    [SerializeField] UpgradeEffects effect;
    [SerializeField] [Range(1, 3)] int power;

    //these methods just return values 
    public int GetUpgradeId()
    {
        return upgradeId;
    }
    public bool GetUpgradePurchased()
    {
        return upgradePurchased;
    }
    public int GetUpgradeCost()
    {
        return upgradeCost;
    }
    public UpgradeEffects GetEffect()
    {
        return effect;
    }
    public int GetPower()
    {
        return power;
    }
}

//enum of effects 
public enum UpgradeEffects
{
    spread, 
    infection, 
    resistance
};