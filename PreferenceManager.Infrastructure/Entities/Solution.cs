using System;
using System.Collections.Generic;

namespace PreferenceManager.Infrastructure.Entities
{
    public partial class Solution
    {
        public Solution()
        {
            SolutionPreferences = new HashSet<SolutionPreference>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Host { get; set; } = null!;

        public virtual ICollection<SolutionPreference> SolutionPreferences { get; set; }
    }
}
