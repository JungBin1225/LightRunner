using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject explaneWin;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnExplaneClicked()
    {
        explaneWin.SetActive(true);
    }

    public void OnExplaneClose()
    {
        explaneWin.SetActive(false);
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
