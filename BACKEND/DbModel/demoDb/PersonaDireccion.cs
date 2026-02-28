using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbModel.demoDb;

[Table("persona_direccion")]
[Index("IdPersona", Name = "ix_persona_direccion_id_persona")]
public partial class PersonaDireccion
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("tipo")]
    [StringLength(20)]
    public string Tipo { get; set; } = null!;

    [Column("direccion")]
    [StringLength(300)]
    public string Direccion { get; set; } = null!;

    [Column("ciudad")]
    [StringLength(80)]
    public string? Ciudad { get; set; }

    [Column("region")]
    [StringLength(80)]
    public string? Region { get; set; }

    [Column("codigo_postal")]
    [StringLength(15)]
    public string? CodigoPostal { get; set; }

    [Column("user_create")]
    public int UserCreate { get; set; }

    [Column("user_update")]
    public int? UserUpdate { get; set; }

    [Column("date_created", TypeName = "timestamp")]
    public DateTime? DateCreated { get; set; }

    [Column("date_update", TypeName = "timestamp")]
    public DateTime? DateUpdate { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("PersonaDirecciones")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}

