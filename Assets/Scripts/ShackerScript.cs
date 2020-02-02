using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackerScript : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 10*Mathf.Sin(Time.time - time));
    }
}
