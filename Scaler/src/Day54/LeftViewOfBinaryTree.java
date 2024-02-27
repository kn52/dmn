package Day54;

import java.util.*;

public class LeftViewOfBinaryTree {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	public static ArrayList<Integer> solve(ViewTreeNode A) {
        Queue<ViewTreeNode> q = new LinkedList<>();
        ArrayList<Integer> ans = new ArrayList<>();
        q.add(A);

        while(!q.isEmpty()) {
            int n = q.size();
            ViewTreeNode node = q.peek();
            ans.add(node.val);
            for (int i = 0; i < n; i++) {
            	ViewTreeNode temp = q.peek();
                q.remove();
                if (temp.right != null) {
                    q.add(temp.right);
                }
                if (temp.left != null) {
                    q.add(temp.left);
                }
            }
        }
        return ans;
    }
}
