using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StorageUpgrade : MonoBehaviour
{
    public int level { get; private set; }
    public int storage { get; private set; }
    public int basePrice { get; private set; } = 100;

    private void Start()
    {
        level = 1;
    }

    public void IncreaseLevel()
    {
        Stats stats = FindAnyObjectByType<Stats>();
        stats.DecreaseBalance(basePrice * (int)Mathf.Pow(2, level - 1));

        level += 1;
        storage += 50;
    }
}
