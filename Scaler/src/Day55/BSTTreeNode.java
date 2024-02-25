package Day55;

public class BSTTreeNode {
	public int data;
	public BSTTreeNode left;
	public BSTTreeNode right;
	
	BSTTreeNode(int data) {
		this.data = data;
		this.left = null;
		this.right = null;
	}
	public static void printPreOrderTree(BSTTreeNode ans) {
		System.out.print(ans.data + " ");
		printPreOrderTree(ans.left);
		printPreOrderTree(ans.right);
	}
	public static void printInOrderTree(BSTTreeNode ans) {	
		printPreOrderTree(ans.left);
		System.out.print(ans.data + " ");
		printPreOrderTree(ans.right);
	}
	public static void printPostTree(BSTTreeNode ans) {
		System.out.print(ans.data + " ");
		printPostTree(ans.left);
		printPostTree(ans.right);
	}
}
