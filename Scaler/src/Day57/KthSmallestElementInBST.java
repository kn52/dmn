package Day57;

public class KthSmallestElementInBST {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int kthsmallest(TreeNode A, int B) {

		int count = 0;
		TreeNode cur = A;
		while (cur != null && count != B) {
			if (cur.left == null) {
				count++;
				if (count == B)
					return cur.val;
				cur = cur.right;
			}
			else {
				TreeNode temp = cur.left;
				while (temp.right != null && temp.right != cur)
					temp = temp.right;
				if (temp.right == null) {
					temp.right = cur;
					cur = cur.left;
				}
				else {
					temp.right = null;
					count++;
					if (count == B)
						return cur.val;
					cur = cur.right;
				}
			}
		}
		return 0;
	}
}
