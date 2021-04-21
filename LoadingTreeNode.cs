using System.Windows.Forms;

namespace ReportSync
{
    /// <summary>
    /// A node to signify that the parent hasn't been loaded yet.
    /// </summary>
    /// <remarks>
    /// The user will see "...loading..." while the children are being loaded. This node is then deleted.
    /// </remarks>
    public class LoadingTreeNode : TreeNode
    {
        private readonly string ssrsPath;

        public LoadingTreeNode(string ssrsPath)
        {
            this.ssrsPath = ssrsPath;

            this.Text = Properties.Resources.TreeNodeLoading;
        }

        public string SsrsPath { get { return this.ssrsPath; } }

        /// <summary>
        /// Tries to get the child <see cref="LoadingTreeNode"/>.
        /// </summary>
        /// <param name="treeNode">The parent tree node.</param>
        /// <param name="loadingTreeNode">The loading tree node, if any.</param>
        /// <returns><c>true</c> if the <paramref name="treeNode"/> had a <see cref="LoadingTreeNode"/>.</returns>
        public static bool TryGetLoadingNode(TreeNode treeNode, out LoadingTreeNode loadingTreeNode)
        {
            if ((treeNode.Nodes.Count == 1) && (treeNode.Nodes[0] is LoadingTreeNode))
            {
                loadingTreeNode = (LoadingTreeNode)treeNode.Nodes[0];
                return true;
            }

            loadingTreeNode = null;
            return false;
        }
    }
}