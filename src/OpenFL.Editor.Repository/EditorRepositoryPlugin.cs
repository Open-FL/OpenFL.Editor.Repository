using System.Diagnostics;
using System.Linq;

using OpenFL.Editor.Utils.Plugins;

using PluginSystem.Core;
using PluginSystem.Core.Pointer;
using PluginSystem.Repository;
using PluginSystem.Utility;

namespace OpenFL.Editor.Repository
{
    public class EditorRepositoryPlugin : APlugin<FLEditorPluginHost>
    {

        private RepositoryPlugin repoPlugin;


        private RepositoryViewer viewer;

        [ToolbarItem("Repository Manager", int.MaxValue / 2)]
        private void RepositoryDummy()
        {
        }

        private RepositoryPlugin GetPlugin()
        {
            if (repoPlugin == null)
            {
                repoPlugin = PluginManager.GetPlugins<RepositoryPlugin>().FirstOrDefault();
                if (repoPlugin == null)
                {
                    repoPlugin = new RepositoryPlugin();
                    PluginManager.AddPlugin(
                                            repoPlugin,
                                            new PluginAssemblyPointer(
                                                                      "repository-plugin",
                                                                      "",
                                                                      "",
                                                                      "0.0.0.0",
                                                                      PluginManager.PluginHost
                                                                     )
                                           );
                }
            }

            return repoPlugin;
        }

        [ToolbarItem("Repository Manager/Edit Origins..", 1)]
        private void EditOrigins()
        {
            RepositoryPlugin plugin = GetPlugin();
            Process.Start(plugin.OriginFile);
        }

        [ToolbarItem("Repository Manager/Show Tree", 0)]
        private void OpenRepository()
        {
            RepositoryPlugin plugin = GetPlugin();

            if (viewer == null || viewer.IsDisposed)
            {
                viewer = new RepositoryViewer(plugin.GetPlugins());
            }

            viewer?.Show();
        }

    }
}