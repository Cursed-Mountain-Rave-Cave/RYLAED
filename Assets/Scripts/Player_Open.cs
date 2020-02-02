using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class Player_Open : MonoBehaviour
{
    int pillsCount = 0;
    int maxPillsCount = 4;
    public float doorDistance = 3; // в приделах этой дистанции дверь будет доступна
    public float pillDistance = 3; // в приделах этой дистанции дверь будет доступна
    public string doorTag = "Door"; // тег двери
    public string pillTag = "Pill"; // тег колёс
    public KeyCode key = KeyCode.F; // клавиша управления
    private float time;
    private Camera cam;

    void Start() 
    {
        time = Time.time;
    }
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
            if (Physics.Raycast(ray, out hit, doorDistance, ~(1<<9)))
            {
                if (hit.collider.tag == doorTag)
                {
                    hit.transform.GetComponent<Open_Close_Controller>().enabled = true;
                    hit.transform.GetComponent<Open_Close_Controller>().Invert(transform);
                }
            }
            if (Physics.Raycast(ray, out hit, pillDistance, ~(1<<9)))
            {
                if (hit.collider.tag == pillTag)
                {
                    Destroy(hit.transform.gameObject);
                    pillsCount++;
                    if(pillsCount >= maxPillsCount){
                        SceneManager.LoadScene("FinalMenu");
                        GlobalParams.record = Time.time - time;
                    }
                }
            }
        }
    }
}