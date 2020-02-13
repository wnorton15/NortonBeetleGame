using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralRegion : MonoBehaviour
{
    //initialize variables
    bool infected = false;
    int numTreesTotal = 2500000;
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
