using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Circle : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    public float speed;
    bool MoveControl = false;
    public GameObject gameManager; //GameManager daki GameOver a ulasmak icin tag uzerinden objeyi bulup getComponent ile script uzerinden islem yapiyorum
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }


    void FixedUpdate()
    {
        if (!MoveControl) //bool mantigi su false iken her zaman haraket edicek calisicak ama tagi spinningCircle olan objeyle carpisinca boolu true yapiyorum bu sayede haraket etmiyor 
        {
            myRigidBody.MovePosition(myRigidBody.position + Vector2.up * speed * Time.deltaTime); // movePosition neden ?????????????
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpinningCircle"))
        {
            transform.SetParent(collision.transform); //circle i donen circleye carptiginda donenin childi yaparak o ne yapiyorsa onu yapmasini sagliyorum yani donucek 
            MoveControl = true;
        }
        if (collision.CompareTag("Circle"))
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
