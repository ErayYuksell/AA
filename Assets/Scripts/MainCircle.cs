using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    //Main circleden circleler olusacak direkt olarak harakete baslicaklar
    public GameObject circle;
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CreateCircle();
        }
    }

    void CreateCircle()
    {
        Instantiate(circle,transform.position,transform.rotation) ;
        gameManager.GetComponent<GameManager>().circleShowText();
    }
}
