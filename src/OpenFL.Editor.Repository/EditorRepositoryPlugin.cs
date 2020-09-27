using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [ToolbarItem("Repository Manager", int.MaxValue/2)]
        private void RepositoryDummy()
        {

        }

        [ToolbarItem("Repository Manager/Edit Origins..", 1)]
        private void EditOrigins()
        {
            Process.Start(plugin.OriginFile);
        }

        [ToolbarItem("Repository Manager/Show Tree", 0)]
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
