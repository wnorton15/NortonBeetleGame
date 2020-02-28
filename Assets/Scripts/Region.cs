using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    //NORTHERN REGION ID
    [SerializeField] int idnum = 0;

    //bool variables to track what points have been given. 
    //each region gives 3 points. 1/2 infected, 3/4 infected, and entirely infected 
    //also controls counter measures 
    bool firstPoint = false;
    bool secondPoint = false;
    bool thirdPoint = false;

    //serialize field for upgrades script, used for adding points 
    [SerializeField] Upgrades upgrades;

    //time since infection update 
    float timeSinceUpdated = Mathf.Infinity;

    //time between infection updates 
    [SerializeField] Infection infection = null;

    float timeBetweenUpdates = 1f;

    //initialize variables
    bool infected = false;
    bool allTreesInfected = false;
    [SerializeField] int numTreesTotal = 1500000;
    float numTreesInfected = 0;

    //counter variable 
    [SerializeField] UnityEngine.UI.Text regionCounter = null;

    //sprite renderer, percent infected  
    //used to change color of the region on the map
    SpriteRenderer spriteRenderer;
    float percentInfected = 0;
    float colorPercent = 1;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        timeBetweenUpdates = infection.GetTimeBetweenUpdates();
    }

    // Update is called once per frame
    void Update()
    {
        //this is for updating the number of trees infected 
        if (timeSinceUpdated > timeBetweenUpdates)
        {
            if (numTreesInfected == 0)
            {
                return;
            }
            else
            {
                UpdateInfection();
            }
        }
        else
        {
            timeSinceUpdated += Time.deltaTime;
        }

        //this is for adding upgrade points 
        CheckForUpgradePoint();

    }

    private void CheckForUpgradePoint()
    {
        //each point can only be given once 
        if (numTreesInfected > numTreesTotal / 2 && !firstPoint)
        {
            upgrades.AddUpgradePoint();
            firstPoint = true;
            CounterMeasures(1);
        }
        else if (numTreesInfected > numTreesTotal / 3 && !secondPoint)
        {
            upgrades.AddUpgradePoint();
            secondPoint = true;
            CounterMeasures(2);
        }
        else if (numTreesInfected == numTreesTotal && !thirdPoint)
        {
            upgrades.AddUpgradePoint();
            thirdPoint = true;
            allTreesInfected = true;
        }
    }

    private void UpdateInfection()
    {
        //grow slowly when small infection 
        if (numTreesInfected < 10)
        {
            numTreesInfected += 1;
            timeSinceUpdated = 0;
            UpdateCounter();
        }
        else
        {
            //test to see how the spread is with a random number 1.1 seems to work good
            //infection.getspreadspeed returns the between -1 and 1
            if (numTreesInfected < numTreesTotal / 2)
            {
                numTreesInfected *= 1f + infection.GetInfectionSpeed();
            }
            else
            {//keeps infection from going over 100%
                numTreesInfected = Mathf.Clamp(numTreesInfected * 1.05f, 1, numTreesTotal);
            }
            //keeps number of trees infected as an int 
            numTreesInfected = (int)numTreesInfected / 1;
            //reset timer 
            timeSinceUpdated = 0;
            //get percent of region infected. This is used to change color 
            percentInfected = (float)numTreesInfected / numTreesTotal;
            
            //update counter 
            UpdateCounter();

            //change color 
            colorPercent = 1 - percentInfected;
            spriteRenderer.color = new Color(colorPercent, colorPercent, colorPercent, 1);
        }
    }

    private void UpdateCounter()
    {
        regionCounter.text = numTreesInfected.ToString();
    }

    public void Infect()
    {
        //infect region 
        infected = true;
        numTreesInfected += 1;
    }

    public int GetId()
    {
        return idnum;
    }

    public bool IsInfected()
    {
        return infected;
    }

    public bool IsAllInfected()
    {
        return allTreesInfected;
    }

    private void CounterMeasures(int power)
    {
        numTreesInfected = numTreesInfected / (power + 1);
    }



}
