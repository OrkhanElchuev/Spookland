using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySound : MonoBehaviour
{
    public float lifePeriod;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy sound after the given period is finished
        Destroy(gameObject, lifePeriod);
    }
}
