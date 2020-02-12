using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    //int variable keeping track of the starting region 
    int startingRegion = 0;

    //int variables with values for each region
    int northernRegion = 1;
    int westernRegion = 2;
    int centralRegion = 3;
    int southernRegion = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //methods to set starting region and disable buttons 
    //TODO disable buttons 
    public void SetNorthernStartingRegion()
    {
        startingRegion = northernRegion;
    }
    public void SetWesternStartingRegion()
    {
        startingRegion = westernRegion;
    }
    public void SetCentralStartingRegion()
    {
        startingRegion = centralRegion;
    }
    public void SetSouthernStartingRegion()
    {
        startingRegion = southernRegion;
    }

}
