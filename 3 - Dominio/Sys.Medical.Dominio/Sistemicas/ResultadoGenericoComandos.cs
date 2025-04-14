namespace Atividade01.Dominio.Sistemicas
{
    public class ResultadoGenericoComandos
    {
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
        public object? Dados { get; set; }

        public ResultadoGenericoComandos(bool sucesso, string mensagem, object? dados = null)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
            this.Dados = dados;
        }

        public static ResultadoGenericoComandos Ok(object? dados = null)
        {
            return new ResultadoGenericoComandos(true, "Sucesso ao realizar operacão", dados);
        }

        public static ResultadoGenericoComandos Erro(object? dados = null)
        {
            return new ResultadoGenericoComandos(false, "Erro ao realizar operacão", dados);
        }

        public static ResultadoGenericoComandos ErroLogin(object? dados = null)
        {
            return new ResultadoGenericoComandos(false, "Usuário ou senha inválidos", dados);
        }
    }
}
