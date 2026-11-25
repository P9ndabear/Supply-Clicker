using UnityEngine;

public class ClickUpgrade : MonoBehaviour
{
    public int level { get; private set; }
    public int basePrice { get; private set; } = 20;

    private void Start()
    {
        level = 1;
    }

    public void IncreaseLevel()
    {
        Stats stats = FindAnyObjectByType<Stats>();
        stats.DecreaseBalance(basePrice * (int)Mathf.Pow(3, level - 1));

        level += 1;
    }

    public void HandleClick()
    {
        GetComponentInParent<Factory>().IncreaseStoredProduct(level);
    }
}