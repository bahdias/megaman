using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour
{

    public Transform[] coinSpawns; //vetor de moedas por plataforma
    public GameObject coin; // objeto coin que será vinculado ao obejto Coin já criado

    // Use this for initialization
    void Start()
    {

        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < coinSpawns.Length; i++)
        {
            int coinFlip = Random.Range(0, 2); // random entre 3 valores
            if (coinFlip > 0)
                Instantiate(coin, coinSpawns[i].position, Quaternion.identity);
        }
    }

}