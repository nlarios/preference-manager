using System;
using System.Collections.Generic;

namespace PreferenceManager.Infrastructure.Entities
{
    public partial class Preference
    {
        public Preference()
        {
            PersonPreferences = new HashSet<PersonPreference>();
            SolutionPreferences = new HashSet<SolutionPreference>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Universal { get; set; }

        public virtual ICollection<PersonPreference> PersonPreferences { get; set; }
        public virtual ICollection<SolutionPreference> SolutionPreferences { get; set; }
    }
}
