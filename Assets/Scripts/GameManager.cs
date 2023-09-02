using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject spinningCircle;
    GameObject mainCircle;
    public Animator animator;
    public Text spinningCircleLevel;
    public Text one;
    public Text two;
    public Text three;
    public int circleCount;
    bool control = true;
    void Start()
    {
        PlayerPrefs.SetInt("registration", int.Parse(SceneManager.GetActiveScene().name)); // telefon hafizasina icine kayit yapar istedigimiz yerden cagrilabilir ulasilabilir key i girdigimde bana icinde ne varsa onu dondurur 
        //sadece int olarak kaydetme yok float olarak falanda var 


        spinningCircle = GameObject.FindGameObjectWithTag("SpinningCircle");
        mainCircle = GameObject.FindGameObjectWithTag("MainCircle");
        spinningCircleLevel.text = SceneManager.GetActiveScene().name; //active scene ismini text icine yaziyor 
        if (circleCount < 2)//oyun basladiginda mainCircle kisminda toplarin icinde yazan yazilar
        {
            one.text = circleCount.ToString();
        }
        else if (circleCount < 3)
        {
            one.text = circleCount.ToString();
            two.text = (circleCount - 1).ToString();
        }
        else
        {
            one.text = circleCount.ToString();
            two.text = (circleCount - 1).ToString();
            three.text = (circleCount - 2).ToString();
        }
        if (circleCount == 0)
        {
            StartCoroutine(newLevel());
        }
    }
    IEnumerator newLevel()
    {
        spinningCircle.GetComponent<Spinning>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        yield return new WaitForSeconds(1);
        if (control) //circle icinde 0 yazdiginda ayni anda gameOver olursa diye control degiskeni gameOver oldugunda false durumuna gecer o yuzden burayida calistirmaz ve sorun cozulur 
        {
            animator.SetTrigger("NewLevel");
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);  //tum mainCirclelarim bittiginde yani 0 i gordugumuzde su anki scene sayisina 1 ekleyerek diger scene 
        }
    }
    public void circleShowText() //toplarin icinde yazan sayilarin ekrana tiklandiginda text olarak azaltma yapar
    {
        circleCount--;
        if (circleCount < 2)
        {
            one.text = circleCount.ToString();
            two.text = "";
            three.text = "";
        }
        else if (circleCount < 3)
        {
            one.text = circleCount.ToString();
            two.text = (circleCount - 1).ToString();
            three.text = "";
        }
        else
        {
            one.text = circleCount.ToString();
            two.text = (circleCount - 1).ToString();
            three.text = (circleCount - 2).ToString();
        }
        if (circleCount == 0) // her mouse a tikladigimda bunu kontrol eder 0 a ulastiysek yeni levela gecer 
        {
            StartCoroutine(newLevel());
        }
    }
    public void GameOver()
    {
        StartCoroutine(CallMethot());
    }
    IEnumerator CallMethot()
    {
        spinningCircle.GetComponent<Spinning>().enabled = false; //Ust uste circle geldiginde oyunun durmasi icin direkt olarak scriptlerini kapadim
        mainCircle.GetComponent<MainCircle>().enabled = false;
        animator.SetTrigger("GameEnd"); //GameOver oldugunda olusturdugum animasyon calisacak
        control = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
}
