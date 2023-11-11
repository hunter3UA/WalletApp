using WalletApp.Application.DTO;

namespace WalletApp.Application.MapperProfiles;

public static class AccountInfoMapper
{
    public static AccountInfoDTO MapToAccountInfoDTO(decimal CardBalance, decimal Available, string DailyPoints, string PaymentDue)
    {
        return new AccountInfoDTO(CardBalance, Available, DailyPoints, PaymentDue);
    }
}