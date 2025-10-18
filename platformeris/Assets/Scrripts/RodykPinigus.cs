using UnityEngine;
using UnityEngine.UI;

public class RidykPinigus : MonoBehaviour
{
    public Text coinText;
    
    void Update()
    {
        coinText.text = "Pinigu: " + GameData.MonetuSkIsVisoGautu;
    }
}