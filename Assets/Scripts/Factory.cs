using UnityEngine;

public class Factory : MonoBehaviour
{
    public int StoredProduct { get; private set; }

    private Stats stats;

    private void OnEnable()
    {
        stats = FindAnyObjectByType<Stats>();
    }

    public void IncreaseStoredProduct(int value)
    {
        GetComponentInChildren<StorageUpgrade>();

        int spaceLeft = GetComponentInChildren<StorageUpgrade>().storage - StoredProduct;
        int amountToVariable1 = Mathf.Min(value, spaceLeft);

        StoredProduct += amountToVariable1;

        int excess = value - amountToVariable1;
        stats.IncreaseBalance(excess);
    }

    public void DecreaseStoredProduct(int value)
    {
        StoredProduct -= value;
    }
}
