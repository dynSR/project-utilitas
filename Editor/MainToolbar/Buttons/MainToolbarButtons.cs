using UnityEngine;
using UnityEditor;
using UnityEditor.Toolbars;

namespace Utilitas {
    internal class MainToolbarButtons {
        [MainToolbarElement(
            "Buttons/Open Project Settings",
            defaultDockPosition = MainToolbarDockPosition.Left,
            menuPriority = 0
        )]
        public static MainToolbarElement ProjectSettingsButton() {
            var icon = EditorGUIUtility.IconContent("SettingsIcon").image as Texture2D;
            var content = new MainToolbarContent(icon);
            return new MainToolbarButton(content, () => { SettingsService.OpenProjectSettings(); });
        }

        [MainToolbarElement("Buttons/Preferences", defaultDockPosition = MainToolbarDockPosition.Left)]
        public static MainToolbarElement PreferencesButton() {
            var icon = EditorGUIUtility.IconContent("MoreOptions").image as Texture2D;
            var content = new MainToolbarContent(icon);
            return new MainToolbarButton(content, () => { SettingsService.OpenUserPreferences(); });
        }
    }
}