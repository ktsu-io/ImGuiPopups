namespace ktsu.ImGuiPopups;

using System.Numerics;

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
		public void Open(string title, string message) => Open(title, message, customSize: Vector2.Zero);
		/// <summary>
		/// Open the popup and set the title and message.
		/// </summary>
		/// <param name="title">The title of the popup window.</param>
		/// <param name="message">The message to show.</param>
		/// <param name="customSize">Custom size of the popup.</param>
		public void Open(string title, string message, Vector2 customSize) => Open(title, message, wrapText: false, customSize);
		/// <summary>
		/// Open the popup and set the title and message.
		/// </summary>
		/// <param name="title">The title of the popup window.</param>
		/// <param name="message">The message to show.</param>
		/// <param name="wrapText">Should the text be wrapped.</param>
		/// <param name="size">Custom size of the popup.</param>
		public void Open(string title, string message, bool wrapText, Vector2 size) => Open(title, message, new() { { "OK", null } }, wrapText, size);
	}
}
