using UnityEngine;
using UnityEngine.UI;

public class GAMEOVER : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text coinText;
    
    void Start()
    {
        gameOverPanel.SetActive(false);
    }
    
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        coinText.text = "PINIGU: " + GameData.MonetuSkIsVisoGautu / 2;
    }
}