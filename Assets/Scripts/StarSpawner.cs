using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ChestController.isOpened)
        {
            Instantiate(spawn, new Vector2(x, y), Quaternion.identity);
        }
    }


}
