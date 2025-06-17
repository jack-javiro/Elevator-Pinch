namespace Elevator_Pinch;

public class FloorRequest
{
    public int Floor { get; set; }
    public Direction Direction { get; set; }
    public FloorRequest(int floor, Direction direction)
    {
        Floor = floor;
        Direction = direction;
    }
}