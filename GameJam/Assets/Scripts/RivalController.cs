using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalController : MonoBehaviour
{
    public int num;
    public float speed;
    public bool isSword;

    public GameObject[] lines;
    List<GameObject> wayPoints;
    GameManager gm;
    GameObject target;
    Animator ani;
    int point;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        ani = GetComponent<Animator>();

        wayPoints = new List<GameObject>();
        for(int i = 0; i < 6; i++)
        {
            wayPoints.Add(lines[i].transform.GetChild(num - 1).gameObject);
        }

        ani.SetBool("Walk", true);
        point = 0;
        isSword = false;
    }

    
    void Update()
    {
        target = wayPoints[point];
        
        if(gm.start)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 1)
            {
                if (point < 5)
                {
                    point++;
                }
            }
            else
            {
                transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
                transform.LookAt(target.transform);
            }
        }

        /*if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }*/
    }
}
