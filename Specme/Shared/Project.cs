using System;
using System.Collections.Generic;
using System.Text;

namespace Specme.Shared
{
    public class Project
    {
        public string UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
