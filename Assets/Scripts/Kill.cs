using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{ //Metodo associado aos "kill planes", plataformas "invisíveis" que irão matar o jogador caso eles a toque. Uso em abismos
    private int respawn;
    // Start is called before the first frame update
    void Start()
    {
      respawn = SceneManager.GetActiveScene().buildIndex;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            
            SceneManager.LoadScene(respawn);
        }
    }
}
