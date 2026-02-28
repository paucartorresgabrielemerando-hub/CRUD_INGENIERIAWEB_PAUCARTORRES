using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbModel.demoDb;

[Table("persona_empleo")]
[Index("IdPersona", Name = "ix_persona_empleo_id_persona")]
public partial class PersonaEmpleo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("empresa")]
    [StringLength(150)]
    public string Empresa { get; set; } = null!;

    [Column("cargo")]
    [StringLength(100)]
    public string? Cargo { get; set; }

    [Column("fecha_inicio", TypeName = "date")]
    public DateTime FechaInicio { get; set; }

    [Column("fecha_fin", TypeName = "date")]
    public DateTime? FechaFin { get; set; }

    [Column("salario", TypeName = "decimal(10,2)")]
    public decimal? Salario { get; set; }

    [Column("user_create")]
    public int UserCreate { get; set; }

    [Column("user_update")]
    public int? UserUpdate { get; set; }

    [Column("date_created", TypeName = "timestamp")]
    public DateTime? DateCreated { get; set; }

    [Column("date_update", TypeName = "timestamp")]
    public DateTime? DateUpdate { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("PersonaEmpleos")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}

