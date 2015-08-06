<Query Kind="Program">
  <NuGetReference Version="2.2.2">Rx-Core</NuGetReference>
  <NuGetReference Version="2.2.2">Rx-Interfaces</NuGetReference>
  <NuGetReference Version="2.2.2">Rx-Linq</NuGetReference>
  <NuGetReference Version="2.2.2">Rx-Main</NuGetReference>
  <NuGetReference Version="2.2.2">Rx-PlatformServices</NuGetReference>
  <NuGetReference Version="2.2.2">Rx-Xaml</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <NuGetReference>WindowsAzure.ServiceBus</NuGetReference>
  <Namespace>Microsoft.ServiceBus.Messaging</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
	
	var interval = Observable.Interval(TimeSpan.FromMilliseconds(200))
							 .Select(_ =>
								{
									var message = Guid.NewGuid().ToString();
									eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(message)));
									return string.Format("{0} > Sending message: {1}", DateTime.Now, message);
								});
								
	interval.Dump();
}

// Define other methods and classes here
static string eventHubName = "sourceHub";
static string connectionString = "Endpoint=sb://sourcehub-ns.servicebus.windows.net/;SharedAccessKeyName=ReadWrite;SharedAccessKey=QuanyKfCMZJdBuk8ZuNwOvueSV/Gx5IC0X/CEJz+xxw=";
