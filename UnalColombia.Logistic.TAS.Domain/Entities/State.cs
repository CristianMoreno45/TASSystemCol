﻿using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class State: IActivatable
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public string? Code1 { get; set; }
        public string? Code2 { get; set; }
        public string? Code3 { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<City>? Cities { get; set; }
    }
}
