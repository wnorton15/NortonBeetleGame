using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using beetle.SceneManagement;

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

    //time between infection updates 
    [Range(1, 5)] [SerializeField] float timeBetweenUpdates;
    float timeBetweenInfectionSpread = 25f;
    float timeSinceInfectionSpread = Mathf.Infinity;

    //infection speed between -1 & 1
    //infection speed of 1 is fast, 0 is no increase in infection, -1 would be fast curing of trees
    //serializefield only to test 
    [Range(-1, 1)] [SerializeField] float infectionSpeed = 0;

    //spread speed will be between 0 & .05
    //starts at 0, increase with upgrades
    [Range(0, .1f)] [SerializeField] float spreadSpeed = 0;

    //resistance starts at 0, when increased it decreases the effectiveness of counter measures 
    [Range(0, 1f)] [SerializeField] float resistance = 0;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        //disable the counters until starting region is picked 
        infectionCounters.SetActive(false);

        //start spread speed at .1, that means the spread will be a multiple of 1.1 every time it is updated
        infectionSpeed = .1f;

        //start time between updates at 3
        timeBetweenUpdates = 3f;

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        //spread to new region 
        if (spreadSpeed > 0 && !allRegionsInfected && timeSinceInfectionSpread > timeBetweenUpdates)
        {
            randomValue = random.NextDouble();
            Debug.Log(randomValue.ToString());
            Debug.Log("value " + spreadSpeed.ToString());
            if (randomValue < spreadSpeed)
            {
                if (!centralRegion.IsInfected())
                {
                    InfectRegion(2);
                }
                else if (!northernRegion.IsInfected())
                {
                    InfectRegion(1);
                }
                else if (!westernRegion.IsInfected())
                {
                    InfectRegion(3);
                }
                else
                {
                    InfectRegion(4);
                }
                timeSinceInfectionSpread = 0;
            }
        }
        else
        {
            timeSinceInfectionSpread += Time.deltaTime;
        }

        if (northernRegion.IsInfected() && centralRegion.IsInfected() && westernRegion.IsInfected() && southernRegion.IsInfected())
        {
            allRegionsInfected = true;
        }


        if (northernRegion.IsAllInfected() && centralRegion.IsAllInfected() && westernRegion.IsAllInfected() && southernRegion.IsAllInfected())
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
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

    //infection upgrades call this 
    public void IncreaseInfectionSpeed(int power)
    {
        infectionSpeed += (float)power * .15f;
    }

    //spread upgrades call this 
    public void IncreaseSpreadSpeed(int power)
    {
        spreadSpeed += (float)power * .0005f;
    }

    //slows the infection. Called from the counter measures 
    public void SlowInfectionSpeed()
    {
        infectionSpeed -= ( 1 - resistance) * .15f; ;
    }

    //increases resistance 
    public void increaseResistance(int power)
    {
        resistance += (float)power * .15f;
    }
}
