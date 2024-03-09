using System;
using System.Collections.Generic;

namespace API;

public partial class Pacient
{
    public int Id { get; set; }

    public string? F { get; set; }

    public string? I { get; set; }

    public string? O { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? Born { get; set; }

    public string? PasportSeria { get; set; }

    public string? PasportAdres { get; set; }

    public int? IdMedCard { get; set; }

    public byte[]? Photo { get; set; }

    public string? Rabota { get; set; }

    public virtual ICollection<Gospitalisation> Gospitalisations { get; set; } = new List<Gospitalisation>();

    public virtual MedCard? IdMedCardNavigation { get; set; }

    public virtual ICollection<MedCard> MedCards { get; set; } = new List<MedCard>();

    public virtual ICollection<Procedur> Procedurs { get; set; } = new List<Procedur>();
}
