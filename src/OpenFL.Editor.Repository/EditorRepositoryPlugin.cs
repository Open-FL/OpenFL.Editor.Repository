using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenFL.Editor.Utils.Plugins;

using PluginSystem.Core;
using PluginSystem.Repository;
using PluginSystem.Utility;

namespace OpenFL.Editor.Repository
{
    public class EditorRepositoryPlugin: APlugin<FLEditorPluginHost>
    {

        public override bool HasIO => true;

        public override bool IsMainPlugin => true;

        public override string Name => "fl-editor-repository-plugin";

        private RepositoryViewer viewer = null;
        private RepositoryPlugin plugin = null;

        [ToolbarItem("Repository Manager")]
        private void OpenRepository()
        {
            if (plugin == null)
            {
               plugin= PluginManager.GetPlugins<RepositoryPlugin>().FirstOrDefault();
            }
            if (plugin != null && (viewer == null || viewer.IsDisposed))
            {
                viewer = new RepositoryViewer(plugin.GetPlugins());
            }

            viewer?.Show();
        }
    }
}
