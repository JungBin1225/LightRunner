using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject rankingMenu;
    public List<Sprite> icons;

    private GameObject goal;
    private GameObject[] players;
    private Dictionary<string, Sprite> spriteToString;

    private string first;
    private string second;
    private string thrid;
    private string fourth;

    void Start()
    {
        goal = GameObject.Find("GoalLine");
        players = GameObject.FindGameObjectsWithTag("Charactor");

        spriteToString = new Dictionary<string, Sprite>();
        spriteToString.Add("Chicken", icons[0]);
        spriteToString.Add("Cat", icons[1]);
        spriteToString.Add("Dog", icons[2]);
        spriteToString.Add("Penguin", icons[3]);
    }

    // Update is called once per frame
    void Update()
    {
        float dis_1 = Vector3.Distance(players[0].transform.position, goal.transform.position);
        float dis_2 = Vector3.Distance(players[1].transform.position, goal.transform.position);
        float dis_3 = Vector3.Distance(players[2].transform.position, goal.transform.position);
        float dis_4 = Vector3.Distance(players[3].transform.position, goal.transform.position);

        float[] dis = { dis_1, dis_2, dis_3, dis_4 };
        int[] rank = { 1, 1, 1, 1 };

        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if(dis[i] > dis[j])
                {
                    rank[i]++;
                }
            }
        }

        for(int i = 0; i < 4; i++)
        {
            rankingMenu.transform.GetChild(rank[i] - 1).GetComponent<Image>().sprite = spriteToString[players[i].name];
        }
        
    }

    public void OnPauseClicked()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnResumeClicked()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
