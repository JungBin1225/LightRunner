using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactorMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public bool setMirrorAble;
    public bool isSword;
    public GameObject swordIcon;

    private float acc;
    

    GameManager gm;
    CharacterController controller;
    Animator ani;
    SetMirror mirrorGen;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        controller = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
        mirrorGen = GetComponentInChildren<SetMirror>();
        acc = 1;
        setMirrorAble = true;
        isSword = false;
    }

    void Update()
    {
        if(gm.start)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            if (moveZ > 0 && acc < 4)
            {
                acc += Time.deltaTime;
            }
            else if (moveZ <= 0)
            {
                acc = 1;
            }

            transform.Rotate(0, moveX * rotSpeed, 0);
            controller.SimpleMove(transform.forward * moveZ * moveSpeed * acc * Time.deltaTime);

            if (moveZ == 0)
            {
                ani.SetBool("Walk", false);
            }
            else
            {
                ani.SetBool("Walk", true);
            }

            if (setMirrorAble)
            {
                mirrorGen.gameObject.SetActive(true);
            }
            else
            {
                mirrorGen.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject mirror = GameObject.FindGameObjectWithTag("Mirror");
                    Destroy(mirror);
                    setMirrorAble = true;
                }
            }

            if(isSword)
            {
                swordIcon.SetActive(true);
            }
            else
            {
                swordIcon.SetActive(false);
            }

            if(transform.position.y < -10)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
