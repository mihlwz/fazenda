using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public GameObject projectilePrefab;
    public int vida = 3;
    public TMP_Text textLife;
    public int pontos = 0;
    public TMP_Text textPontos;
    public TMP_Text textMissao;
    private float larguraTela; // Largura da tela em unidades do mundo
    public float speedBoost = 20f;
    private float horizontalInput;
    

    void Start()
    {
        // Calcula a largura da tela em unidades do mundo
        larguraTela = Camera.main.orthographicSize * Camera.main.aspect * 2;
        
    }



    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        // movimenta o player para esquerda e direita a partir da entrada do usuário
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);


        // mantêm o player dentro dos limites do jogo (eixo x)
        float larguraPlayer = transform.localScale.x / 2; // Considera a largura do Player
        float leftLimit = -larguraTela / 2 + larguraPlayer;
        float rightLimit = larguraTela / 2 - larguraPlayer;


        if (transform.position.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }

        //Vector3 posicao = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        // dispara comida ao pressionar barra de espaço
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, posicao, projectilePrefab.transform.rotation);
        }*/

    }

    public void OnMoveEvent(InputAction.CallbackContext value)
    {
        horizontalInput = value.ReadValue<Vector2>().x;
    }

    public void OnFireEvent(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal")) // Verifica se colidiu com um objeto marcado como "Animal"
        {
            PerderVida();
        }
    }

     void PerderVida()
    {
        vida--;
        textLife.text = vida.ToString();

        if (vida <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void GanhaPonto()
    {
        pontos = pontos + 1;
        textPontos.text = pontos.ToString();
        Missao();
    }

    public void SpeedBoost()
    {
        // Aumenta a velocidade do jogador
        speed += speedBoost;
    }

    void Missao()
    {
        if(pontos == 10)
        {
            textMissao.text = "CONCLUÍDA!";
        }
    }

}


