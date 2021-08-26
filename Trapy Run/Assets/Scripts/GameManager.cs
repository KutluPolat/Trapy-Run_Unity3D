using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private bool _firstTime = true;

    public GameObject GameOverObject, WinObject, Confettis;
    public TextMeshProUGUI LevelText;

    private void Awake()
    {
        LevelText.text = "Level: " + PlayerPrefs.GetInt("LevelText").ToString();

        if (PlayerPrefs.GetInt("Level") == 0)
            PlayerPrefs.SetInt("Level", 1);

        if (PlayerPrefs.GetInt("LevelText") == 0)
            PlayerPrefs.SetInt("LevelText", 1);

        LoadScene();
    }

    private void Start()
    {
        _player = GameObject.Find("PlayerCapsule");
    }

    private void Update()
    {
        if (_firstTime)
        {
            if (Minions.Attack || _player.transform.position.y < -2)
            {
                _firstTime = false;
                GameOverObject.SetActive(true);
            }

            if (Player.WinMode)
            {
                _firstTime = false;
                Confettis.SetActive(true);
                WinObject.SetActive(true);
            }
        }
    }

    private void LoadScene()
    {
        if (PlayerPrefs.GetInt("Level") == 1 && SceneManager.GetActiveScene().name != "FirstLevel")
            SceneManager.LoadScene("FirstLevel");

        if (PlayerPrefs.GetInt("Level") == 2 && SceneManager.GetActiveScene().name != "SecondLevel")
            SceneManager.LoadScene("SecondLevel");

        if (PlayerPrefs.GetInt("Level") == 3 && SceneManager.GetActiveScene().name != "ThirdLevel")
            SceneManager.LoadScene("ThirdLevel");
    }

    private void ResetBooleans()
    {
        Minions.Attack = false;
        Player.RescueMode = false;
        Player.WinMode = false;
    }

    public void Restart()
    {
        ResetBooleans();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        ResetBooleans();
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        PlayerPrefs.SetInt("LevelText", PlayerPrefs.GetInt("LevelText") + 1);

        if (PlayerPrefs.GetInt("Level") == 4)
            PlayerPrefs.SetInt("Level", 1);

        LoadScene();
    }
}
