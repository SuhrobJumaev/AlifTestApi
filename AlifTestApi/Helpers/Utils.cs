using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlifTestApi.Helpers
{
    public static class Utils
    {
        public const int PhoneProduct = 1;
        public const int ComputerProduct = 2;
        public const int TVProduct = 3;

        public const int MaxPhoneRange = 9;
        public const int MaxComputerRange = 12;
        public const int MaxTVRange = 18;

        public const decimal PhonePercent = 3m;
        public const decimal ComputerPercent = 4m;
        public const decimal TVPercent = 5m;



        public const string ProductIdRequired = "ProductId is required.";
        public const string PriceRequired = "Price is required.";
        public const string PhoneNumberRequired = "PhoneNumber is required.";
        public const string CreditRangeRequired = "CreditRange is required.";
        public const string InvalidProductId = "Invalid ProductId. Underfined productId.";
        public const string InvalidPrice = "Invalid Price";
        public const string InvalidPhoneNumber = "Invalid phoneNumber";

        public const string SmsSenderName = "TechMarket";

        public static string SmsSubscriberTextSuccessRu = "Ваша покупка в рассрочку прошла успешно. Стоимость товара - {0}, проценты - {1}, на {2} месяцев.";


    }
}
