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

    //regions 
    [SerializeField] NorthernRegion northernRegion;
    [SerializeField] WesternRegion westernRegion;
    [SerializeField] CentralRegion centralRegion;
    [SerializeField] SouthernRegion southernRegion;

    //spread speed between -1 & 1
    //spread speed of 1 is fast, 0 is no spread, -1 would be fast curing of trees
    //TODO maybe change to not serialize field 
    [Range(-1, 1)] [SerializeField] float spreadSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {
        //disable the counters for while the game is going 
        infectionCounters.SetActive(false);
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
    //TODO enable infection counters 
    private void DisableStartingRegionButtons()
    {
        startingRegionButtons.SetActive(false);
        EnableInfectionCounters();
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
}
