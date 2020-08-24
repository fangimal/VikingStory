using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public bool scrolling, paralax;

    public float backroundSize; //Размер бэкграунда
    public float paralaxSpeed;

    private Transform cameraTransform; //Положенгие камеры
    private Transform[] layers; //Количество используемых картинок
    private float viewZone = 10; //Область видимости самой камеры
    private int leftIndex, rightIndex; //Когда мы будем сдвигаться максимум в право и в лево

    private float lastCameraX;

    void Start()
    {

        cameraTransform = Camera.main.transform; //Положение текущей камеры
        lastCameraX = cameraTransform.position.x;

        layers = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1; // со 2 картинки начнём
    }

    private void Update()
    {
        if (paralax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * paralaxSpeed);
        }

        lastCameraX = cameraTransform.position.x;

        if (scrolling)
        {

            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            {
                ScrollLeft();
            }
            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            {
                ScrollRight();
            }
        }
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backroundSize);
        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0) //Всегда будем находится на 2-ой картинке
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }


}
