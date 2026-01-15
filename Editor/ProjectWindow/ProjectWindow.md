# Project Window Enhancer

### Rules to follow

- To minimize impact on performances :
    - Always check if the "Event.current" equals Event.Repaint

### How to differentiate elements in project hierarchy

```csharp
var isFolder = AssetDatabase.IsValidFolder(guid.ToPath());
var isAsset = !isFolder && !guid.IsNullOrEmpty();
var isSubasset = isAsset && typeof(AssetDatabase).InvokeMethod<bool>("IsSubAsset", instanceId);
```

### Research

```csharp
// A way to get the project browser ???
  static Type t_ProjectBrowser = typeof(Editor).Assembly.GetType("UnityEditor.ProjectBrowser");
```

```csharp
// Idk what this thing does for the moment
  static IEnumerable<EditorWindow> allBrowsers => _allBrowsers ??= t_ProjectBrowser.GetFieldValue<IList>("
  s_ProjectBrowsers").Cast<EditorWindow>();
```

```csharp
// A structure/class to represent Folders (used for cache/verification(s) purposes)
 public class Folder {
        public string path => guid.ToPath();
        public string name => path.Split('/').Last();
        public int color = 0;
        public string icon = "";
        public Folder(string guid) => this.guid = guid;
        string guid; 
 }
```

ShowFolderContents =
“Affiche ce dossier dans le Project Browser comme si l’utilisateur venait de cliquer dessus”
