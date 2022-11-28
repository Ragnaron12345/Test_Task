using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldResistance : MonoBehaviour
{
    public int GoldResist = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Worker"))
        {
            GoldResist--;
            if (GoldResist == 0)
            {
                Destroy(gameObject, 2f);
            }
        }
    }
}