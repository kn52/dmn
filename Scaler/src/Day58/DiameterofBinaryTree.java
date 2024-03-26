package Day58;

public class DiameterofBinaryTree {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int solve(TreeNode A) {
		return getDiameter(A);
	}

	private int getDiameter(TreeNode currNode) {
		if (currNode == null) {
			return 0;
		}

		int heightLST = getHeight(currNode.left);
		int heightRST = getHeight(currNode.right);

		return Math.max(heightLST + heightRST, Math.max(getDiameter(currNode.left), getDiameter(currNode.right)));
	}

	private int getHeight(TreeNode currNode) {
		if (currNode == null) {
			return 0;
		}

		return 1 + Math.max(getHeight(currNode.left), getHeight(currNode.right));
	}

}
