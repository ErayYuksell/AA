using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    private void Start()
    {
       // PlayerPrefs.DeleteAll(); //kayitlari siler build ederken yorum satiri olmasi lazim test ederken kullaniliyor 
    }
    public void StartGame()
    {
        int registeredLevel = PlayerPrefs.GetInt("registration");
        if (registeredLevel == 0) // burada basta kayitli bir level yoksa hep main menuda kalir bunu engellemek icin boyle bir sorgu yaptik
            //GameManager da int a cevirdik o yuzden rahat rahat sayi ekleyebiliyoruz 
        {
            SceneManager.LoadScene(registeredLevel+1);
        }
        else
        {
            SceneManager.LoadScene(registeredLevel); //bu scenei yukle demek
        }
       
    }
    public void GameExit()
    {
        Application.Quit(); //oyun build edildikten sonra calisir 
    }
}
