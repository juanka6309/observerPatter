using observerPattern;

var observer1 = new Specialist("Juan");
var observer2 = new Specialist("Carlos");
var provider = new ApplicationsHandler();

observer1.Subscribe(provider);
observer2.Subscribe(provider);
provider.AddApplication(new(1, "Pedro"));
provider.AddApplication(new(2, "David"));

observer1.ListApplications();
observer2.ListApplications();

observer1.Unsubscribe();

Console.WriteLine();
Console.WriteLine($"{observer1.Name} unsubscribed");
Console.WriteLine();

provider.AddApplication(new(3, "Sofia"));
observer1.ListApplications();
observer2.ListApplications();
Console.WriteLine();
provider.CloseApplications();