using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class Player_Open : MonoBehaviour
{

    public float distance = 5; // в приделах этой дистанции дверь будет доступна
    public string doorTag = "Door"; // тег двери
    public KeyCode key = KeyCode.F; // клавиша управления
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.tag == doorTag)
                {
                    hit.transform.GetComponent<Open_Close_Controller>().enabled = true;
                    hit.transform.GetComponent<Open_Close_Controller>().Invert(transform);
                }
            }
        }
    }
}