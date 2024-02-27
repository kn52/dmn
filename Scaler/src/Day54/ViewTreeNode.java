package Day54;

public class ViewTreeNode {
	public int val;
	public ViewTreeNode left;
	public ViewTreeNode right;
	
	ViewTreeNode(int data) {
		this.val = data;
		this.left = null;
		this.right = null;
	}
	public static void printPreOrderTree(ViewTreeNode ans) {
		System.out.print(ans.val + " ");
		printPreOrderTree(ans.left);
		printPreOrderTree(ans.right);
	}
	public static void printInOrderTree(ViewTreeNode ans) {	
		printPreOrderTree(ans.left);
		System.out.print(ans.val + " ");
		printPreOrderTree(ans.right);
	}
	public static void printPostTree(ViewTreeNode ans) {
		System.out.print(ans.val + " ");
		printPostTree(ans.left);
		printPostTree(ans.right);
	}
}
