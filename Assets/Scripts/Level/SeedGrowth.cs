using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowth : MonoBehaviour
{
    public float timeToLive;
    public seedTypes seedType;
    public GameObject hogweedEffect;
    public GameObject cherryEffect;
    public GameObject potatoEffect;

    private float currentTime;
    private Vector3 currPos;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
	currPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currPos += new Vector3(0f, 1f / timeToLive, 0f) * Time.deltaTime;
	transform.position = currPos;
        currentTime += Time.deltaTime;
        if (currentTime >= timeToLive)
        {
            Vector3 newPosition = transform.position + new Vector3(0, -.8f, 0);
            switch (seedType)
            {
            case seedTypes.hogweed:
                Instantiate(hogweedEffect, newPosition, Quaternion.identity);
                break;
            case seedTypes.potato:
                Instantiate(potatoEffect, newPosition, Quaternion.identity);
                break;
            case seedTypes.cherry:
                Instantiate(cherryEffect, newPosition, Quaternion.identity);
                break;
            }
            Destroy(this.gameObject);
        }
    }
}
