using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using OpenFL.Editor.Utils.Plugins;

using PluginSystem.Core;
using PluginSystem.Core.Pointer;
using PluginSystem.Repository;
using PluginSystem.Utility;

using ThemeEngine.Forms;

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
                    PluginAssemblyPointer ptr = new PluginAssemblyPointer(
                                                                          "repository-plugin",
                                                                          "",
                                                                          "",
                                                                          "0.0.0.0",
                                                                          PluginManager.PluginHost
                                                                         );
                    
                    PluginManager.AddPlugin(
                                            repoPlugin,
                                            ptr
                                           );
                }
            }
            if (!File.Exists(repoPlugin.OriginFile))
            {
                DialogResult res = StyledMessageBox.Show(
                                                         $"{repoPlugin.PluginAssemblyData.PluginName}: First Startup.",
                                                         "Do you want to create the default Origins File?",
                                                         MessageBoxButtons.YesNo,
                                                         SystemIcons.Question
                                                        );
                if (res == DialogResult.Yes)
                {
                    File.WriteAllText(repoPlugin.OriginFile, "https://open-fl.github.io/RepositoryOrigins/open-fl-editor.txt\nhttps://open-fl.github.io/RepositoryOrigins/open-fl.txt\nhttps://open-fl.github.io/RepositoryOrigins/plugin-system.txt");
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

        [ToolbarItem("Repository Manager/Delete Origins..", 1)]
        private void DeleteOrigins()
        {
            RepositoryPlugin plugin = GetPlugin();
            if (File.Exists(plugin.OriginFile)) File.Delete(plugin.OriginFile);
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