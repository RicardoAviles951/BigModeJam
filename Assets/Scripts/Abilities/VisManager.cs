using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisManager : MonoBehaviour
{
    private ParticleSystem _system;
    public float radius;
    public float noiseStrength = 0;
    public float noiseFrequency = 0;
    public float noiseScrollSpeed = 0;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        _system = GetComponent<ParticleSystem>();
        var ShapeModule = _system.shape;
        ShapeModule.radius = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var ShapeModule = _system.shape;
        ShapeModule.radius = radius;

        var MainModule = _system.main;
        MainModule.startColor = color;

        var NoiseModule = _system.noise;
        NoiseModule.frequency   = noiseFrequency;
        NoiseModule.strength    = noiseStrength;
        NoiseModule.scrollSpeed = noiseScrollSpeed;
    }
}
