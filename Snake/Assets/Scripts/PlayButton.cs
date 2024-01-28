using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button EasyButton;
    public Button MediumButton;
    public Button HardButton;
    // Start is called before the first frame update
    void Start()
    {
        EasyButton.onClick.AddListener(EasyGame);
        MediumButton.onClick.AddListener(MediumGame);
        HardButton.onClick.AddListener(HardGame);
    }
    void EasyGame()
    {
        SceneManager.LoadScene("GameEasy");
    }
    void MediumGame()
    {
        SceneManager.LoadScene("GameMedium");
    }
    void HardGame()
    {
        SceneManager.LoadScene("GameHard");
    }
}
