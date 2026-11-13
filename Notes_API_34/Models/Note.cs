using System;
using System.Collections.Generic;

namespace Notes_API_34.Models;

public partial class Note
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public int IdUser { get; set; }

    public DateOnly CreatedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
