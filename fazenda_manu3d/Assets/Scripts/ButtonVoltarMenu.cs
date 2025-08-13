using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonVoltarMenu : MonoBehaviour
{
    [SerializeField] private string nomeMenu;

    public void AbrirMenu()
    {
        SceneManager.LoadScene(nomeMenu);
    }
}
