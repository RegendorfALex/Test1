using System;
using System.Collections.Generic;

namespace API;

public partial class Gospitalisation
{
    public int Id { get; set; }

    public int? IdPacient { get; set; }

    public int? Pasport { get; set; }

    public string? Job { get; set; }

    public string? PolisNumber { get; set; }

    public DateTime? PolisStart { get; set; }

    public DateTime? PolisEnd { get; set; }

    public DateTime? PolisCompany { get; set; }

    public DateTime? DateGospitalisation { get; set; }

    public string? Price { get; set; }

    public string? Otdelenie { get; set; }

    public string? NameDiagnos { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public string? Status { get; set; }

    public virtual Pacient? IdPacientNavigation { get; set; }
}
