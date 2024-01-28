using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    [SerializeField] Collider2D zoneSpawn;
    Vector2 direction;
    List<Transform> segments = new List<Transform>();
    [SerializeField] Transform segmentPrefab;
    public AudioClip collisionSound;
    public AudioClip foodSound;
    public GameObject poisonedFoodPrefab;
    [SerializeField] Text scoreText; 
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("Score");
        UpdateScoreText();
        Time.timeScale = 0.25f;
        direction = Vector2.right;
        segments.Add(transform);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && direction.x != 0)
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && direction.x != 0)
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && direction.x != 0)
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direction.x != 0)
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && direction.y != 0)
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction.y != 0)
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && direction.y != 0)
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && direction.y != 0)
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }


        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);
    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Grow();
            AudioSource.PlayClipAtPoint(foodSound, transform.position);
            score++;
            UpdateScoreText();
            SpawnFood(poisonedFoodPrefab);
            PlayerPrefs.SetInt("Score", score); // Stocke le score dans PlayerPrefs
        }
        if (collision.gameObject.tag == "PoisonedFood")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }

    void SpawnFood(GameObject foodPrefab)
    {
        Bounds bounds = zoneSpawn.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
    public int GetScore()
    {
        return score;
    }
}
