using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowth : MonoBehaviour
{
    public float timeToLive;

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
//            Instantiate("hogweed");
	    print("growth done");
            Destroy(this.gameObject);
        }
    }
}
