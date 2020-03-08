using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = (int)Random.Range(0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
