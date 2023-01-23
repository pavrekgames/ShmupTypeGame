using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    private float offset;
    private Material material;

    void Start()
    {
        material= GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
