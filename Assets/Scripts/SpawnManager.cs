using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    public int maxPlatforms = 20; // quantidade de plataformas que serão geradas
    public GameObject platform; // objeto que será vinculado ao objeto Ground (plataforma)
    public float horizontalMin = 7.5f; // distância mínima entre uma plataforma e outra
    public float horizontalMax = 10f; // distância máxima entre uma plataforma e outra
    public float verticalMin = 1f; // altura mínima entre uma plataforma e outra
    public float verticalMax = 2f; // altura máxima entre uma plataforma e outra


    private Vector2 originPosition; // vetor que receberá a posição original do objeto


    void Start()
    {

        originPosition = transform.position;
        Spawn();

    }

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);   // Quaternion livre de rotação
            originPosition = randomPosition;
        }
    }

}