using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {

        if(gm.countDown < 3)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if (gm.countDown < 2)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if(gm.countDown < 1)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }

        if(gm.countDown < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
