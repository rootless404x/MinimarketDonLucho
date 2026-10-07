using System.ComponentModel.DataAnnotations;

namespace MinimarketDonLucho.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
    [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    public List<Producto> Productos { get; set; } = new();
}
