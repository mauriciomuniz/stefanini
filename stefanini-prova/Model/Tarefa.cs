using System.ComponentModel.DataAnnotations.Schema;

namespace stefanini_prova.Model
{
    [Table("Tarefas")]
    public class Tarefa : Basis
    {     
        public string? Title { get; set; }
        public string? Description { get; set; }
        public StatusTarefa? Status { get; set; } = StatusTarefa.Nao_Iniciado;
    }
}
