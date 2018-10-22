using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    // Use this for initialization
    public float backgroundSize;


    public float paralxSpead;
    public bool scrolling, paralax;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int righIndex;


    private float lastCameraX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);

        leftIndex = 0;
        righIndex = layers.Length - 1;
    }

    private void Update()
    {
        if (paralax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * paralxSpead);
        }
            lastCameraX = cameraTransform.position.x;

        if (scrolling)
        {
            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
                ScrollLeft();
            if (cameraTransform.position.x > (layers[righIndex].transform.position.x - viewZone))
                ScrollRigh();
        }
        
    }

    private void ScrollLeft()
    {
        int lastRight = righIndex;
        layers[righIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = righIndex;
        righIndex--;
        if (righIndex < 0)
            righIndex = layers.Length - 1;
    }

    private void ScrollRigh()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[righIndex].position.x + backgroundSize);
        righIndex = leftIndex;
        leftIndex++;
        if (leftIndex < 0)
            leftIndex = layers.Length - 1;

    }
}
