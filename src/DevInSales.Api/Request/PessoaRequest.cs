namespace DevInSales.Api.Request
{
    public class PessoaRequest
    {
        public PessoaRequest()
               : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public PessoaRequest(string nome, string cpf, string funcao)
        {
            Nome = nome;
            CPF = cpf;
            Funcao = funcao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Funcao { get; set; }
    }
}
