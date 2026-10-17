using UnityEngine;
using TMPro;

public class GoldSystem : MonoBehaviour
{
    [SerializeField] public TMP_Text goldText;
    private float _totalGold = 400f;
    public float totalGold
    {
        get => _totalGold;
        set
        {
            if (_totalGold != value)
            {
                _totalGold = value;
                goldText.text = "Gold: " + _totalGold.ToString();
            }
        }
    }

    private void Start()
    {
        totalGold = _totalGold;
        goldText.text = "Gold: " + _totalGold.ToString();
    }
    
}


