using System;
using System.Collections.Generic;

namespace API;

public partial class Procedur
{
    public int Id { get; set; }

    public int? IdPacient { get; set; }

    public int? IdDiagnos { get; set; }

    public DateTime? Date { get; set; }

    public int? IdMedCard { get; set; }

    public string? ProcedurName { get; set; }

    public string? Result { get; set; }

    public string? Recomendation { get; set; }

    public virtual Daigno? IdDiagnosNavigation { get; set; }

    public virtual Pacient? IdPacientNavigation { get; set; }
}
