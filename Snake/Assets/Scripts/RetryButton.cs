using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    public Button retryButton;
    // Start is called before the first frame update
    void Start()
    {
        retryButton.onClick.AddListener(PlayGame);
    }
    void PlayGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
