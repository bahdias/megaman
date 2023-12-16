using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            // Quando o jogador colide com a moeda, marque-a como coletada.
            isCollected = true;

            // Desative a moeda.
            gameObject.SetActive(false);

            // Chame uma função para fazer a moeda reaparecer após 5 segundos.
            Invoke("RespawnCoin", 5.0f);
        }
    }

    private void RespawnCoin()
    {
        // Ative a moeda novamente.
        gameObject.SetActive(true);

        // Marque a moeda como não coletada.
        isCollected = false;
    }
}
