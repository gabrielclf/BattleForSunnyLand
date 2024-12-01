using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    [SerializeField] private Transform target; //alvo da camera

    [SerializeField] private Vector3 offset; // controlar posição da camera

    [SerializeField] [Range(0.01f,1f)] private float smoothSpeed = 0.125f;


    private Vector3 velocidade = Vector3.zero;// (0,0,0)
    private void LateUpdate() {
        Vector3 posicaoDestino = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, posicaoDestino, ref velocidade,smoothSpeed);
    }
}
