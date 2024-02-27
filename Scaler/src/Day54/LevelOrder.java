package Day54;

import java.util.*;

public class LevelOrder {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public static ArrayList<ArrayList<Integer>> solve(ViewTreeNode A) {
		Queue<ViewTreeNode> q = new LinkedList<>();
        ArrayList<ArrayList<Integer>> ans = new ArrayList<>();
        q.add(A);

        while(!q.isEmpty()) {
            ArrayList<Integer> ani = new ArrayList<>();
            int n = q.size();
            for (int i = 1; i <= n; i++) {
            	ViewTreeNode temp = q.peek();
                q.remove();
                ani.add(temp.val);
                if (temp.left != null) {
                    q.add(temp.left);
                }
                if (temp.right != null) {
                    q.add(temp.right);
                }
            }
            ans.add(ani);
        }
        return ans;
	}
}
