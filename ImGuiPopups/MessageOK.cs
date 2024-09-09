namespace ktsu.io.ImGuiPopups;

public partial class ImGuiPopups
{
	/// <summary>
	/// A class for displaying a prompt popup window.
	/// </summary>
	public class MessageOK : Prompt
	{
		/// <summary>
		/// Open the popup and set the title and message.
		/// </summary>
		/// <param name="title">The title of the popup window.</param>
		/// <param name="message">The message to show.</param>
		public void Open(string title, string message) => base.Open(title, message, new() { { "OK", null } });
	}
}
