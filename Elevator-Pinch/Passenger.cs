namespace Elevator_Pinch;

public class Passenger
{
    public int DestinationFloor { get; set; }
    public Passenger(int destinationFloor)
    {
        DestinationFloor = destinationFloor;
    }
}