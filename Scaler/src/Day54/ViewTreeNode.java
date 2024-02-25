package Day54;

public class ViewTreeNode {
	public int data;
	public ViewTreeNode left;
	public ViewTreeNode right;
	
	ViewTreeNode(int data) {
		this.data = data;
		this.left = null;
		this.right = null;
	}
	public static void printPreOrderTree(ViewTreeNode ans) {
		System.out.print(ans.data + " ");
		printPreOrderTree(ans.left);
		printPreOrderTree(ans.right);
	}
	public static void printInOrderTree(ViewTreeNode ans) {	
		printPreOrderTree(ans.left);
		System.out.print(ans.data + " ");
		printPreOrderTree(ans.right);
	}
	public static void printPostTree(ViewTreeNode ans) {
		System.out.print(ans.data + " ");
		printPostTree(ans.left);
		printPostTree(ans.right);
	}
}
