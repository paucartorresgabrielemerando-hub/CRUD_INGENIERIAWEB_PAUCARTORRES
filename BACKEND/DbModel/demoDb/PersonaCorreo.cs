using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbModel.demoDb;

[Table("persona_correo")]
[Index("IdPersona", Name = "ix_persona_correo_id_persona")]
public partial class PersonaCorreo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("correo")]
    [StringLength(150)]
    public string Correo { get; set; } = null!;

    [Column("es_principal")]
    public bool EsPrincipal { get; set; }

    [Column("user_create")]
    public int UserCreate { get; set; }

    [Column("user_update")]
    public int? UserUpdate { get; set; }

    [Column("date_created", TypeName = "timestamp")]
    public DateTime? DateCreated { get; set; }

    [Column("date_update", TypeName = "timestamp")]
    public DateTime? DateUpdate { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("PersonaCorreos")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}

