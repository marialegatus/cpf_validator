using cpf_validator.Domain.Validation;

namespace cpf_validator.Domain.ValueObject
{
    public class Cpf
    {
        public string value { get; }
        public bool result { get; private set; }

        public Cpf(string value)
        {
            this.value = Common.GetOnlyNumbers(value);
            this.result = true;

            //CPF informado não possui números
            if (String.IsNullOrEmpty(this.value))
            {
                result = false;
                return;
            }

            //Tamanho do cpf informado inválido
            var cpfLength = this.value.Length;
            if (cpfLength < 11 || cpfLength > 11)
            {
                result = false;
                return;
            }

            //CPF possui todos os dígitos iguais
            if (Common.CheckIfCharactersAreTheSame(this.value))
            {
                result = false;
                return;
            }

            var cpfListTemp = this.value.Select(s => int.Parse(s.ToString())).ToList();
            var cpfList = cpfListTemp.Take(9).ToList();
            var cpfValidationDigits = cpfListTemp.Skip(9).ToList();

            var firstDigitResult = cpfList.ObtainValidationDigit(10);
            if (cpfValidationDigits[0] != firstDigitResult)
            {
                result = false;
                return;
            }

            cpfList.Add(firstDigitResult);

            var secondDigitResult = cpfList.ObtainValidationDigit(11);
            if (cpfValidationDigits[1] != secondDigitResult)
            {
                result = false;
                return;
            }
        }
    }
}
