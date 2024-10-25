using Photino.NET;
using System.Drawing;

namespace SimplePhotinoApp;

internal static class Program
{
	[STAThread]
	static void Main(string[] args)
	{
		// Set up "loading" page
		var window = new PhotinoWindow()
			.SetTitle(nameof(SimplePhotinoApp))
			// Resize to a percentage of the main monitor work area
			.SetUseOsDefaultSize(false)
			.SetSize(new Size(1024, 800))
			// Center window in the middle of the screen
			.Center()
			// Users can resize windows by default.
			// Let's make this one fixed instead.
			.SetResizable(false)
			.Load("Loading.html");

		// Redirect to web page after 3 sec
		Timer timer = new(TimerCallback, null, 3000, Timeout.Infinite);

		window.WaitForClose(); // Starts the application event loop

		void TimerCallback(object state)
		{
			window.Load(new Uri("https://tryphotino.io/"));
		}
	}
}
