using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChSelectMenu : MonoBehaviour
{
    public void Start2PlayerGame()
    {
        SceneManager.LoadScene("2PlayerGameScene"); 
    }

    public void Start3PlayerGame()
    {
        SceneManager.LoadScene("3PlayerGameScene"); 
    }

    public void Start4PlayerGame()
    {
        SceneManager.LoadScene("4PlayerGameScene"); 
    }
}