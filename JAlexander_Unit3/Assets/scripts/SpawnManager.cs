using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsPrefab;
    private Vector3 spawnPos = new Vector3(15, 0, 0);
    private playercontroller playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObs", 2, 2);

        playerCtrl = GameObject.Find("player").GetComponent<playercontroller>();


    }
        

        void SpawnObs()
        {

        if (playerCtrl.gameOver == false)
        {
            Instantiate(obsPrefab, spawnPos, obsPrefab.transform.rotation);
        }
        }
    
}