using UnityEngine;
using UnityEngine.UI;

public class AutoUpgrade : MonoBehaviour
{
    public int level { get; private set; }
    public int basePrice { get; private set; } = 500;
    private float timer = 0.0f;

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

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5)
        {
            GetComponentInParent<Factory>().IncreaseStoredProduct(level-1);

            timer = 0.0f;
        }
    }
}