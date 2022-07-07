using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personagem : MonoBehaviour
{
    public float Velocidade = 10;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public GameObject FundoOpaco;
    public bool Vivo;
    private Vector3 direcao;
    private Animator animatorJogador;
    private Rigidbody rigidbodyJogador;

    void Start()
    {
        animatorJogador = GetComponent<Animator>();
        rigidbodyJogador = GetComponent<Rigidbody>();
        Time.timeScale = 1;
        Vivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        float eixo_x = Input.GetAxis("Horizontal");
        float eixo_z = Input.GetAxis("Vertical");
        direcao = new Vector3(eixo_x,0,eixo_z);

        if(direcao != Vector3.zero){
            animatorJogador.SetBool("move",true);
        }else{
            animatorJogador.SetBool("move",false);
        }
        if(Vivo == false){
            if(Input.GetButtonDown("Fire1")){
                SceneManager.LoadScene("game");
            }
        }
    }
    void FixedUpdate() {
        //movimentação
        rigidbodyJogador.MovePosition(
        rigidbodyJogador.position + 
        (direcao*Velocidade*Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin,raio.direction*100, Color.red);

        RaycastHit impacto;
        if(Physics.Raycast(raio, out impacto, 100, MascaraChao)){
            Vector3 PosicaoMiraJogador = impacto.point - transform.position;
            PosicaoMiraJogador.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(PosicaoMiraJogador);
            rigidbodyJogador.MoveRotation(novaRotacao);
        }
    }
}
