using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject respawn;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Character character = collider.GetComponent<Character>();
            character.PlayAudioDie();
            character.Lives = 5;

            collider.transform.position = respawn.transform.position;
        }
    }

        
}

