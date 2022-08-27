using System;
using System.Collections.Generic;

namespace PreferenceManager.Infrastructure.Entities
{
    public partial class PersonPreference
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public int PreferenceId { get; set; }
        public string PreferenceValue { get; set; } = null!;
        public string? EncryptedValue { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual Preference Preference { get; set; } = null!;
    }
}
