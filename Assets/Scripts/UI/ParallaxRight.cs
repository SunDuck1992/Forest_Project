using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]

public class ParallaxRight : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _imagePositionX;
    private RawImage _image;

    void Start()
    {
        _image = GetComponent<RawImage>();
    }

    void Update()
    {
        _imagePositionX += _speed * Time.deltaTime * -1;

        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
