using System;

public static class EventBroker {
    public delegate void GoldChangeDelegate(int newGoldAmount);
    public static event GoldChangeDelegate OnGoldAmountChanged;
    public static event Action OnRestartGame;

    public static void InvokeOnGoldAmountChanged(int gold) {
        OnGoldAmountChanged?.Invoke(gold);
    }

    public static void InvokeOnRestartGame() {
        OnRestartGame?.Invoke();
    }
}
