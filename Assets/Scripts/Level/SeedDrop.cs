using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDrop : MonoBehaviour
{
    public float rotationSpeed = .5f;
    public GameObject growthPrefab;

    private Vector3 currentEulerRot;

    // Start is called before the first frame update
    void Start()
    {
        currentEulerRot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject other = coll.gameObject;
        if (other.tag == "Player")
        {
            other.SendMessage("gainSeeds", "hogweed");
	    Vector3 newLocation = transform.position + new Vector3(0, -1.9f, 0);
            Instantiate(growthPrefab, newLocation, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
