namespace Domain
{
    public enum EPaymentMethod
    {
        PixOne = 0,
        PixTwo = 1,
        CreditCard = 2,
        Billet = 3
    }

    public class Payment
    {
        public EPaymentMethod PaymentMethod { get; set; }
    }
}