namespace SuperVolleyball.Entities;

public class Position
{
    public int PositionId { get; set; }
    public string PositionName { get; set; }
    public override string ToString()
    {
        return PositionName;
    }
}