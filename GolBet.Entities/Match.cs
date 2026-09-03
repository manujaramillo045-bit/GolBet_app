// GolBet.Entities/Match.cs
using System.ComponentModel.DataAnnotations.Schema;
using GolBet.Entities.Common;
using GolBet.Entities.Enums;

namespace GolBet.Entities;
public class Match : AuditableEntity
{
    public DateTime Date { get; set; }
    public MatchStatus Status { get; set; } = MatchStatus.Scheduled; //enum
    public int? HomeGoals { get; set; } // opcional, puede ser nulo
    public int? AwayGoals { get; set; } // opcional, puede ser nulo

    [Column(TypeName = "decimal(5,2)")] // cuando se cree la tabla (columna) en la base de datos, se creara con el tipo decimal y 5 digitos en total y 2 decimales
    public decimal HomeOdds { get; set; }

    [Column(TypeName = "decimal(5,2)")] // cuando se cree la tabla (columna) en la base de datos, se creara con el tipo decimal y 5 digitos en total y 2 decimales
    public decimal DrawOdds { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal AwayOdds { get; set; }

    // Two foreign keys to the same table (Team) and relationships. This is a common scenario in sports betting, where a match involves two teams (home and away). The foreign keys are HomeTeamId and AwayTeamId, which reference the primary key of the Team table. The navigation properties HomeTeam and AwayTeam allow for easy access to the related Team entities.

    public int HomeTeamId { get; set; } // PK
    public Team HomeTeam { get; set; } = null!; // la relacion de PK con la tabla Team, se inicializa con null! para evitar null reference exception
    
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = null!; // relacion con team

    //Navigation Property. Sirve para que cuando se consulte un partido, se pueda consultar todas las apuestas que se han hecho a ese partido. Se inicializa con una lista vacia para evitar null reference exception.
    public ICollection<Bet> Bets { get; set; } = new List<Bet>(); // relacion con Bet, un partido puede tener muchas apuestas y se representa con ICollection
}
