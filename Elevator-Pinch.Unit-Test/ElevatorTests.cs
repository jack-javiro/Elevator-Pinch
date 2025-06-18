namespace Elevator_Pinch.Unit_Test;

public class ElevatorTests
{
    [Fact]
    public void AddFloorRequest_AddsRequest()
    {
        var elevator = new Elevator();
        elevator.AddFloorRequest(2, Direction.Up);
        Assert.True(elevator.HasRequests());
    }

    [Fact]
    public void HasRequests_ReturnsFalseWhenNoRequests()
    {
        var elevator = new Elevator();
        Assert.False(elevator.HasRequests());
    }

    [Fact]
    public void HasRequests_ReturnsTrueWhenRequestsExist()
    {
        var elevator = new Elevator();
        elevator.AddFloorRequest(3, Direction.Up);
        Assert.True(elevator.HasRequests());
    }

    [Fact]
    public async Task StepAsync_ProcessesRequests()
    {
        var elevator = new Elevator();
        elevator.AddFloorRequest(2, Direction.Up);
        await elevator.StepAsync();
        Assert.True(elevator.CurrentFloor == 2 || elevator.CurrentFloor == 1);
    }

}
