using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    public static int hp = 3; //quantidade de hits que pode tomar antes de perder uma via
    public GameObject hit1, hit2, hit3;
    public int vidas = 3;//se chegar a 0 = gameover
    [SerializeField] private TextMeshProUGUI contadorVidas;

    public bool isHurt = false;
    public bool isDead = false;

    void Start()
    {
        hit1.gameObject.SetActive(true);
        hit2.gameObject.SetActive(true);
        hit3.gameObject.SetActive(true);
    }

    void Update()
    { //pegar input do jogador
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        //Controle de HP do jogador
        if (hp > 3)
        {
            hp = 3;
        }
        switch (hp)
        {
            case 3:
                hit1.gameObject.SetActive(true);
                hit2.gameObject.SetActive(true);
                hit3.gameObject.SetActive(true);
                break;

            case 2:
                hit1.gameObject.SetActive(true);
                hit2.gameObject.SetActive(true);
                hit3.gameObject.SetActive(false);
                break;

            case 1:
                hit1.gameObject.SetActive(true);
                hit2.gameObject.SetActive(false);
                hit3.gameObject.SetActive(false);
                break;

            case 0:
                hit1.gameObject.SetActive(false);
                hit2.gameObject.SetActive(false);
                hit3.gameObject.SetActive(false);
                break;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    { // realizar os comandos no jogo
        //mover personagem
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnTriggerEnter2D(Collider2D detect)
    {
        if (detect.CompareTag("Obstaculo"))
        {
            hp -= 1;
        }
        if (detect.CompareTag("Obstaculo") && hp > 0)
        {
            animator.SetTrigger("isHurt");
            StartCoroutine("Hurt");
        }
        else
        {
            isDead = true;
            animator.SetTrigger("isDead");
            StartCoroutine("Death");
        }
    }

    IEnumerator Hurt()
    {
        isHurt = true;
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }

    IEnumerator Death()
    {
        contadorVidas.text ="0"+vidas--;
        yield return new WaitForSeconds(1f);
        isDead = false;
    }
}
