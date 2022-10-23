using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BreathingLamp : MonoBehaviour
{
    public Light2D light2D;
    public float speed;
    public float min = 5;
    public float max= 10;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        light2D.pointLightOuterRadius = Mathf.Abs(Mathf.Sin(timer += Time.deltaTime*speed))*(max-min)+min;
    }
}
