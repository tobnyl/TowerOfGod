using UnityEngine;
using System.Collections;

public class AudioSourceExtended : MonoBehaviour
{
    public float Duration { get; set; }

    void Start()
    {
        Invoke("Destroy", Duration);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}