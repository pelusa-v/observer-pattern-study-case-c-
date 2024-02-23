using observer_pattern_study_case_dotnet.console.Shop.Entities;

namespace observer_pattern_study_case_dotnet.console.Observers;

public class ProductNotificator : IObserver<Product>
{
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Product value)
    {
        Console.WriteLine($"-> Notification: The status of the product with Id = {value.Id} is {value.Status.ToString()}");
    }
}
