using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PluginSystem.Core.Pointer;
using PluginSystem.StartupActions;

using ThemeEngine;

namespace OpenFL.Editor.Repository
{
    public partial class RepositoryViewer : Form
    {
        public RepositoryViewer(List<PluginSystem.Repository.Repository> repos)
        {
            InitializeComponent();
            StyleManager.RegisterControls(this);
            
            foreach (PluginSystem.Repository.Repository repository in repos)
            {
               TreeNode node= tvRepos.Nodes.Add(repository.RepositoryOrigin);
                foreach (BasePluginPointer basePluginPointer in repository.Plugins)
                {
                    node.Nodes.Add(basePluginPointer.ToKeyPair());
                }
            }

            tvRepos.NodeMouseDoubleClick+= TvReposOnNodeMouseDoubleClick;
        }

        private void TvReposOnNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                ActionRunner.AddActionToStartup($"{ActionRunner.ADD_PACKAGE_ACTION} {new BasePluginPointer(e.Node.Text).PluginOrigin}");
                MessageBox.Show("Will be installed on restart.");
            }
        }

        private void tvRepos_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
