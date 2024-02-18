using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject medusa, minotaur;
    [SerializeField]Transform medusaSpawn, minotaurSpawn;

    // Start is called before the first frame update
    void Start()
    {
        medusa = Instantiate(medusa);
        medusa.transform.position = medusaSpawn.position;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
