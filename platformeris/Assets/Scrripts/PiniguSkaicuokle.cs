using UnityEngine;
using UnityEngine.UI;

public class PiniguSkaicuokle : MonoBehaviour
{
    private Text coinText;
    private string coinLabel = "Pinigu: ";
    private string gerPab = "Sveikiname!";

    private const int sk = 14;

    private void Reset()
    {
        coinText = GetComponent<Text>();
    }

    private void Awake()
    {
        if (coinText == null)
        {
            coinText = GetComponent<Text>();
        }
    }

    private void Update()
    {
        if (coinText == null)
        {
            return;
        }

        int pinigai = GameData.MonetuSkIsVisoGautu;
        if (pinigai/2 >= sk)
        {
            coinText.text = gerPab;
            UnityEngine.Time.timeScale = 0f;
        }
        else
        {
            coinText.text = coinLabel + pinigai/2;
        }
    }
}
