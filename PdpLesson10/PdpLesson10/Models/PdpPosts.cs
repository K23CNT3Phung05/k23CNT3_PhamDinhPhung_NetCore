using System;
using System.Collections.Generic;

namespace PdpLesson10.Models;

public partial class PdpPosts
{
    public int PdpId { get; set; }

    public string? PdpTitle { get; set; }

    public string? PdpImage { get; set; }

    public string? PdpContent { get; set; }

    public bool? PdpStatus { get; set; }
}