using Microsoft.AspNetCore.SignalR;

public class BudgetHub : Hub
{
    public async Task JoinBudget(string budgetId)
    {
        // Client joins the budget room
        await Groups.AddToGroupAsync(Context.ConnectionId, budgetId);
        Console.WriteLine($"User joined budget room: {budgetId}");
    }

    // Client sends a transaction update
    public async UpdateTransaction(string budgetId, Transaction transaction)
    {
        // Notify all clients in the budget room about the transaction update
        await Clients.OthersInGroup(budgetId).SendAsync("TransactionUpdated" transaction);
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Client connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }
    
        public override async Task OnDisconnectedAsync(Exception exception)
    {
        Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }
}