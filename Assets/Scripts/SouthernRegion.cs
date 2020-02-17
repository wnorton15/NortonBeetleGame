using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthernRegion : MonoBehaviour
{
    //SOUTHERN REGION ID
    public int idnum = 4;

    //initialize variables
    bool infected = false;
    int numTreesTotal = 1500000;
    int numTreesInfected = 0;
    int numTreesDead = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Infect()
    {
        infected = true;
        numTreesInfected += 1;
    }
}
