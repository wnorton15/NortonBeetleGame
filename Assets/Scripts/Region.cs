﻿using System;
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

    //news report text. Used to let the player know about counter measures 
    [SerializeField] UnityEngine.UI.Text newsReportText;

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
        if (numTreesInfected > numTreesTotal / 3 && !firstPoint)
        {
            upgrades.AddUpgradePoint();
            firstPoint = true;
            CounterMeasures(1);
            UpdateNewsReport(1, idnum);
        }
        else if (numTreesInfected > numTreesTotal / 2 && !secondPoint)
        {
            upgrades.AddUpgradePoint();
            secondPoint = true;
            CounterMeasures(2);
            UpdateNewsReport(2, idnum);
        }
        else if (numTreesInfected == numTreesTotal && !thirdPoint)
        {
            upgrades.AddUpgradePoint();
            thirdPoint = true;
            allTreesInfected = true;
            CounterMeasures(0);
            UpdateNewsReport(3, idnum);
        }
    }

    private void UpdateNewsReport(int counterMeasureNum, int idnum)
    {
        switch (idnum)
        {
            case 1:
                if (counterMeasureNum == 1)
                {
                    newsReportText.text = "Northern Region is 1/3 infected, scientists have started treating trees.";
                }
                else if (counterMeasureNum == 2)
                {
                    newsReportText.text = "Northern Region is 1/2 infected, scientists have started spraying pesticide.";
                }
                else if (counterMeasureNum == 3)
                {
                    newsReportText.text = "Northern Region trees have all been infected. Scientists have given up.";
                }
                else
                {
                    newsReportText.text = "";
                }
                break;
            case 2:
                if (counterMeasureNum == 1)
                {
                    newsReportText.text = "Central Region is 1/3 infected, scientists have started treating trees.";
                }
                else if (counterMeasureNum == 2)
                {
                    newsReportText.text = "Central Region is 1/2 infected, scientists have started spraying pesticide.";
                }
                else if (counterMeasureNum == 3)
                {
                    newsReportText.text = "Central Region trees have all been infected. Scientists have given up.";
                }
                else
                {
                    newsReportText.text = "";
                }
                break;
            case 3:
                if (counterMeasureNum == 1)
                {
                    newsReportText.text = "Western Region is 1/3 infected, scientists have started treating trees.";
                }
                else if (counterMeasureNum == 2)
                {
                    newsReportText.text = "Western Region is 1/2 infected, scientists have started spraying pesticide.";
                }
                else if (counterMeasureNum == 3)
                {
                    newsReportText.text = "Western Region trees have all been infected. Scientists have given up.";
                }
                else
                {
                    newsReportText.text = "";
                }
                break;
            case 4:
                if (counterMeasureNum == 1)
                {
                    newsReportText.text = "Southern Region is 1/3 infected, scientists have started treating trees.";
                }
                else if (counterMeasureNum == 2)
                {
                    newsReportText.text = "Southern Region is 1/2 infected, scientists have started spraying pesticide.";
                }
                else if (counterMeasureNum == 3)
                {
                    newsReportText.text = "Southern Region trees have all been infected. Scientists have given up.";
                }
                else
                {
                    newsReportText.text = "";
                }
                break;
            default:
                newsReportText.text = "";
                break;
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
        //lower number of trees infected 
        numTreesInfected = numTreesInfected / (power + 1);
        //temporarily stop the infection  
        timeSinceUpdated = -10f;
        //slow the infection speed
        infection.SlowInfectionSpeed();
    }
}
