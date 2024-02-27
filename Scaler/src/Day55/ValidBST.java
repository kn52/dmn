package Day55;

public class ValidBST {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	public static int isValidBST(BSTTreeNode A) {
        int ans = isBST(A.left, Integer.MIN_VALUE, A.val) && isBST(A.right, A.val, Integer.MAX_VALUE) ? 1 : 0;
        return ans;
    }

    public static boolean isBST(BSTTreeNode temp, int min, int max) {
        if (temp == null) return true;
        if(temp.val>=max || temp.val<=min) return false;
        return isBST(temp.left, min, temp.val) && isBST(temp.right, temp.val, max);
    }

}
