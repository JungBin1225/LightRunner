using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSword : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Charactor")
        {
            if(other.name == "Chicken")
            {
                if(!other.GetComponent<CharactorMove>().isSword)
                {
                    other.GetComponent<CharactorMove>().isSword = true;

                    Destroy(this.gameObject);
                }
            }
            else
            {
                if(!other.GetComponent<RivalController>().isSword)
                {
                    other.GetComponent<RivalController>().isSword = true;

                    Destroy(this.gameObject);
                }
            }
        }
    }
}
