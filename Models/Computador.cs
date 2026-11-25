using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputadoresMvc.Models;

[Table("Computadores", Schema = "dbo")]
public class Computador
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome.")]
    [StringLength(100, ErrorMessage = "O nome deve ter até 100 caracteres.")]
    [Display(Name = "Nome do computador")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a marca.")]
    [StringLength(60, ErrorMessage = "A marca deve ter até 60 caracteres.")]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o processador.")]
    [StringLength(100, ErrorMessage = "O processador deve ter até 100 caracteres.")]
    public string Processador { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a memória RAM.")]
    [Range(1, 2048, ErrorMessage = "A memória RAM deve estar entre 1 e 2048 GB.")]
    [Display(Name = "Memória RAM (GB)")]
    public int? MemoriaRamGb { get; set; }

    [Required(ErrorMessage = "Informe o armazenamento.")]
    [Range(1, 100000, ErrorMessage = "O armazenamento deve estar entre 1 e 100000 GB.")]
    [Display(Name = "Armazenamento (GB)")]
    public int? ArmazenamentoGb { get; set; }
}
