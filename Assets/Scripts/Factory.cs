using UnityEngine;

public class Factory : MonoBehaviour
{
    public int StoredProduct { get; private set; }
    public int MaxStorage { get; private set; }

    private Stats stats;

    private void OnEnable()
    {
        stats = FindAnyObjectByType<Stats>();
    }

    public void IncreaseStoredProduct(int value)
    {
        int spaceLeft = MaxStorage - StoredProduct;
        int amountToVariable1 = Mathf.Min(value, spaceLeft);

        StoredProduct += amountToVariable1;

        int excess = value - amountToVariable1;
        stats.IncreaseBalance(excess);
    }

    public void DecreaseStoredProduct(int value)
    {
        StoredProduct -= value;
    }

    public void IncreaseMaxStorage(int value)
    {
        MaxStorage += value;
    }
}
