// GolBet.Entities/Team.cs
using System.ComponentModel.DataAnnotations;
using GolBet.Entities.Common;

namespace GolBet.Entities;
public class Team : AuditableEntity // por medio de esta herencia, hereda ID y Fechas
{
    [Required, MaxLength(80)] // obligatorio y cuantos caracteres maximo
    public string Name { get; set; } = null!;

    [Required, MaxLength(60)]
    public string City { get; set; } = null!;

    [MaxLength(300)]
    public string? CrestUrl { get; set; } // escudo del equipo puede ser opcional y puede ser nulo
}
