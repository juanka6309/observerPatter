using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observerPattern
{
    internal class Specialist : IObserver<Application>
    {
        public string Name { get; set; }
        public List<Application> Applications { get; set; }
        public Specialist(string name)
        {
            Name = name;
            Applications = new();
        }
        public void ListApplications()
        {
            if (Applications.Any())
                foreach (var app in Applications)
                    Console.WriteLine($"Hello, {Name}! {app.ApplicantName} has just applied for job {app.JobId}");
            else
                Console.WriteLine($"Hey, {Name}! No applications yet.");
        }

        private IDisposable _cancellation;
        public virtual void Subscribe(ApplicationsHandler provider)
        {
            _cancellation = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            _cancellation.Dispose();
            Applications.Clear();
        }
        public void OnCompleted()
        {
            Console.WriteLine($"Hey, {Name}! We are not accepting any more applications");
        }
        public void OnError(Exception error)
        {
        }
        public void OnNext(Application value)
        {
            Applications.Add(value);
        }
    }
}
