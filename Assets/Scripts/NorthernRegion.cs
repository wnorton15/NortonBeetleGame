using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NorthernRegion : MonoBehaviour
{
    //NORTHERN REGION ID
    int idnum = 1;

    //time since infection update 
    float timeSinceUpdated = Mathf.Infinity;

    //TODO make this the same for all regions
    [Range(1, 5)] [SerializeField] float timeBetweenUpdates = 3f;

    //initialize variables
    bool infected = false;
    int numTreesTotal = 1500000;
    double numTreesInfected = 0;
    int numTreesDead = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceUpdated > timeBetweenUpdates)
        {
            if (numTreesInfected == 0)
            {
                return;
            }
            else if (numTreesInfected < 10)
            {
                numTreesInfected += 1;
                timeSinceUpdated = 0;
                Debug.Log(numTreesInfected.ToString());
            }
            else
            {
                //test to see how the spread is with a random number 
                numTreesInfected *= 1.1;
                numTreesInfected = (int)numTreesInfected / 1;
                timeSinceUpdated = 0;
                Debug.Log(numTreesInfected.ToString());
            }
        }
        else
        {
            timeSinceUpdated += Time.deltaTime;
        }

    }

    public void Infect()
    {
        infected = true;
        numTreesInfected += 1;
    }

    public int GetId()
    {
        return idnum;
    }
}
