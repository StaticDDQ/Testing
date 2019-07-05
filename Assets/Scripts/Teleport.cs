using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool overlap = false;

    private void Update()
    {
        if (overlap)
        {
            Vector3 toPlayer = player.position - transform.position;
            float dotProd = Vector3.Dot(transform.up, toPlayer);

            // Move across
            if(dotProd < 0)
            {
                float rotDiff = Quaternion.Angle(transform.rotation, receiver.rotation);
                rotDiff += 180;
                player.Rotate(Vector3.up, rotDiff);

                Vector3 posOffset = Quaternion.Euler(0f, rotDiff, 0f) * toPlayer;
                player.position = receiver.position + posOffset;

                overlap = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            overlap = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            overlap = false;
        }
    }
}
