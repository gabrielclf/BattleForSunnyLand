using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool JogoPausado = false;
    public GameObject menuPausa;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(JogoPausado){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        JogoPausado = false;
    }

    void Pause(){
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        JogoPausado = true;
    }

    public void CarregarMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void FecharJogo(){
        Application.Quit();
    }
}
