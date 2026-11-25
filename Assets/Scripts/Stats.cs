using UnityEngine;

public class Stats : MonoBehaviour
{
    public int balance { get; private set; }

    public void IncreaseBalance(int value) {
        balance += value;
    }

    public void DecreaseBalance(int value) {
        balance -= value;
    }
}
