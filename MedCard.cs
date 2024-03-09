using System;
using System.Collections.Generic;

namespace API;

public partial class MedCard
{
    public int Id { get; set; }

    public DateTime? DateLast { get; set; }

    public DateTime? DateFuture { get; set; }

    public int? IdPacient { get; set; }

    public DateTime? CreatePolis { get; set; }

    public DateTime? EndPolis { get; set; }

    public int? NumberPolis { get; set; }

    public string? PolisCompany { get; set; }

    public virtual Pacient? IdPacientNavigation { get; set; }

    public virtual ICollection<Pacient> Pacients { get; set; } = new List<Pacient>();
}
