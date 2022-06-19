namespace cpf_validator.Domain.Validation
{
    public static class Cpf
    {
        public static int ObtainValidationDigit(this List<int> arrayValue, int constant)
        {
            int digitResult = 0;
            int sumOfDigits = 0;

            foreach (int digit in arrayValue)
            {
                sumOfDigits += digit * constant;
                constant -= 1;
            }

            var modOfDigit = sumOfDigits % 11;
            if (modOfDigit > 1)
            {
                digitResult = 11 - modOfDigit;
            }

            return digitResult;
        }
    }
}
