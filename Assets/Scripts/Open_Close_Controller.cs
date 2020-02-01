using UnityEngine;
using System.Collections;

public class Open_Close_Controller : MonoBehaviour
{

    public Transform anchor; // дверная петля
    public float distance = 20; // если игрок уходит на большую дистанцию - скрипт отключается, для оптимизации
    public bool isOpen = false; // на старте сцены дверь открыта?
    public float openAngle = 90;
    public float closeAngle = 0;
    public float smooth = 2;

    private Transform target;

    void Awake()
    {
        openAngle = Mathf.Abs(openAngle);
        closeAngle = Mathf.Abs(closeAngle);
        if (isOpen) anchor.localRotation = Quaternion.Euler(0, openAngle, 0);
        enabled = false;
    }

    void Update()
    {
        if (isOpen)
        {
            Quaternion rotation = Quaternion.Euler(0, openAngle, 0);
            anchor.localRotation = Quaternion.Lerp(anchor.localRotation, rotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, closeAngle, 0);
            anchor.localRotation = Quaternion.Lerp(anchor.localRotation, rotation, smooth * Time.deltaTime);
        }

        if (target)
        {
            float dis = Vector3.Distance(transform.position, target.position);
            if (dis > distance) enabled = false;
        }
    }

    public void Invert(Transform player)
    {
        target = player;
        isOpen = !isOpen;
    }
}