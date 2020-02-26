using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    //int variable keeping track of the starting region 
    int startingRegion = 0;

    [SerializeField] GameObject startingRegionButtons;
    [SerializeField] GameObject infectionCounters;
    [SerializeField] GameObject upgradeButton;

    //regions 
    [SerializeField] NorthernRegion northernRegion;
    [SerializeField] WesternRegion westernRegion;
    [SerializeField] CentralRegion centralRegion;
    [SerializeField] SouthernRegion southernRegion;

    //changes with upgrades 
    [Range(1, 5)] [SerializeField] float timeBetweenUpdates;

    //spread speed between -1 & 1
    //spread speed of 1 is fast, 0 is no spread, -1 would be fast curing of trees
    //serializefield only to test 
    [Range(-1, 1)] [SerializeField] float spreadSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {
        //disable the counters for while the game is going 
        infectionCounters.SetActive(false);

        //start spread speed at .1, that means the spread will be a multiple of 1.1 every time it is updated
        spreadSpeed = .1f;

        //start time between updates at 3
        timeBetweenUpdates = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //methods to set starting region and disable buttons 
    //disable buttons 
    public void SetNorthernStartingRegion()
    {
        startingRegion = northernRegion.GetId();
        InfectRegion(startingRegion);
        DisableStartingRegionButtons();
    }
    public void SetWesternStartingRegion()
    {
        startingRegion = westernRegion.GetId();
        InfectRegion(startingRegion);
        DisableStartingRegionButtons();
    }
    public void SetCentralStartingRegion()
    {
        startingRegion = centralRegion.GetId();
        InfectRegion(startingRegion);
        DisableStartingRegionButtons();
    }
    public void SetSouthernStartingRegion()
    {
        startingRegion = southernRegion.GetId();
        InfectRegion(startingRegion);
        DisableStartingRegionButtons();
    }

    //get rid of the buttons when one starting region is selected 
    //enable infection counters and upgrade button
    private void DisableStartingRegionButtons()
    {
        startingRegionButtons.SetActive(false);
        EnableInfectionCounters();
        EnableUpgradeButton();
    }

    private void EnableUpgradeButton()
    {
        upgradeButton.SetActive(true);
    }

    private void EnableInfectionCounters()
    {
        infectionCounters.SetActive(true);
    }

    //this infects new region 
    public void InfectRegion(int regionId)
    {
        switch (regionId)
        {
            case 1:
                northernRegion.Infect();
                break;
            case 2:
                centralRegion.Infect();
                break;
            case 3:
                westernRegion.Infect();
                break;
            case 4:
                southernRegion.Infect();
                break;
        }
    }

    //these return values
    public float GetTimeBetweenUpdates()
    {
        return timeBetweenUpdates;
    }
    public float GetSpreadSpeed()
    {
        return spreadSpeed;
    }

    //spread upgrades call this 
    public void IncreaseSpreadSpeed(int power)
    {
        spreadSpeed += (float)power * .15f;
    }
}
