using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float Velocidade = 30;
    public float BalaLonge = 60;
    public GameObject Jogador;
    private Rigidbody rigidbodyBala;
    void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();
        Jogador = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        if(distancia>BalaLonge){
            Destroy(gameObject);
        }
        rigidbodyBala.MovePosition(
            rigidbodyBala.position + 
            transform.forward*Velocidade*Time.deltaTime
        );
    }
    void OnTriggerEnter(Collider objetoDeColisao) {
        if (objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
        }
        Destroy(gameObject);
    }
}
