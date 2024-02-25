package Day53;

import java.util.ArrayList;

public class PreOrderTransversal {

	static ArrayList<Integer> ans = new ArrayList<Integer>();
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		

	}
	
	public static ArrayList<Integer> preOrderTransversal(TreeNode A) {
		if(A==null){
            return ans;
        }
		
		ans.add(A.data);
		preOrderTransversal(A.left);
		preOrderTransversal(A.right);
		
		return ans;
	}
}
