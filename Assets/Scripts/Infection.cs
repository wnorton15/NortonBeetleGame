using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAB.Game
{
    public class Infection : MonoBehaviour
    {
        //initialize variables 
        int startingRegion = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        bool StartingRegionPicked()
        {
            if (startingRegion != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}