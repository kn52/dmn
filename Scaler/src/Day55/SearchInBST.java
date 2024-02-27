package Day55;

public class SearchInBST {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int search(BSTTreeNode A, int target, int ans) {
		BSTTreeNode temp = A;
        if (temp == null) return 0;

        if (temp.val == target) return 1;
        else if (target < temp.val) ans = search(temp.left, target, ans);
        else if (target > temp.val) ans = search(temp.right, target, ans);

        return ans;
    }
}
