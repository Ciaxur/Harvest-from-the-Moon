using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDrop : MonoBehaviour
{
    public float rotationSpeed = .5f;

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
            other.SendMessage("gainSeeds", seedTypes.hogweed);
            Destroy(this.gameObject);
        }
    }
}
