using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using planetScript;
using Random = UnityEngine.Random;
using CustomMeteor;

public class GenerateSolarSystem : MonoBehaviour
{
    [SerializeField] private int planetCant;
    [SerializeField] private float sizeSolarSystem;
    [SerializeField] private float sizeSun;
    [SerializeField] private NewPlanet prefab;
    private Meteor gObject;
    private float timer;
    [SerializeField] private Meteor prefabMeteor;
    [SerializeField] private int meteorAmount;
    private float meteorFallTime = 8f;

    [SerializeField] private List<Material> planetMaterials;
    private int materialSelected;

    private float oscilationSpeed;
    private float oscillationRadius;
    private float oscillationAngle;
    private float rotationSpeed;
    private float localScale;

    void Start()
    {
        NewPlanet planet;

        planet = Instantiate(prefab, transform);
        rotationSpeed = Random.Range(0.1f, 4f);
        Vector3 tam = new Vector3(sizeSun, sizeSun, sizeSun);

        planet.Set(0f, 0f, 0f, rotationSpeed, tam, planetMaterials[0]);
        planet.SetLight();

        for (int i = 0; i < planetCant; i++)
        {
            planet = Instantiate(prefab, transform);

            oscilationSpeed = Random.Range(0.1f, 4f);
            oscillationAngle = Random.Range(0.0f, 10f);
            oscillationRadius = Random.Range(sizeSun + 10f, sizeSolarSystem);
            rotationSpeed = Random.Range(0.1f, 6f);
            localScale = Random.Range(0.1f, sizeSun - 8f);
            materialSelected = (int)Random.Range(1.0f, 9.0f);

            Vector3 tempScale = new Vector3(localScale, localScale, localScale);
            planet.Set(oscilationSpeed, oscillationRadius, oscillationAngle, rotationSpeed, tempScale, planetMaterials[materialSelected]);
            planet.SetTrail();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= meteorFallTime)
        {
            for (int i = 0; i < meteorAmount; i++)
            {
                gObject = Instantiate(prefabMeteor, new Vector3(Random.Range(-(sizeSolarSystem), sizeSolarSystem), 100f, Random.Range(-(sizeSolarSystem), sizeSolarSystem)), new Quaternion());
            }

            timer = 0.0f;
        }
    }
}
