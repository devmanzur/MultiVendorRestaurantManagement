namespace Common.Invariants
{
    public enum ContractStatus
    {
        Registered,
        Unregistered,
        Expired,
        Invalid
    }

    public static class ContractStatusHelper
    {
        public static ContractStatus ConvertToContractStatus(string item)
        {
            if (string.IsNullOrEmpty(item)) return ContractStatus.Invalid;
            switch (item.ToLowerInvariant())
            {
                case "registered":
                    return ContractStatus.Registered;
                case "unregistered":
                    return ContractStatus.Unregistered;
                case "expired":
                    return ContractStatus.Expired;
                default:
                    return ContractStatus.Invalid;
            }
        }
    }
}