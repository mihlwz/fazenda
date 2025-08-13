using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelConfirmacao;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            AbrirConfirmaçao();
        }
    }
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);

    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Application.Quit();
    }

    public void AbrirConfirmaçao()
    {
        painelConfirmacao.SetActive(true);
        painelMenuInicial.SetActive(false);   
    }

    public void AbrirMenu()
    {
        painelMenuInicial.SetActive(true);
        painelConfirmacao.SetActive(false);
    }
}
