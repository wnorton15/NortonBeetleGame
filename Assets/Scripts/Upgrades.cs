using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject[] otherLayersOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpgradeScreen()
    {
        foreach (GameObject layer in otherLayersOpen)
        {
            layer.SetActive(false);
        }
        upgradeMenu.SetActive(true);
    }

    public void backToGame()
    {
        upgradeMenu.SetActive(false);
        foreach (GameObject layer in otherLayersOpen)
        {
            layer.SetActive(true);
        }
    }
}
