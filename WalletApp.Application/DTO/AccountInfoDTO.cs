namespace WalletApp.Application.DTO;

public sealed record AccountInfoDTO(decimal CardBalance, decimal Available, string DailyPoints, string PaymentDue);