namespace ktsu.ImGuiPopups;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using ImGuiNET;

public partial class ImGuiPopups
{
	/// <summary>
	/// A class for displaying a prompt popup window.
	/// </summary>
	public class Prompt
	{
		private Modal Modal { get; } = new();
		private string Label { get; set; } = string.Empty;
		private Dictionary<string, Action?> Buttons { get; set; } = [];
		private bool WrapText { get; set; }

		/// <summary>
		/// Open the popup and set the title, label, and button definitions.
		/// </summary>
		/// <param name="title">The title of the popup window.</param>
		/// <param name="label">The label of the input field.</param>
		/// <param name="buttons">The names and actions of the buttons.</param>
		public virtual void Open(string title, string label, Dictionary<string, Action?> buttons) => Open(title, label, buttons, customSize: Vector2.Zero);
		/// <summary>
		/// Open the popup and set the title, label, and button definitions.
		/// </summary>
		/// <param name="title">The title of the popup window.</param>
		/// <param name="label">The label of the input field.</param>
		/// <param name="buttons">The names and actions of the buttons.</param>
		/// <param name="customSize">Custom size of the popup.</param>
		public virtual void Open(string title, string label, Dictionary<string, Action?> buttons, Vector2 customSize) => Open(title, label, buttons, wrapText: false, customSize);
		/// <summary>
		/// Open the popup and set the title, label, and button definitions.
		/// </summary>
		/// <param name="title">The title of the popup window.</param>
		/// <param name="label">The label of the input field.</param>
		/// <param name="buttons">The names and actions of the buttons.</param>
		/// <param name="wrapText">Should ImGui.TextWrapped be called.</param>
		/// <param name="size">Custom size of the popup.</param>
		public void Open(string title, string label, Dictionary<string, Action?> buttons, bool wrapText, Vector2 size)
		{
			// Wrapping text without a custom size will result in an incorrectly sized
			// popup as the text will wrap based on the popup and the popup will size
			// based on the text.
			Debug.Assert(!wrapText || (size != Vector2.Zero));

			Label = label;
			Buttons = buttons;
			WrapText = wrapText;
			Modal.Open(title, ShowContent, size);
		}

		/// <summary>
		/// Show the content of the popup.
		/// </summary>
		private void ShowContent()
		{
			if (WrapText)
			{
				ImGui.TextWrapped(Label);
			}
			else
			{
				ImGui.TextUnformatted(Label);
			}
			ImGui.NewLine();

			foreach (var (text, action) in Buttons)
			{
				if (ImGui.Button(text))
				{
					action?.Invoke();
					ImGui.CloseCurrentPopup();
				}
				ImGui.SameLine();
			}
		}

		/// <summary>
		/// Show the modal if it is open.
		/// </summary>
		/// <returns>True if the modal is open.</returns>
		public bool ShowIfOpen() => Modal.ShowIfOpen();
	}
}
