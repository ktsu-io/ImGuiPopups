namespace ktsu.io.ImGuiWidgetsDemo;

using ImGuiNET;
using ktsu.io.ImGuiApp;
using ktsu.io.ImGuiWidgets;

internal class ImGuiPopupsDemo
{
	private static void Main()
	{
		ImGuiPopupsDemo imGuiPopupsDemo = new();
		ImGuiApp.Start(nameof(ImGuiPopupsDemo), new ImGuiAppWindowState(), imGuiPopupsDemo.OnStart, imGuiPopupsDemo.OnTick, imGuiPopupsDemo.OnMenu, imGuiPopupsDemo.OnWindowResized);
	}

	private static string inputString = "String Input Popup";
	internal static readonly string[] Friends = ["James", "Cameron", "Matt", "Troy", "Hali"];

	private readonly ImGuiPopups.InputString popupInputString = new();
	private readonly ImGuiPopups.FilesystemBrowser popupFilesystemBrowser = new();
	private readonly ImGuiPopups.MessageOK popupMessageOK = new();
	private readonly ImGuiPopups.SearchableList<string> popupSearchableList = new();

	private void OnStart()
	{
	}

	private void OnTick(float dt)
	{
		if (ImGui.Button(inputString))
		{
			popupInputString.Open("Enter a string", "Enter", "Yeet", (string result) =>
			{
				inputString = result;
			});
		}

		if (ImGui.Button("Open File"))
		{
			popupFilesystemBrowser.FileOpen("Open File", (f) =>
			{
				popupMessageOK.Open("File Chosen", $"You chose: {f}");
			}, "*.cs");
		}

		if (ImGui.Button("Save File"))
		{
			popupFilesystemBrowser.FileSave("Save File", (f) =>
			{
				popupMessageOK.Open("File Chosen", $"You chose: {f}");
			}, "*.cs");
		}

		if (ImGui.Button("Choose Best Friend"))
		{
			popupSearchableList.Open("Best Friend", "Who is your best friend?", Friends, (string result) =>
			{
				popupMessageOK.Open("Best Friend Chosen", $"You chose: {result}");
			});
		}

		popupSearchableList.ShowIfOpen();
		popupMessageOK.ShowIfOpen();
		popupInputString.ShowIfOpen();
		popupFilesystemBrowser.ShowIfOpen();
	}

	private void OnMenu()
	{
		// Method intentionally left empty.
	}

	private void OnWindowResized()
	{
		// Method intentionally left empty.
	}
}
