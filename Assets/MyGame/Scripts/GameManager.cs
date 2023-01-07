using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private GameObject collectable;


    private float time;

    // Collectable Spawnt bei Start
    void Start()
        
        {
            SpawnCollectable();
        } 
    
   
    public void SpawnCollectable()
    {
        //durch diese Funktion (random range) wird das Collectable random gespawnt
        Instantiate(collectable, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);

    }
}
