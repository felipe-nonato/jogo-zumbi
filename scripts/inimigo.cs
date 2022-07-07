using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{

    public GameObject Jogador;
    public float Velocidade = 3;
    private Rigidbody rigidbodyInimigo;
    private Animator animatorInimigo;
    void Start() {
        rigidbodyInimigo = GetComponent<Rigidbody>();
        animatorInimigo = GetComponent<Animator>();
        Jogador = GameObject.FindWithTag("Player");
        int geraTipo = Random.Range(1,28);
        transform.GetChild(geraTipo).gameObject.SetActive(true);
    }

    //Para rigidbody
    void FixedUpdate() 
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 direcao = Jogador.transform.position - rigidbodyInimigo.position;
        Quaternion rot = Quaternion.LookRotation(direcao);
        rigidbodyInimigo.MoveRotation(rot);
        if(distancia>2.8)
        {
        rigidbodyInimigo.MovePosition(
            rigidbodyInimigo.position + 
            (direcao.normalized*Velocidade*Time.deltaTime)
            );
            animatorInimigo.SetBool("estaPerto",false);

        }
        else
        {
            animatorInimigo.SetBool("estaPerto",true);
        }

    }

    void atacarJogador()
    {
        Jogador.GetComponent<personagem>().Vivo = false;
        Jogador.GetComponent<personagem>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<personagem>().FundoOpaco.SetActive(true);
        Time.timeScale = 0;
    }
}
