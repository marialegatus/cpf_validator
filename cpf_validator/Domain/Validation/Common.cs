namespace cpf_validator.Domain.Validation
{
    public static class Common
    {
        public static string GetOnlyNumbers(string value)
        {
            return new String(value.Where(x => Char.IsDigit(x)).ToArray());
        }

        public static bool CheckIfCharactersAreTheSame(string value)
        {
            var valueLength = value.Length;

            if (value.Distinct().Count() == valueLength)
            {
                return true;
            }

            return false;
        }
    }
}
