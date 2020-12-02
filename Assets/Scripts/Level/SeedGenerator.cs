using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour
{
    public GameObject seedPrefab;
    public List<Vector3> spawnPoints;
    public float probToSpawn = 1f;
    public float coolDownLength = 5.0f;

    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        coolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPoints != null && spawnPoints.Count > 0)
        {
          if (coolDown <= 0.0f)
          {
              if (Random.Range(0.0f, 100.0f) < probToSpawn)
              {
                  Instantiate(seedPrefab, spawnPoints[Random.Range(0, spawnPoints.Count -1)], Quaternion.identity);
                  coolDown = coolDownLength;
              }
          }
          else
          {
            coolDown -= Time.deltaTime;
          }
        }
    }
}
