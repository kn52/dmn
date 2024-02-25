package Day53;

public class TreeNode {
	public int data;
	public TreeNode left;
	public TreeNode right;
	
	TreeNode(int data) {
		this.data = data;
		this.left = null;
		this.right = null;
	}
	public static void printPreOrderTree(TreeNode ans) {
		System.out.print(ans.data + " ");
		printPreOrderTree(ans.left);
		printPreOrderTree(ans.right);
	}
	public static void printInOrderTree(TreeNode ans) {	
		printPreOrderTree(ans.left);
		System.out.print(ans.data + " ");
		printPreOrderTree(ans.right);
	}
	public static void printPostTree(TreeNode ans) {
		System.out.print(ans.data + " ");
		printPostTree(ans.left);
		printPostTree(ans.right);
	}
}
