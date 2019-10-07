
namespace OnlineStore.Domain
{
    using System.ComponentModel;

    public enum OnlineState
    {
        [Description("Cancelled")]
        Cancelled,
        [Description("Pending Cancellation")]
        PendingCancellation,
        [Description("Active")]
        Active,
        [Description("Pending Activation")]
        PendingActivation,
        [Description("Recorded")]
        Recorded
    }
}
