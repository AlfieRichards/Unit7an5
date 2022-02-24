using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public void Playsnd()
    {
        FindObjectOfType<AudioManager>().Play("select");
    }
}
