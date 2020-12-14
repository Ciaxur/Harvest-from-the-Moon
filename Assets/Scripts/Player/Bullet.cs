using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // External Settings
    public int damage = 1;
    public bool persist = false;

    void Start() {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        if (source != null) {
          source.volume = SettingsManager.Instance.soundsVolume;
          source.mute = SettingsManager.Instance.soundsMuted;
          source.Play();
          print("AudioSource Found");
        }
    }

    void OnTriggerEnter(Collider other) {
        // Collided with Enemy
        if (other.tag == "Enemy") {
            Attributes attrb = other.GetComponent<Attributes>();
            attrb.inflictDamage(damage);
        }

        // DIE
        if (!persist) {
            Destroy(gameObject);
        }
    }
    
}
