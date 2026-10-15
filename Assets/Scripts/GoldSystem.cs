using TMPro;
using UnityEngine;

public class GoldSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    public int totalGold = 10000;

    private void Update()
    {
        updateGold();
    }

    // update gold amount
    private void updateGold()
    {
        goldText.text = $"Gold: {totalGold}";
    }
}
