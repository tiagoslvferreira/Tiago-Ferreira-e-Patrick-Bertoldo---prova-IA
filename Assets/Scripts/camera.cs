using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target; // Referência ao transform do jogador
    public float smoothSpeed = 0.125f; // Velocidade de interpolação suave
    public Vector3 offset; // Distância entre a câmera e o jogador
    
     private void FixedUpdate()
    {
        if (target != null) 
        {
            // Calcula a posição desejada da câmera com base na posição do jogador e no offset
            Vector3 desiredPosition = target.position + offset;

            // Usa a função Vector3.Lerp para suavizar a transição da posição atual da câmera para a posição desejada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Atualiza a posição da câmera
            transform.position = smoothedPosition;
        }
    }
}
