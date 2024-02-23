namespace observer_pattern_study_case_dotnet.console.Shop.Entities;

public class ProductMonitor : IObservable<Product>
{
    private readonly List<Product> cartProducts;

    public readonly List<IObserver<Product>> observers;

    public ProductMonitor()
    {
        observers = new List<IObserver<Product>>();
        cartProducts = new List<Product>()
        {
            new Product() { Id = 0, Name = "Cheesse", Status = Status.Cart },
            new Product() { Id = 1, Name = "Wine", Status = Status.Cart },
            new Product() { Id = 2, Name = "Soda", Status = Status.Cart },
            new Product() { Id = 3, Name = "Beer", Status = Status.Cart },
            new Product() { Id = 4, Name = "Carrot", Status = Status.Cart },
        };
    }

    public IDisposable Subscribe(IObserver<Product> observer)
    {
        if(! observers.Contains(observer)) observers.Add(observer);

        return default;
    }

    private void Notify(int productId)
    {
        var product = GetProductById(productId);
        foreach (var observer in observers)
        {
            observer.OnNext(product);
        }
    }

    public void RunProductLifeCycle(int id)
    {
        BuyProduct(id);
        Thread.Sleep(5000);
        StartProductDelivery(id);
        Thread.Sleep(7000);
        MarkProductAsReceived(id);
    }

    public void BuyProduct(int id)
    {
        var prod = GetProductById(id);
        prod.Status = Status.Ordered;
        Console.WriteLine($"User bought product Id = {id}");
        Notify(id);
    }

    public void StartProductDelivery(int id)
    {
        var prod = GetProductById(id);
        prod.Status = Status.Sending;
        Console.WriteLine($"Product Id = {id} is on its way");
        Notify(id);
    }

    public void MarkProductAsReceived(int id)
    {
        var prod = GetProductById(id);
        prod.Status = Status.Delivered;
        Console.WriteLine($"Product Id = {id} was delivered");
        Notify(id);
    }

    private Product GetProductById(int id)
    {
        var prod = cartProducts.Where(p => p.Id == id).FirstOrDefault();
        if (prod == null) throw new Exception("Not found");
        
        return prod;
    }
}
