using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralRegion : MonoBehaviour
{
    //CENTRAL REGION ID
    int idnum = 2;

    //time since infection update 
    float timeSinceUpdated = Mathf.Infinity;

    float timeBetweenUpdates = 1f;
    //time between infection updates 
    [SerializeField] Infection infection = null;
    //initialize variables
    bool infected = false;
    int numTreesTotal = 2500000;
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
        Debug.Log(spriteRenderer.color.ToString());
        timeBetweenUpdates = infection.GetTimeBetweenUpdates();
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
            else
            {
                UpdateInfection();
            }
        }
        else
        {
            timeSinceUpdated += Time.deltaTime;
        }

    }

    private void UpdateInfection()
    {
        //grow slowly when small infection 
        if (numTreesInfected < 10)
        {
            numTreesInfected += 1;
            timeSinceUpdated = 0;
            Debug.Log(numTreesInfected.ToString());
            UpdateCounter();
        }
        else
        {
            //test to see how the spread is with a random number 1.1 seems to work good
            //TODO make the spread easily changed by variable 
            if (numTreesInfected < numTreesTotal / 2)
            {
                numTreesInfected *= 1.1f;
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

            //debug messages for testing
            Debug.Log(numTreesInfected.ToString());
            Debug.Log(percentInfected.ToString());

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
}
