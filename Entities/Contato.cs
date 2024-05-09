namespace TodoApi.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Pendente,
        EmAndamento,
        Concluido
    }
}
