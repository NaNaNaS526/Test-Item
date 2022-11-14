using System.ComponentModel;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCountText;
    public int scoreCountNumber;

    private void Update()
    {
        scoreCountText.text = scoreCountNumber.ToString();
    }
}