﻿using System.ComponentModel.DataAnnotations;

public class Anime
{
    public int id { get; set; }
    public string name { get; set; }
    public string genre { get; set; }
    public int? rating { get; set; }
}