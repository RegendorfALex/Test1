using System;
using System.Collections.Generic;

namespace API;

public partial class Daigno
{
    public int Id { get; set; }

    public string? DiagnosName { get; set; }

    public virtual ICollection<Procedur> Procedurs { get; set; } = new List<Procedur>();
}
