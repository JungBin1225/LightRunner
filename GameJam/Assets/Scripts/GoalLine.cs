using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalLine : MonoBehaviour
{
    public bool isGoal;
    
    void Start()
    {
        isGoal = false;
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Charactor")
        {
            isGoal = true;

            if(other.name == "Chicken")
            {

            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
