package Day58;

public class EqualTreePartition {

	long sum = 0;
	int ans = 0;

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int solve(TreeNode A) {
		sum = getSum(A);
		if (sum % 2 != 0) {
			return 0;
		} else {
			modifiedSum(A, sum);
			return ans;
		}

	}

	public long modifiedSum(TreeNode root, long s) {
		if (root == null) {
			return 0;
		}
		long l = modifiedSum(root.left, s);
		long r = modifiedSum(root.right, s);
		if (l == s / 2 || r == s / 2) {
			ans = 1;
		}
		return l + r + root.val;
	}

	public long getSum(TreeNode root) {
		if (root == null) {
			return 0;
		}
		return root.val + getSum(root.left) + getSum(root.right);
	}
}
