namespace SuperVolleyball.Entities;

public class Team
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public override string ToString()
    {
        return TeamName;
    }
}