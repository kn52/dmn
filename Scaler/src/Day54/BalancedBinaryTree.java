package Day54;

public class BalancedBinaryTree {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	public static int isBalanced(ViewTreeNode A) {
		if (height(A) == 0) return 0;
		return 1;
	}
	public static int height(ViewTreeNode A) {
        if (A == null) return 1;

        int l = height(A.left);
        int r = height(A.right);

        if (l == 0 || r == 0 || Math.abs(l - r) > 1) return 0;   

        return Math.max(l, r) + 1;      
    }
}
