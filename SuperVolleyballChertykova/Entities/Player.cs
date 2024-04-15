using System;

namespace SuperVolleyball.Entities;

public class Player
{
    public int PlayerId { get; set; }
    public string PlayerSurname { get; set; }
    public string Position { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime GameStart { get; set; }
    public string Team { get; set; }
}