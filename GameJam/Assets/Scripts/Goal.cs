using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Chicken")
        {
            if(other.GetComponent<CharactorMove>().isSword)
            {
                SceneManager.LoadScene("Clear");
            }
        }
    }
}