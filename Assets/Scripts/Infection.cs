using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infection : MonoBehaviour
{
    //random object used to control spread
    System.Random random = new System.Random();
    //double variable to store the random number for comparing 
    double randomValue;

    //all regions infected stops spread 
    bool allRegionsInfected = false;

    //int variable keeping track of the starting region 
    int startingRegion = 0;
    
    //layers of ui, used to enable / disable 
    [SerializeField] GameObject startingRegionButtons;
    [SerializeField] GameObject infectionCounters;
    [SerializeField] GameObject upgradeButton;
    [SerializeField] GameObject upgradePointsCounterObject;

    //regions 
    [SerializeField] Region northernRegion;
    [SerializeField] Region westernRegion;
    [SerializeField] Region centralRegion;
    [SerializeField] Region southernRegion;

    //changes with upgrades 
    [Range(1, 5)] [SerializeField] float timeBetweenUpdates;

    //infection speed between -1 & 1
    //infection speed of 1 is fast, 0 is no increase in infection, -1 would be fast curing of trees
    //serializefield only to test 
    [Range(-1, 1)] [SerializeField] float infectionSpeed = 0;

    //spread speed will be between 0 & .05
    //starts at 0, increase with upgrades
    [Range(0, .05f)] [SerializeField] float spreadSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        //disable the counters until starting region is picked 
        infectionCounters.SetActive(false);

        //start spread speed at .1, that means the spread will be a multiple of 1.1 every time it is updated
        infectionSpeed = .1f;

        //start time between updates at 3
        timeBetweenUpdates = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //spread to new region 
        if (spreadSpeed > 0)
        {
            randomValue = random.NextDouble();
            if (randomValue < spreadSpeed)
            {
                
            }
        }
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
        upgradePointsCounterObject.SetActive(true);
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
    public float GetInfectionSpeed()
    {
        return infectionSpeed;
    }

    //spread upgrades call this 
    public void IncreaseInfectionSpeed(int power)
    {
        infectionSpeed += (float)power * .15f;
    }
}
