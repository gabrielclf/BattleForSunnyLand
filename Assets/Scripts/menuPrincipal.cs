using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{
     public void FecharJogo()
     {
          Application.Quit();
          Debug.Log("Fechou!");
     }
     public void IniciarJogo()
     {
          SceneManager.LoadScene("Ato1");
     }

     public void RetornarMenu()
     {
          SceneManager.LoadScene("MainMenu");
     }

}
