namespace Publisher {
    public class GoldAmountChangedMessage {
        public int GoldAmount { get; }

        public GoldAmountChangedMessage(int goldAmount) {
            GoldAmount = goldAmount;
        }
    }
}