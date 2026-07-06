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
    [Header("MoveStats")]
    [SerializeField]  private TMP_Text walkSpeedText;
    [SerializeField]  private TMP_Text sprintSpeedText;
    
    [SerializeField] private PlayerMovement playerMovement;
    
    
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
        walkSpeedText.text = $"Walk speed: {playerMovement.WalkSpeed}";
        sprintSpeedText.text = $"Sprint speed: {playerMovement.SprintSpeed}";

    }
    
}
