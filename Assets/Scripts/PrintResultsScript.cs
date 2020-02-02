using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PrintResultsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    void Start()
    {
        var record =  GlobalParams.record;
        Debug.Log("Before: " + GlobalParams.onlineRecord);
        GlobalParams.onlineRecord = Mathf.Min(GlobalParams.onlineRecord, Mathf.Max((record - Random.Range(0.5f, 1.5f)), 0.00001f));
        text.text = "Your time: " + record + " c.\n\nBest online time: " + GlobalParams.onlineRecord + " c.";
        Debug.Log(GlobalParams.onlineRecord);
        text.fontSize = 40;
        text.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
