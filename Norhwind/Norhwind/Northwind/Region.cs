﻿using System;
using System.Collections.Generic;

namespace Norhwind.Northwind;

public partial class Region
{
    public short RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; } = new List<Territory>();
}