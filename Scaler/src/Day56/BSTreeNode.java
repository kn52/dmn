package Day56;

public class BSTreeNode {
	public int val;
	public BSTreeNode left;
	public BSTreeNode right;
	
	BSTreeNode(int val) {
		this.val = val;
		this.left = null;
		this.right = null;
	}
	public static void printPreOrderTree(BSTreeNode ans) {
		System.out.print(ans.val + " ");
		printPreOrderTree(ans.left);
		printPreOrderTree(ans.right);
	}
	public static void printInOrderTree(BSTreeNode ans) {	
		printPreOrderTree(ans.left);
		System.out.print(ans.val + " ");
		printPreOrderTree(ans.right);
	}
	public static void printPostTree(BSTreeNode ans) {
		System.out.print(ans.val + " ");
		printPostTree(ans.left);
		printPostTree(ans.right);
	}
}
