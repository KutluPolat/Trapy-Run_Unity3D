using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private bool _firstTime = true;

    public GameObject GameOverObject;


    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Minions.Attack && _firstTime)
        {
            _firstTime = false;
            GameOverObject.SetActive(true);
        }
    }

    public void Restart()
    {
        Minions.Attack = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
