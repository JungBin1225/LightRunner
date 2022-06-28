using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMirror : MonoBehaviour
{
    public float rotSpeed;
    public GameObject mirrorPrefab;

    CharactorMove player;

    void Start()
    {
        player = GetComponentInParent<CharactorMove>();
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, rotSpeed, 0);
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -rotSpeed, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && player.setMirrorAble)
        {
            GameObject mirror = Instantiate(mirrorPrefab, transform.position, transform.rotation);

            if (transform.localRotation.eulerAngles.y > 0 && transform.localRotation.eulerAngles.y < 180)
            {
                
                mirror.transform.GetChild(0).localRotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                mirror.transform.GetChild(0).localRotation = Quaternion.Euler(0, 90, 0);
            }

            player.setMirrorAble = false;
        }
    }
}
