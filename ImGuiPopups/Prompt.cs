namespace ktsu.io.ImGuiWidgets;

using System;
using System.Collections.Generic;
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

		/// <summary>
		/// Open the popup and set the title, label, and button definitions.
		/// </summary>
		/// <param name="title">The title of the popup window.</param>
		/// <param name="label">The label of the input field.</param>
		/// <param name="buttons">The names and actions of the buttons.</param>
		public virtual void Open(string title, string label, Dictionary<string, Action?> buttons)
		{
			Label = label;
			Buttons = buttons;
			Modal.Open(title, ShowContent);
		}

		/// <summary>
		/// Show the content of the popup.
		/// </summary>
		private void ShowContent()
		{
			ImGui.TextUnformatted(Label);
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
