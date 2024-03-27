package Day58;

import java.util.*;

public class NextPointerBinarryTree {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public void connect(TreeNode root) {
		Queue<TreeNode> q = new LinkedList<>();
		q.add(root);
		q.add(null);

		while (q.size() > 1) {
			TreeNode front = q.peek();
			q.remove();

			if (front != null) {
				front.next = q.peek();
				if (front.left != null) {
					q.add(front.left);
				}
				if (front.right != null) {
					q.add(front.right);
				}
			} else {
				q.add(null);
			}
		}
	}
}
