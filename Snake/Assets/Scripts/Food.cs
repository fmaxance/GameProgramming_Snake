using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] Collider2D zoneSpawn;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFood();
    }

    void SpawnFood()
    {
        Bounds bounds = zoneSpawn.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        transform.position = new Vector2 (x, y);
    }

    private void OnTriggerEnter2D()
    {
        SpawnFood();
        if (gameObject.tag == "PoisonedFood")
        {
            SpawnFood();
        }
    }
}
