namespace cpf_validator.Application
{
    public class CpfAppService
    {
        public bool Validate(string cpf)
        {
            var cpfVO = new Domain.ValueObject.Cpf(cpf);
            if (!cpfVO.result)
            {
                throw new ArgumentException("CPF invalido");
            }

            return true;
        }
    }
}
