using UnityEngine;
using UnityEngine.UI;

public class FoodUp : MonoBehaviour
{
    public Text text;
    public int foodScore;

    // Update is called once per frame
    void Update()
    {
        text.text = "+" + foodScore.ToString("0");
    }
}
