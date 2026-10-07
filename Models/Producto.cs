using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimarketDonLucho.Models;

public class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(80, ErrorMessage = "Máximo 80 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Precio { get; set; }

    public int Stock { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de vencimiento")]
    public DateTime? FechaVencimiento { get; set; }

    [Display(Name = "Categoría")]
    public int CategoriaId { get; set; }

    public Categoria? Categoria { get; set; }
}
