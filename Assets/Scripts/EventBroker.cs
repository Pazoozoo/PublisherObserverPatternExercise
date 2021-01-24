using System;

public static class EventBroker {
    public delegate void GoldChangeDelegate(int newGoldAmount);
    public static GoldChangeDelegate OnGoldAmountChanged;
    public static Action OnRestartGame;
}
