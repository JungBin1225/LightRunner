using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float countDown;
    public bool start;

    void Awake()
    {

    }

    void Start()
    {
        countDown = 3;
        start = false;
    }

    void Update()
    {
        if(countDown < 0)
        {
            start = true;
        }
        else
        {
            countDown -= Time.deltaTime;
        }
    }
}
