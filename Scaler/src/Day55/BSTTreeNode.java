package Day55;

public class BSTTreeNode {
	public int val;
	public BSTTreeNode left;
	public BSTTreeNode right;
	
	BSTTreeNode(int val) {
		this.val = val;
		this.left = null;
		this.right = null;
	}
	public static void printPreOrderTree(BSTTreeNode ans) {
		System.out.print(ans.val + " ");
		printPreOrderTree(ans.left);
		printPreOrderTree(ans.right);
	}
	public static void printInOrderTree(BSTTreeNode ans) {	
		printPreOrderTree(ans.left);
		System.out.print(ans.val + " ");
		printPreOrderTree(ans.right);
	}
	public static void printPostTree(BSTTreeNode ans) {
		System.out.print(ans.val + " ");
		printPostTree(ans.left);
		printPostTree(ans.right);
	}
}
