﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int hogweedSeeds = 0;
    public int cherrySeeds = 0;
    public int potatoSeeds = 0;
    public seedTypes currentSeed;
    public GameObject growthPrefab;

    public List<Shooter> weapons;
    public Shooter currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        currentSeed = seedTypes.hogweed;
        foreach (Shooter w in weapons)
        {
            w.setCurrent(false);
        }
        currentWeapon.setCurrent(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cycleWeapons()
    {
        currentWeapon.setCurrent(false);
        int curIndex = weapons.IndexOf(currentWeapon);
        curIndex = (curIndex+1) % weapons.Count;
        currentWeapon = weapons[curIndex];
        currentWeapon.setCurrent(true);
    }

    public void Shoot()
    {
        currentWeapon.Shoot();
    }

    public void gainSeeds(seedTypes type)
    {
        switch (type)
        {
            case seedTypes.hogweed:
                hogweedSeeds++;
                break;
            case seedTypes.cherry:
                cherrySeeds++;
                break;
            case seedTypes.potato:
                potatoSeeds++;
                break;
        }
    }

    public void plantSeed(seedTypes type)
    {
        bool haveSeeds = false;
	switch (type)
        {
            case seedTypes.hogweed:
                if (hogweedSeeds > 0)
                {
                    haveSeeds = true;
                    hogweedSeeds--;
                }
                break;
            case seedTypes.potato:
                if (potatoSeeds > 0)
                {
                    haveSeeds = true;
                    potatoSeeds--;
                }
                break;
            case seedTypes.cherry:
                if (cherrySeeds > 0)
                {
                    haveSeeds = true;
                    cherrySeeds--;
                }
                break;
        }

        if (haveSeeds)
        {
	    Vector3 newLocation = transform.position + new Vector3(0, -.5f, 0);
            SeedGrowth sg = Instantiate(growthPrefab, newLocation, Quaternion.identity).GetComponent<SeedGrowth>();
            sg.seedType = type;
        }
    }
}

public enum seedTypes { hogweed, cherry, potato};