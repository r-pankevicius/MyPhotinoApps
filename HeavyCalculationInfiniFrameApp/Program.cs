using InfiniFrame;
using InfiniFrame.Security;
using System.Security.Cryptography;

namespace HeavyCalculationInfiniFrameApp;

internal static class Program
{
	[STAThread]
	static void Main(string[] args)
	{
		var windowBuilder = InfiniFrameWindowBuilder.Create();
		var window = windowBuilder
			.SetTitle("I'm freshly opened")
			.SetMaximized(true)
			.SetTrustAllOrigins(true)
			.EnableContextMenu(false)
			.EnableIgnoreCertificateErrors(true)
			.EnableJavascriptClipboardAccess(true)
			.EnableMediaAutoplay(true)
			.EnableMediaStream(true)
			.EnableWebSecurity(false)
			.EnableFileSystemAccess(true)
			.EnableNotifications(false)
			.SetStartPageContent("I've just started.")
			.Build();

		var progress = new Progress<WorkerMessage>(message =>
		{
			if (message.Progress > 10_000_000)
			{
				window.SetTitle("Main page");
				window.Load(new Uri("https://docs.infiniframe.dev/"));
			}
			else if (message.Progress > 1_000_000)
			{
				window.SetTitle("Loading page");
				window.Load("Loading.html");
			}
			else
			{
				window.LoadRawString($"Working hard - {message.Text} ({message.Progress})");
			}
		});

		Task.Run(() => DoHeavyWorkAndAnnoyBrowser(progress));

		window.LoadRawString("I've just started.");

		window.WaitForClose(); // Starts the application event loop
	}

	static void DoHeavyWorkAndAnnoyBrowser(IProgress<WorkerMessage> progress)
	{
		Console.WriteLine("Intensive calculations are running in background...");

		byte[] data = new byte[1024 * 1024]; // 1 MB
		Random.Shared.NextBytes(data);

		using var sha256 = SHA256.Create();

		byte[] hash = data;

		const int iterations = 100_000_000;
		const int printStep = 1_000_000;

		for (int i = 0; i < iterations; i++)
		{
			hash = sha256.ComputeHash(hash);
			if (i % printStep == 0)
			{
				progress.Report(new WorkerMessage($"Progress: {i} / {iterations}", i));
				Console.WriteLine($"Progress: {i} / {iterations}");
			}
		}

		Console.WriteLine(Convert.ToHexString(hash));
	}

	record WorkerMessage(string Text, int Progress);
}
