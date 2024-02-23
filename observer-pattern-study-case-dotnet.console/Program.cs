// See https://aka.ms/new-console-template for more information
using observer_pattern_study_case_dotnet.console.Observers;
using observer_pattern_study_case_dotnet.console.Shop.Entities;

Console.WriteLine("Hello, World!");

var productNotificator = new ProductNotificator();
var monitor = new ProductMonitor();
monitor.Subscribe(productNotificator);

monitor.RunProductLifeCycle(1);