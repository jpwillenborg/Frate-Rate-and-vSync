using UnityEngine;


public class ColorByHeight : MonoBehaviour
{
    public Color bottomColor;
    public Color topColor;
    public float minHeight;
    public float maxHeight;


    void Update()
    {
        float heightPercent = Mathf.InverseLerp(minHeight, maxHeight, transform.position.y);
        Color materialColor = Color.Lerp(bottomColor, topColor, heightPercent);
        GetComponent<Renderer>().material.color = materialColor;
    }
}