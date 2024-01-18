using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
    }
    void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
