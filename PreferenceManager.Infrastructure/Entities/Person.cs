using System;
using System.Collections.Generic;

namespace PreferenceManager.Infrastructure.Entities
{
    public partial class Person
    {
        public Person()
        {
            PersonPreferences = new HashSet<PersonPreference>();
        }

        public long Id { get; set; }
        public string ExternalAuthId { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<PersonPreference> PersonPreferences { get; set; }
    }
}
