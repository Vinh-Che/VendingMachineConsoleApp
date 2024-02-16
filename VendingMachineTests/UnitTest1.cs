using VendingMachineConsoleApp;

public class VendingMachineTests
{
    private VendingMachine vm;

    public VendingMachineTests()
    {
        vm = new VendingMachine();
        // Reset or initialize the state as needed for each test
    }

    [Fact]
    public void InsertMoney_IncreasesCredit()
    {
        vm.InsertMoney(50);
        Assert.Equal(50, vm.Credit); // Assuming Credit is a public property for testing
    }

    [Fact]
    public void RecallMoney_ResetsCreditToZero()
    {
        vm.InsertMoney(50);
        vm.RecallMoney();
        Assert.Equal(0, vm.Credit);
    }

    [Fact]
    public void OrderProduct_DecreasesCreditCorrectly()
    {
        // Arrange
        vm.InsertMoney(50); // Insert initial credit
        var expectedRemainingCredit = 30; // Assuming Coke costs 20, and initial credit is 50

        // Act
        vm.OrderProduct("Coke");

        // Assert
        // Assuming you have a way to verify remaining credit or change returned
        // This could require adjusting your VendingMachine design to support testing
        // For example, by checking a public property for remaining credit or change given back
        Assert.Equal(expectedRemainingCredit, vm.Credit); // This line needs your VendingMachine to expose remaining credit
    }

    // Note: You'll need to modify the VendingMachine class to expose the Credit property for testing.
}