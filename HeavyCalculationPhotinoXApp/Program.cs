using Photino.NET;
using System.Security.Cryptography;

namespace HeavyCalculationPhotinoXApp;

internal static class Program
{
	[STAThread]
	static void Main(string[] args)
	{
		var app = new PhotinoApplication();

		var window = new PhotinoWindow();

		var progress = new Progress<WorkerMessage>(message =>
		{
			if (message.Progress > 10_000_000)
			{
				window.SetTitle("Main page");
				window.Load(new Uri("https://tryphotino.io/"));
			}
			else if (message.Progress > 1_000_000)
			{
				window.SetTitle("Loading page");
				window.Load("Loading.html");
			}
			else
			{
				window.LoadString($"Working hard - {message.Text} ({message.Progress})");
			}
		});

		Task.Run(() => DoHeavyWorkAndAnnoyBrowser(progress));

		window
			.SetTitle("I'm freshly opened")
			.SetUseOsDefaultSize(true)
			.SetMaximized(true)
			.SetContextMenuEnabled(false)
			.SetIgnoreCertificateErrorsEnabled(true)
			.SetJavascriptClipboardAccessEnabled(true)
			.SetMediaAutoplayEnabled(true)
			.SetMediaStreamEnabled(true)
			.SetWebSecurityEnabled(false)
			.SetFileSystemAccessEnabled(true)
			.LoadString("I've just started.");

		app.Run(window);
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
