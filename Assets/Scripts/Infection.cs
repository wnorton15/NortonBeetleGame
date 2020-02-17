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
        DisableStartingRegionButtons();
    }
    public void SetWesternStartingRegion()
    {
        //startingRegion = westernRegion;
        DisableStartingRegionButtons();
    }
    public void SetCentralStartingRegion()
    {
        //startingRegion = centralRegion;
        DisableStartingRegionButtons();
    }
    public void SetSouthernStartingRegion()
    {
        //startingRegion = southernRegion;
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
    public void infectRegion(int regionId)
    {
        switch (regionId)
        {
            case 1:
                //northernRegionInfected = true;
                break;
            case 2:
                //centralRegionInfected = true;
                break;
            case 3:
                //westernRegionInfected = true;
                break;
            case 4:
                //southernRegionInfected = true;
                break;
        }
    }
}
