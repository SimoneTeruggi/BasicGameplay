using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;

    public Color newColorAtStart = new Color(0.5f, 1.0f, 0.3f, 0.4f);

    public Vector3 newPosAtStart = new Vector3(3, 4, 1);
    public Vector3 newScaleAtStart = Vector3.one * 1.3f;

    public float rotateSpeedX = 10.0f;
    public float rotateSpeedY = 0.0f;
    public float rotateSpeedZ = 0.0f;

    public float startDelay = 2.0f;
    public float continuousDelay = 2.0f;

    void Start()
    {
        //Changese cube position at start
        transform.position = newPosAtStart;
        //Changes cube scale at start
        transform.localScale = newScaleAtStart;

        //Get cube material and changes color at start
        material = Renderer.material;
        material.color = newColorAtStart;

        //Changes cumbe color over time by InvokeRepeating
        InvokeRepeating("ColorChanger", startDelay, continuousDelay);

        //Changes cube scale and ratio over time by InvokeRepeating
        InvokeRepeating("ScaleChanger", startDelay, continuousDelay);

        //Changes cube position over time by InvokeRepeating
        InvokeRepeating("PositionChanger", startDelay, continuousDelay);
    }
    
    void Update()
    {

        transform.Rotate(rotateSpeedX * Time.deltaTime, rotateSpeedY * Time.deltaTime, rotateSpeedZ * Time.deltaTime);
    }

    private void ColorChanger()
    {
        float randColorValue = Random.Range(0.0f, 1.0f);
        float randColorValue2 = Random.Range(0.0f, 1.0f);
        float randColorValue3 = Random.Range(0.0f, 1.0f);
        float randTransp = Random.Range(0.0f, 1.0f);

        Color randColor = new Color(randColorValue, randColorValue2, randColorValue3, randTransp);
        material.color = randColor;
    }

    private void ScaleChanger()
    {
        float randScaleX = Random.Range(0.0f, 3.0f);
        float randScaleY = Random.Range(0.0f, 3.0f);
        float randScaleZ = Random.Range(0.0f, 3.0f);

        transform.localScale = new Vector3(randScaleX, randScaleY, randScaleZ);
    }

    private void PositionChanger()
    {
        float posX = Random.Range(0, 5);
        float posY = Random.Range(0, 5);
        float posZ = Random.Range(0, 5);

        transform.position = new Vector3(posX, posY, posZ);
    }

}
