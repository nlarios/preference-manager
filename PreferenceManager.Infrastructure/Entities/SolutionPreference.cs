using System;
using System.Collections.Generic;

namespace PreferenceManager.Infrastructure.Entities;

public partial class SolutionPreference
{
    public int Id { get; set; }
    public int SolutionId { get; set; }
    public int PreferenceId { get; set; }

    public virtual Preference Preference { get; set; } = null!;
    public virtual Solution Solution { get; set; } = null!;
}