using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    // Кватернионы (Quaternion) используются для вращения объектов в Unity.
    // Кватернион - это угол и ось вращения.

    // Порядок кватернионов имеет значение!!!
    // При умножении кватернионов: первый кватернион становится точкой отсчёта второго кватерниона.


    // объявление переменных
    Quaternion originRotation;
    float Angle;
    float MouseX;
    float MouseY;
    
    void Start()
    {
        // запоминание изначального положения
        originRotation = transform.rotation;
        // блокировка курсора
        Cursor.lockState = CursorLockMode.Locked;
    }

    // FixedUpate вызывается каждые 0.002 секунды (Лучше, чем просто Update, 
    // вызов которого напрямую зависит от мощности устройства)
    void FixedUpdate()
    {
        // координаты положения мыши
        MouseX += Input.GetAxis("Mouse X")*3;
        MouseY -= Input.GetAxis("Mouse Y")*3;
        
        MouseY = Mathf.Clamp(MouseY, -60, 60);
    
        Quaternion rotationY = Quaternion.AngleAxis(MouseX, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(MouseY, Vector3.right);
        // изменение наклона камеры
        transform.rotation = originRotation * rotationY * rotationX;    

        // изменение положения камеры в пространстве
        if (Input.GetKey(KeyCode.W)){
            transform.position += transform.forward / 9;
        }

        if (Input.GetKey(KeyCode.S)){
            transform.position -= transform.forward / 9;
        }

        if (Input.GetKey(KeyCode.D)){
            transform.position += transform.right / 9;
        }

        if (Input.GetKey(KeyCode.A)){
            transform.position -= transform.right / 9;
        }

        if (Input.GetKey(KeyCode.LeftShift)){
            transform.position += transform.up / 9;
        }

        if (Input.GetKey(KeyCode.LeftControl)){
            transform.position -= transform.up / 9;
        }
    }
}
