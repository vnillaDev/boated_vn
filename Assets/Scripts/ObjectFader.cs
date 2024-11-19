using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float fadeOpacity;
    public bool DoFade = false;


    private float defaultOpacity;
    Material material;


    private void Start()
    {
        material = GetComponent<Renderer>().material;
        defaultOpacity = material.color.a;
    }


    private void Update()
    {
        if (DoFade)
            FadeNow();
        else
            FadeReset();
    }


    private void FadeNow()
    {
        Color currentColor = material.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeOpacity, fadeSpeed * Time.deltaTime));

        material.color = smoothColor;
    }


    private void FadeReset()
    {
        Color currentColor = material.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, defaultOpacity, fadeSpeed * Time.deltaTime));

        material.color = smoothColor;
    }
}
