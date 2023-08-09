using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECamera : MonoBehaviour
{
    public

float

 sensX;
    public

float

 sensY;
    // ѕеременна€ под направление, хранит в себе полный набор координат
    public

Transform

 orientation;
    // ѕеременные ткущего поворота, не целые


    float

     xRotation;


    float

     yRotation;

    // ѕри начале работы скрипта
    private void Start()
    {
        // блокируем  урсор и делаем его невидимым
        Cursor.

lockState

= CursorLockMode.

Locked

;
        Cursor.

visible

=

false

;
    }
    // ѕосто€нно при работе
    private void

Update

()
    {
        //записываем координаты с мышки.
        //Ќе забываем про независимость от кадров и умножение на чувствительность.
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.

deltaTime

*

sensX

;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.

deltaTime

*

sensY

;

        //»змен€ем повороты осей и ограничиваем значение от -90 до 90 (float число)
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.

Clamp

(xRotation,

-90f

,

90f

);

        //”станавливаем повороты при помощи создани€ направление при помощи Quaternion


        transform

        .

        rotation

        = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.

rotation

= Quaternion.Euler(0, yRotation, 0);
    }}
