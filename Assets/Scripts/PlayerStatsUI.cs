using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text rangeText;
    [SerializeField] private TMP_Text attackSpeedText;
    [SerializeField] private TMP_Text stepsText;
    [SerializeField] private TMP_Text killCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        Refresh();
    }

    private void Refresh()
    {
        int health = 100;
        
        float attackRange = 2;
        float attackSpeed = 1f;
        int steps = 1;
        int killCount = 0;
        
        healthText.text = $"Health: {health}";
        rangeText.text = $"Attack Range: {attackRange}";
        attackSpeedText.text = $"Attack speed: {attackSpeed}";
        stepsText.text = $"Steps: {steps}";
        killCountText.text = $"kill count: {killCount}";
        
    }
    
}
